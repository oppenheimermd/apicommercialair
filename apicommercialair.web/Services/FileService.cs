using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace apicommercialair.web.Services
{
    public class FileService : IFileService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string _aircraftImages;

        public FileService(IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
                _aircraftImages = Path.Combine(env.WebRootPath, "Images\\aircraft\\");
                _contextAccessor = contextAccessor;
        }

        public string SetPhotoName()
        {
            var fileName = DateTime.Now.ToString() + ".jpg";
            return fileName;
        }

        public string GetPhotoFilePath(string fileName)
        {
            return Path.Combine(_aircraftImages, fileName);
        }

        public async Task<string> SavePhotoFile(byte[] bytes, string fileName)
        {
            var ext = Path.GetExtension(fileName);
            var name = Path.GetFileNameWithoutExtension(fileName);

            var relative = $"aircraft/{name}{ext}";
            var absolute = Path.Combine(_aircraftImages, relative);
            var dir = Path.GetDirectoryName(absolute);

            Directory.CreateDirectory(dir);
            using (var writer = new FileStream(absolute, FileMode.CreateNew))
            {
                await writer.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
            }

            return "/Images/" + relative;
        }

        public Task DeletePhoto(string fileName)
        {
            var filePath = GetPhotoFilePath(fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return Task.CompletedTask;
        }

    }
}
