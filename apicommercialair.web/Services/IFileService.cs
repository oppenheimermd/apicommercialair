using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apicommercialair.web.Services
{
    public interface IFileService
    {
        string SetPhotoName();
        string GetPhotoFilePath(string fileName);
        Task<string> SavePhotoFile(byte[] bytes, string fileName);
        Task DeletePhoto(string fileName);
    }
}
