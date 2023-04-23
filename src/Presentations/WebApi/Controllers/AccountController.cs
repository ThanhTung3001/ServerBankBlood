using Data.Mongo.Collections;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Account;
using Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IMapper _mapper ;
        private readonly IAccountService _accountService;
        private readonly ILoginLogService _loginLogService;



        public AccountController(IAccountService accountService, ILoginLogService loginLogService,IMapper mapper )
        {
            _accountService = accountService;
            _loginLogService = loginLogService;
            _mapper = mapper;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            //auth
            var result = await _accountService.AuthenticateAsync(request);
            if (result.Errors == null || !result.Errors.Any())
            {
                //mongo usage example
                LoginLog log = new LoginLog()
                {
                    LoginTime = DateTime.Now,
                    UserEmail = request.Email
                };
             //   await _loginLogService.Add(log);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("getMe")]
        public async Task<IActionResult> GetMe(){
              try
              {
                  var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                //   Console.Write(userId);
                  var userInfo =  await _accountService.GetFullUserInfo(username);
                  var result =  _mapper.Map<UserDto>(userInfo);
                  return Ok(new {
                    data = result,
                    message = "Get data sucess"
                  });
              }
              catch (Exception ex)
              {
                return BadRequest(new {
                      data = "",
                      message = $"Get data Fail {ex.ToString()}"
                });
                throw;
              }
                
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var uri = $"{Request.Scheme}://{Request.Host.Value}";
            return Ok(await _accountService.RegisterAsync(request, uri));
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        {
            return Ok(await _accountService.ConfirmEmailAsync(userId, code));
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var uri = $"{Request.Scheme}://{Request.Host.Value}";
            await _accountService.ForgotPasswordAsync(request, uri);
            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            return Ok(await _accountService.ResetPasswordAsync(request));
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
        {
            return Ok(await _accountService.RefreshTokenAsync(request));
        }

        [HttpGet("logout")]
        public async Task<IActionResult> LogoutAsync(string userEmail)
        {
            return Ok(await _accountService.LogoutAsync(userEmail));
        }

        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        [HttpGet("check-email")]
        public IActionResult CheckEmail([FromQuery] string email)
        {
            var result = _accountService.ExistUserByEmail(email);
            if (!result)
            {
                return Ok(new
                {
                    message = "Email not exist",
                    code = 200
                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "Email is exist",
                    code = 300
                });
            }
        }

        [HttpPatch("update-roles")]
        public async Task<IActionResult> UpdateRoleForUser([FromBody] UpdateRole model)
        {
            try
            {
                await _accountService.AddRoleForUser(model.roles, model.UserName);
                return Ok(new
                {
                    message = "Update Role Success",
                    code = 200

                });
            }
            catch (Exception ex)
            {

                return BadRequest(new   {
                    message = $"Update Role Fail  {ex.ToString()}",
                    code = 400

                });
            }
        }
        [HttpDelete("delete-users/{username}")]
        public async Task<IActionResult> DeleteUser(string username){
            try
            {
                await _accountService.RemoveUser(username);
                return Ok(new {
                    message="Delete user sucess",
                    code = 200
                });
            }
            catch (System.Exception)
            {
                return BadRequest(
                    new {
                        messsage="Delete User failt",
                        code=400
                    }
                );
                throw;
            }
        }    
    }
}
