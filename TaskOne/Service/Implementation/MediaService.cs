using Microsoft.AspNetCore.Hosting;
using TaskOne.Service.Abstract;

namespace TaskOne.Service.Implementation
{
    public class MediaService : IMediaService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MediaService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public bool DeletePhysicalFile(string name)
        {
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + "/assets/");
            if (File.Exists(directoryPath))
            {
                File.Delete(directoryPath);
                return true;
            }
            return false;
        }

        public async Task<string> Upload(IFormFile file)
        {
            string location = "/assets/";
            try
            {
                var path = _webHostEnvironment.WebRootPath + location;    //wwwroot+images
                var extension = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + extension;
                //Save
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (FileStream fileStream = File.Create(path + fileName))
                {
                    await file.CopyToAsync(fileStream);
                    fileStream.Flush();
                    return $"{location}/{fileName}";
                }
            }
            catch
            {
                return "Problem";
            }
        }


    }
}
