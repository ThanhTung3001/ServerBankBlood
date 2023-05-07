using AutoMapper;
using Identity.Models;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Account;
using Models.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Attributes;
using Data.Contexts;
using System.Linq;
using System;
using Models.DbEntities.User;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _AppDbContext;
        public AdminController(IAccountService accountService, IMapper mapper, ApplicationDbContext AppContext)
        {
            _accountService = accountService;
            _mapper = mapper;
            _AppDbContext = AppContext;
        }

        [Cached(2)]
        [Authorize(Policy = "OnlyAdmins")]
        [HttpGet("alluser")]
        public async Task<IActionResult> GetAllUser()
        {
            var userList = await _accountService.GetUsers();
            var data = _mapper
                .Map<IReadOnlyList<ApplicationUser>, IReadOnlyList<UserDto>>(userList);

            return Ok(new BaseResponse<IReadOnlyList<UserDto>>(data, $"User List"));
        }

      //  [Cached(1)]
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("alluserwithroles")]
        public async Task<IActionResult> GetAllUserWithRoles()
        {
            var userList = await _accountService.GetUsers();
         
            var result = userList.Select(x => (new UserDto
            {
                Id = x.Id,
                phoneNumber = x.PhoneNumber,
                email = x.Email,
                userName = x.UserName,
                firstName = x.FirstName,
                lastName = x.LastName,
                roles = x.UserRoles.ToList().Select(y => y.Role.Name.ToString()).ToList(),
                avatar = x.UserInfo!=null?(x.UserInfo.Avatar):"",
                createDate = x.UserInfo!=null?(x.UserInfo.CreateUTC):DateTime.Now,
                userInfo = _mapper.Map<UserInfoDto>(_AppDbContext.UserInfo.Include(x=>x.Hospital).FirstOrDefault(e=>e.AppUserId==x.Id))
            }));

            return Ok(result);
        }
    }
}

