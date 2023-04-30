using System;
using System.Threading.Tasks;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private IUploadFileService _uploadFileService ;

        public  UploadController(IUploadFileService uploadFileService){
            _uploadFileService  = uploadFileService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromQuery]string path,IFormFile file)
        {
            try
            {
             //  var file = Request.Form.Files["image"];
                var media = await _uploadFileService.UploadFile(path,file);
                return Ok(new {
                    message = "Upload file success",
                    data = media
                });
            }
            catch(Exception ex)
            {
                return StatusCode(500,$"Internal server error {ex.ToString()}");
            }
        }

    }
}