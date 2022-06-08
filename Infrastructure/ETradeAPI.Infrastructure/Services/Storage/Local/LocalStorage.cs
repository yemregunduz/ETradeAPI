using ETradeAPI.Application.Services.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace ETradeAPI.Infrastructure.Services.Storage.Local
{
    public class LocalStorage: Storage, ILocalStorage
    {
        private readonly IWebHostEnvironment _webhostEnvironment;
        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webhostEnvironment = webHostEnvironment;
        }
        public async Task DeleteAsync(string path, string fileName) => File.Delete($"{path}\\{fileName}");

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f=>f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
        {
            var result = File.Exists($"{path}\\{fileName}");
            if (result)
            {
                return true;
            }
            return false;
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webhostEnvironment.WebRootPath, path);
            CheckDirectoryExists(uploadPath);
            List<(string fileName, string path)> datas = new();
            foreach (IFormFile file in files)
            {
                string newFileName = await FileRenameAsync(path, file.Name, HasFile);

                await CopyFileAsync($"{uploadPath}\\{newFileName}", file);
                datas.Add((newFileName, $"{path}\\{newFileName}"));
            }
            //todo return value 
            return datas;
        }
        private static async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log!
                throw ex;
            }

        }
        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
