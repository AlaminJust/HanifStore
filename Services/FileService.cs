using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileService
            (
                IWebHostEnvironment hostEnvironment
            )
        {
            _hostEnvironment = hostEnvironment;
        }
        public string InsertFile(IFormFile formFile, string path)
        {
            string uniqueFileName = null;

            if (formFile != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath , path);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
