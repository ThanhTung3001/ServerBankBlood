using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contexts;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbEntities.Registration;
using Models.DTOs.BloodgroupDtos;
using Models.PaginationList;
using Models.ResponseModels;

namespace WebApi.Controllers;

public class RegistrationController : CrudControllerBase<Register>
{
    public ApplicationDbContext _appDbContext { get; set; }
    public RegistrationController(IGenericRepository<Register> genericRepository, IMapper mapper, ApplicationDbContext appDbContext) : base(genericRepository, mapper)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public override async Task<ActionResult> Gets([FromQuery] PaginationListQuery query)
    {

        try
        {
            var response = await _appDbContext.Registers.OrderByDescending(e=>e.Id)
                 .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize).
                 Include(e => e.BloodGroup)
                .Include(e => e.UserInfo)
                .Include(e => e.Hospital)
                .ToListAsync();

            var result = _mapper.Map<List<Register>, List<RegisterDto>>(response);
            var totalRecords = await _appDbContext.Registers.CountAsync();
            var totalPages = (totalRecords / query.PageSize) + 1;


            return Ok(new PaginationListResponse<List<RegisterDto>>(result, query.PageNumber, query.PageSize, totalPages, totalRecords));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponse<object>(message: e.ToString()));

        }

    }
}