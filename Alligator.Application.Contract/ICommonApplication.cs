using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Alligator.Domain.Model;

namespace Alligator.Application.Contract
{
    public interface ICommonApplication
    {
        
        Task<string> CreateFileAsync(IFormFile formFile, string folderName);
        Task<string> CreateFileAsync(string base64, string folderName, string extension);
        Task<string> GenrateOtp();

        IFormFile GetFile(List<IFormFile> Files, string FileName);

    }
}
