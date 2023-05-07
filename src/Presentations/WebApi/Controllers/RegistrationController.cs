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
using Services.Interfaces;
using WebApi.Extensions;

namespace WebApi.Controllers;

public class RegistrationController : CrudControllerBase<Register>
{
    public ApplicationDbContext _appDbContext { get; set; }
    public IAuthenticatedUserService _iAuthenService { get; set; }
    public RegistrationController(IGenericRepository<Register> genericRepository, IMapper mapper, ApplicationDbContext appDbContext, IAuthenticatedUserService IAuthenService) : base(genericRepository, mapper)
    {
        _appDbContext = appDbContext;
        _iAuthenService = IAuthenService;
    }

    [HttpGet]
    public override async Task<ActionResult> Gets([FromQuery] PaginationListQuery query)
    {

        try
        {
            var response = await _appDbContext.Registers.OrderByDescending(e => e.Id)
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
    [HttpGet("GetByMe")]
    public async Task<ActionResult> GetByMe([FromQuery] PaginationListQuery query)
    {

        try
        {
            var UserEmail = _iAuthenService.UserEmail;
            var userInfo = await _appDbContext.UserInfo.FirstOrDefaultAsync(e => e.Email == UserEmail);
            var response = await _appDbContext.Registers.OrderByDescending(e => e.Id).Where(e => e.UserId == userInfo.Id)
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
    [HttpPost("DonateBlood")]
    public async Task<IActionResult> DonateBlood([FromBody] RegisterDtoCreate model)
    {
        try
        {
            var UserEmail = _iAuthenService.UserEmail;
            var userInfo = await _appDbContext.UserInfo.FirstOrDefaultAsync(e => e.Email == UserEmail);
            var entity = _mapper.Map<Register>(model);
            entity.UserId = userInfo.Id;
            //entity.RegisterTime = DateTime.Now;
            entity.CreateUTC = DateTime.Now;
            var response = await _appDbContext.Registers.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            var qrPath = AppGenerateQrCode.GenerateQrCode(response.Entity.Id.ToString(), userInfo.Iccid.ToString());
            entity.QrCode = qrPath;
            _appDbContext.Registers.Update(entity);
            await _appDbContext.SaveChangesAsync();
            var result = _mapper.Map<RegisterDto>(response.Entity);
            return Ok(new BaseResponse<RegisterDto>(result, message: $"Add data {typeof(RegisterDto)} success"));
        }
        catch (Exception ex)
        {

            return BadRequest(new BaseResponse<RegisterDto>(null, message: $"Add data {typeof(RegisterDto)} fail {ex.ToString()}"));
        }

    }
    [HttpGet("GetById/{id}")]

    public async Task<IActionResult> GetById(int id){
        try
        {
            var response = await _appDbContext.Registers.Include(e=>e.BloodGroup)
            .Include(e=>e.Hospital)
            .Include(e=>e.UserInfo)
            .FirstOrDefaultAsync(e=>e.Id==id);
             return Ok(new BaseResponse<RegisterDto>(_mapper.Map<RegisterDto>(response), message: $"Get data {typeof(RegisterDto)} success"));
        }
        catch (System.Exception)
        {
            
            return NotFound();
        }
    }

    [HttpGet("GetRegistrationByHospital")]
    public async Task<IActionResult> GetByHospitalAsync()
    {
        var UserEmail = _iAuthenService.UserEmail;
        var userInfo = await _appDbContext.UserInfo.FirstOrDefaultAsync(e => e.Email == UserEmail);
        //     var hospital = await _appDbContext.Hospitals.Include(e=>e.Register).FirstOrDefaultAsync(e=>e.Id==userInfo.AppUserId);
        var register = await _appDbContext.Registers.Include(e => e.UserInfo).Include(e => e.Hospital).Include(e => e.BloodGroup).Where(e => e.HospitalId == userInfo.HospitalId).ToListAsync();
        return Ok(new BaseResponse<List<RegisterDto>>(_mapper.Map<List<RegisterDto>>(register), message: $"Get data {typeof(RegisterDto)} success"));

    }
    [HttpPut("UpdateStatusRegis/{id}/{status}")]
    public async Task<IActionResult> UpdateRegistration(int id, int status)
    {
        try
        {
            var regis = await _appDbContext.Registers.FirstOrDefaultAsync(e => e.Id == id);
            if (regis == null)
            {
                throw new EntryPointNotFoundException();
            }
            else
            {
                regis.status = (Models.Enums.StatusType)status;
                 _appDbContext.Registers.Update(regis);
                await _appDbContext.SaveChangesAsync();
                return Ok(new
                {
                    message = "Update Regis success",
                    data = regis
                });
            }
        }
        catch (System.Exception ex)
        {
                return BadRequest(new {
                     message = $"Update Regis fail: {ex.ToString()}",
                     data = ""
                });
        }
    }

}