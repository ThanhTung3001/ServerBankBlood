using System;

using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Data.Contexts;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Models.DbEntities.Attachments;
using Models.Enums;

namespace Identity.Services.Concrete
{
    public class UploadFileService : IUploadFileService
    {
        private readonly ApplicationDbContext _context;

        public UploadFileService(ApplicationDbContext context) { _context = context;}
        public async Task<Media> UploadFile(string path, IFormFile file)
        {
              var now = DateTime.Now.Second;
            // var file = Request.Form.Files["image"];
            var folderName = Path.Combine("wwwroot", "uploads", path);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            var fileName = now.ToString()+"_"+ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
          
            var imagePath = $"/uploads/{path}/{fileName}";
            var mediaSave = new Media()
            {
                Path = imagePath,
                FileName = fileName,
                Type = FileType.Image
            };
            var entity = await _context.Medias.AddAsync(mediaSave);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

    }
}