
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
    public class FileService
    {
     

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

    }

}
