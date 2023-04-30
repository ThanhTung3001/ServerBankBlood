using Net.Codecrete.QrCodeGenerator;
using System;
using System.IO;

namespace WebApi.Extensions
{
    public class AppGenerateQrCode
    {

        public static string GenerateQrCode(string dataContext, string username)
        {

            try
            {
                var qr = QrCode.EncodeText(dataContext, QrCode.Ecc.Medium);
                //  qr.SaveAsPng("hello-world-qr.png", 10, 3);
                var fileName = username +"_"+ DateTime.Now.Second.ToString() + "_bloodbank.png";
                // Save the Bitmap image to a file
               var folderName = Path.Combine("wwwroot", "uploads", "QrCode");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
           // var fileName = now.ToString()+"_"+ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
                qr.SaveAsPng(fullPath, 10,3);
                return $"/uploads/QrCode/{fileName}";
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

    }

}