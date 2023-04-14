using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DbEntities;
using Models.PaginationList;
using Models.ResponseModels;
using Exception = System.Exception;

namespace WebApi.Controllers;

// [Authorize]
[Route("api/[controller]")]
[ApiController]
public class CrudControllerBase<TEntity,TDTO>:ControllerBase where TEntity:BaseEntity  where TDTO:class
{
    public CrudControllerBase(IGenericRepository<TEntity> genericRepository, IMapper mapper)
    {
        _GenericRepository = genericRepository;
        _mapper = mapper;
    }
    private IGenericRepository<TEntity> _GenericRepository { get; set; }
    private IMapper _mapper { get; set; }

    [HttpGet]
    public async Task<ActionResult> Gets([FromQuery] PaginationListQuery listQuery)
    {
        try
        {
            var dataPaging = await _GenericRepository.PaginationList(listQuery);
            var dataMapper = _mapper.Map<List<TDTO>>(dataPaging.Data);
            
            return Ok(new PaginationListResponse<List<TDTO>>(dataMapper,dataPaging.PageNumber,
                dataPaging.PageSize,dataPaging.TotalPages,dataPaging.TotalRecords));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponse<object>(message:e.ToString()));
            
        }
        
    }

    [HttpPost]
    public IActionResult Create([FromBody] TEntity entity)
    {
        try
        {
           var response = _GenericRepository.Insert(entity);
           return Ok(new BaseResponse<TEntity>(response, message: $"Add data {typeof(TEntity)} success"));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponse<object>(message:e.ToString()));
       
        }
    }
    
    [HttpPut("{Id}")]
    public IActionResult Update([FromBody] TEntity entity,int Id)
    {
        try
        {
            if (Id != entity.Id)
            {
                return BadRequest();
            }
            var item = _GenericRepository.GetById(entity.Id);
            if (item != null)
            {
                 item = _GenericRepository.Update(entity);
                return Ok(new BaseResponse<TEntity>(item, message: $"Update data {typeof(TEntity)} success"));
            }
         
            return BadRequest(new BaseResponse<TEntity>(null, message: $"Update data {typeof(TEntity)} fail: item not exist"));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponse<object>(message:e.ToString()));
       
        }
    }
    
    [HttpDelete("{Id}")]
    public async Task<ActionResult> Gets(int Id)
    {
        try
        {
            var item = _GenericRepository.GetById(Id);
            if (item == null)
            {
                return NotFound();
            }
            var response = _GenericRepository.Delete(item);
            
            return Ok(new BaseResponse<int>(response, message: $"Delete data {typeof(TEntity)} success"));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponse<object>(message:e.ToString()));
            
        }
        
    }

}