using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public interface IFileService
    {
        public string InsertFile(IFormFile formFile, string path);
    }
}
