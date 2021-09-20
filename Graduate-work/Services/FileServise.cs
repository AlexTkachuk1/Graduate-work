using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Graduate_work.Services
{
    public class FileService
    {
        private IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetTempDocxFilePath()
        {
            var fileName = $"{Guid.NewGuid()}.docx";
            return Path.Combine(_webHostEnvironment.WebRootPath, "temp", fileName);
        }

        public string GetFolderPath()
            => Path.Combine(_webHostEnvironment.WebRootPath, "images\\pictures");

        public string GetPath(long id)
            => Path.Combine(GetFolderPath(), $"{id}.png");

        public string GetUrl(long id)
            => $"/images/pictures/{id}.png";
    }
}
