using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static string[] Add(IFormFile[] files)
        {
            string[] dbPath = new string[files.Length];
            if (files.Length > 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    string extension = Path.GetExtension(files[i].FileName);
                    dbPath[i] = @"Images/" + Guid.NewGuid().ToString("N") + extension;
                    string directoryPath = Directory.GetCurrentDirectory() + @"\wwwroot\" + dbPath[i];
                    using (FileStream stream = File.Create(directoryPath))
                    {
                        files[i].CopyTo(stream);
                        stream.Flush();
                    }
                }
                return dbPath;
            }
            throw new Exception("Boş dosya gönderilemez.");
        }

        public static string Update(IFormFile file, string existingFilePath)
        {
            string replacedFile;
            string extension = Path.GetExtension(file.FileName);
            string dbPath = @"Images/" + Guid.NewGuid().ToString("N") + extension;
            string directoryPath = Directory.GetCurrentDirectory() + @"\wwwroot\" + dbPath;
            if (file != null)
            {
                using (FileStream stream = File.Create(directoryPath))
                {
                    File.Delete(existingFilePath);
                    file.CopyTo(stream);
                    replacedFile = stream.Name;
                    stream.Flush();
                }
                return replacedFile;
            }
            throw new Exception("Boş dosya gönderilemez.");
        }
    }
}

