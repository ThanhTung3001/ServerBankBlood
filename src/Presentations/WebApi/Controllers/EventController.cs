using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contexts;
using Data.Repos;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbEntities.Post;
using Models.DTOs.Event;
using Models.PaginationList;
using Models.ResponseModels;

namespace WebApi.Controllers;

public class EventController : CrudControllerBase<Event>
{
    public ApplicationDbContext _appDbContext { get; set; }
    private readonly IAccountService _accountService;
    public EventController(IGenericRepository<Event> genericRepository, IMapper mapper, ApplicationDbContext appDbContext, IAccountService accountService) : base(genericRepository, mapper)
    {
        _appDbContext = appDbContext;
        _accountService = accountService;
    }

    [HttpGet]
    public override async Task<ActionResult> Gets([FromQuery] PaginationListQuery query)
    {

        try
        {
            var response = await _appDbContext.Events
                .AsTracking()
                .OrderByDescending(e => e.Id)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .Include(e => e.EventUserSubs)
                    .ThenInclude(eus => eus.userInfo)
                .ToListAsync();


            var result = _mapper.Map<List<Event>, List<EventDto>>(response);
            var totalRecords = await _appDbContext.Events.CountAsync();
            var totalPages = (totalRecords / query.PageSize) + 1;


            return Ok(new PaginationListResponse<List<EventDto>>(result, query.PageNumber, query.PageSize, totalPages, totalRecords));
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponse<object>(message: e.ToString()));

        }

    }
    [HttpGet("EventSubcribe")]
    public async Task<ActionResult> GetEventSubcribe()
    {

        try
        {
            var response = await _appDbContext.EventUserSubs.ToListAsync();
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(new BaseResponse<object>(message: e.ToString()));

        }

    }

    [HttpPost("Subcribe/{id}")]
    public async Task<IActionResult> SubcribeEvent(int id)
    {
        try
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //   Console.Write(userId);
            var userInfo = await _accountService.GetFullUserInfo(username);
            var entity = new EventUserSub()
            {
                UserInfoId = userInfo.UserInfo.Id,
                EventId = id
            };
            var response = await _appDbContext.EventUserSubs.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return Ok(new BaseResponse<object>(response.Entity, "Subcribe event sucess"));

        }
        catch (Exception ex)
        {

            return Ok(new BaseResponse<object>(ex.ToString(), "Subcribe event success"));
        }
    }

}