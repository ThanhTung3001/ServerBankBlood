using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models.DbEntities.Attachments;

namespace Identity.Services.Interfaces
{
    public interface IUploadFileService
    {
        public Task<Media> UploadFile(string path,IFormFile file);
    }
}