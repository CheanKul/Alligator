using Alligator.Application.Contract;
using Alligator.Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Alligator.Application
{
    public class CommonApplication : ICommonApplication
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment hostingEnvironment;

        public CommonApplication(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            this.configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        }
       

        public async Task<string> CreateFileAsync(IFormFile formFile, string folderName)
        {
            if (string.IsNullOrWhiteSpace(hostingEnvironment.WebRootPath))
            {
                hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            var webRoot = hostingEnvironment.WebRootPath;


            if (!System.IO.Directory.Exists(webRoot + $"\\{folderName}"))
            {
                System.IO.Directory.CreateDirectory(webRoot + $"\\{folderName}");
            }
            Random random = new Random();

            string imageName;
            if (formFile != null && formFile.Length > 0)
            {
                imageName = random.Next(111111, 9999999).ToString() + Path.GetExtension(formFile.FileName);
                using (var fileStream = new FileStream(Path.Combine(webRoot, folderName, imageName), FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
            }
            else
            {
                return null;
            }
            return "/" + folderName + "/" + imageName;
        }


        public async Task<string> CreateFileAsync(List<IFormFile> formFile, string folderName)
        {
            if (string.IsNullOrWhiteSpace(hostingEnvironment.WebRootPath))
            {
                hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            var webRoot = hostingEnvironment.WebRootPath;


            if (!System.IO.Directory.Exists(webRoot + $"\\{folderName}"))
            {
                System.IO.Directory.CreateDirectory(webRoot + $"\\{folderName}");
            }
            string imageName = "";
            for (int i = 0; i < formFile.Count; i++)
            {

                if (formFile[i] != null && formFile[i].Length > 0)
                {
                    imageName = formFile[i].FileName;
                    using (var fileStream = new FileStream(Path.Combine(webRoot, folderName, imageName), FileMode.Create))
                    {
                        await formFile[i].CopyToAsync(fileStream);
                    }
                }
                else
                {
                    return null;
                }
            }
            return "/" + folderName + "/" + imageName;
        }




        public IFormFile GetFile(List<IFormFile> Files, string FileName)
        {
            if (!FileName.Contains("."))
            {
                FileName = FileName + ".jpg";
            }

            return Files.Where(f => f.FileName.ToLower().Equals(FileName.ToLower())).FirstOrDefault();
        }


        public async Task<string> CreateFileAsync(string base64, string folderName, string extension)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hostingEnvironment.WebRootPath))
                {
                    hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }
                var webRoot = hostingEnvironment.WebRootPath;


                if (!Directory.Exists(webRoot + $"/{folderName}"))
                {
                    Directory.CreateDirectory(webRoot + $"/{folderName}");
                }
                List<string> imageNames = new List<string>();

                Random random = new Random();

                string imageName = random.Next(111111, 9999999).ToString() + "." + extension;

                var file = Path.Combine(webRoot + "/" + folderName, imageName);


                byte[] imageBytes = Convert.FromBase64String(base64);

                await File.WriteAllBytesAsync(file, imageBytes);

                return "/" + folderName + "/" + imageName;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<string> GenrateOtp()
        {
            try
            {
                int OTPLength = Convert.ToInt32(configuration.GetValue<string>("Otp:Length"));
                string sOTP = String.Empty;

                string sTempChars = String.Empty;

                Random rand = new Random();

                string[] saAllowedCharacters = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                for (int i = 0; i < OTPLength; i++)

                {

                    int p = rand.Next(0, saAllowedCharacters.Length);

                    sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                    sOTP += sTempChars;

                }
                return sOTP;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
