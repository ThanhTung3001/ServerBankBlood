
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("{path}")]
        public async Task<IActionResult> UploadImage(string path)
        {
            try
            {
               var file = Request.Form.Files["image"];
                var media = await _uploadFileService.UploadFile(path,file);
                return Ok(new {
                    message = "Upload file success",
                    data = media
                });
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}