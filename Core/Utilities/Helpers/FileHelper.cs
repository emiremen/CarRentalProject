using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var newPath = Directory.GetCurrentDirectory() + @"\wwwroot\Images\" + Guid.NewGuid().ToString("N") + extension;
            if (file != null)
            {
                using (FileStream stream = File.Create(newPath))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
                return newPath;
            }
            else
            {
                throw new Exception("Boş dosya gönderilemez.");
            }
        }
        public static string Update(IFormFile file, string existingFilePath)
        {
            string replacedFile;
            var extension = Path.GetExtension(file.FileName);
            var newPath = Directory.GetCurrentDirectory() + @"\wwwroot\Images\" + Guid.NewGuid().ToString("N") + extension;
            if (file != null)
            {
                using (FileStream stream = File.Create(newPath))
                {
                    File.Delete(existingFilePath);
                    file.CopyTo(stream);
                    replacedFile = stream.Name;
                    stream.Flush();
                }
                return replacedFile;
            }
            else
            {
                throw new Exception("Boş dosya gönderilemez.");
            }
        }
    }
}
