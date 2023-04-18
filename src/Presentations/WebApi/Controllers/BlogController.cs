using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contexts;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbEntities.Post;
using Models.DTOs.Blogs;
using Models.PaginationList;
using Models.ResponseModels;

namespace WebApi.Controllers;

public class BlogController : CrudControllerBase<Blog>
{
    public ApplicationDbContext _appDbContext { get; set; }
    public BlogController(IGenericRepository<Blog> genericRepository, IMapper mapper,ApplicationDbContext appDbContext) : base(genericRepository, mapper)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public override async Task<ActionResult> Gets([FromQuery] PaginationListQuery query)
    {

        try
        {
            var response = await _appDbContext.Blogs
                 .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize).
                 Include(e => e.Category)
                .Include(e => e.BlogTags)
                .ToListAsync();

            var result = _mapper.Map<List<Blog>, List<BlogDto>>(response);
            var totalRecords = await _appDbContext.Blogs.CountAsync();
            var totalPages = (totalRecords / query.PageSize) + 1;


            return Ok(new PaginationListResponse<List<BlogDto>>(result, query.PageNumber, query.PageSize, totalPages, totalRecords));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponse<object>(message: e.ToString()));

        }

    }

}