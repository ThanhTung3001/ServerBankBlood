using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contexts;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DbEntities.User;
using Models.ResponseModels;

namespace WebApi.Controllers;

public class UserInfoController:CrudControllerBase<UserInfo>
{
    private readonly ApplicationDbContext _AppContext;
    public UserInfoController(IGenericRepository<UserInfo> genericRepository, IMapper mapper,ApplicationDbContext AppContext) : base(genericRepository, mapper)
    {
        _AppContext = AppContext;
    }
    [HttpGet("GetUserByAppUserId")]
    public async Task<IActionResult> GetUserInfoByAppUserId ([FromQuery] int appUserId){
        try
        {
            var userInfo =  await _AppContext.UserInfo.Where(e=>e.AppUserId==appUserId)
            .Include(e=>e.Hospital)
            .FirstOrDefaultAsync();
            userInfo.Hospital = await _AppContext.Hospitals.Where(e=>e.Id==userInfo.HospitalId).FirstOrDefaultAsync();
          return Ok(new BaseResponse<UserInfo>(userInfo, message: $"Get data sucess"));
        }
        catch (System.Exception ex)
        {
            
            return BadRequest(new BaseResponse<object>(ex.ToString(),"Get data fail"));
        }
    }
     [HttpPut("UpdateHospitalId/{hospitalId}")]
    public async Task<IActionResult> UpdateHospitalId (int hospitalId,[FromQuery] int appUserId){
        try
        {
            var userInfo =  await _AppContext.UserInfo.Where(e=>e.AppUserId==appUserId)
            .Include(e=>e.Hospital)
            .FirstOrDefaultAsync();
            userInfo.HospitalId = hospitalId;
            _AppContext.Update(userInfo);
             await _AppContext.SaveChangesAsync();
          return Ok(new BaseResponse<UserInfo>(userInfo, message: $"Get data sucess"));
        }
        catch (System.Exception ex)
        {
            
            return BadRequest(new BaseResponse<object>(ex.ToString(),"Get data fail"));
        }
    }
}