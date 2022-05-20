using ETradeAPI.Application.Services;
using ETradeAPI.Infrastructure.StaticHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webhostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webhostEnvironment = webHostEnvironment;
        }
        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine( _webhostEnvironment.WebRootPath,path);
            CheckDirectoryExists(uploadPath);
            List<(string fileName, string path)> datas = new();
            List<bool> results = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(uploadPath,file.FileName);
                bool result = await CopyFileAsync(Path.Combine(uploadPath, fileNewName), file);
                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
                results.Add(result);
            }
            if (results.TrueForAll(r=>r.Equals(true)))
            {
                return datas;
            }
            //todo return value 
            return null;
        }
        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static async Task<string> FileRenameAsync(string path, string fileName, bool first = true)
        {
            string newFileName = await Task.Run<string>(async () =>
            {
                string extension = Path.GetExtension(fileName);
                string newFileName = string.Empty;
                if (first)
                {
                    string oldName = Path.GetFileNameWithoutExtension(fileName);
                    newFileName = $"{FileNameHelper.CharacterRegulatory(oldName)}{extension}";
                }
                else
                {
                    newFileName = fileName;
                    int hyphenIndex = newFileName.IndexOf("-");
                    if (hyphenIndex == -1)
                        newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
                    else
                    {
                        int lastIndex = 0;
                        while (true)
                        {
                            lastIndex = hyphenIndex;
                            hyphenIndex = newFileName.IndexOf("-", hyphenIndex + 1);
                            if (hyphenIndex == -1)
                            {
                                hyphenIndex = lastIndex;
                                break;
                            }
                        }

                        int dotIndex = newFileName.IndexOf(".");
                        string fileNo = newFileName.Substring(hyphenIndex + 1, dotIndex - hyphenIndex - 1);

                        if (int.TryParse(fileNo, out int _fileNo))
                        {
                            _fileNo++;
                            newFileName = newFileName.Remove(hyphenIndex + 1, dotIndex - hyphenIndex - 1)
                                                .Insert(hyphenIndex + 1, _fileNo.ToString());
                        }
                        else
                            newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";

                    }
                }

                if (File.Exists($"{path}\\{newFileName}"))
                    return await FileRenameAsync(path, newFileName, false);
                else
                    return newFileName;
            });

            return newFileName;
        }
        private static async Task<bool> CopyFileAsync(string path,IFormFile file)
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
    }

}
