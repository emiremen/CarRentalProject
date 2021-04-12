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

        public static string[] Update(IFormFile[] files, string[] existingFilePath)
        {
            string[] replacedFiles = new string[files.Length]; ;
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
                        File.Delete(existingFilePath[i]);
                        files[i].CopyTo(stream);
                        replacedFiles[i] = stream.Name;
                        stream.Flush();
                    }
                }
                return replacedFiles;
            }
            throw new Exception("Boş dosya gönderilemez.");
        }

        public static void Delete(string existingFilePath)
        {
            string directoryPath = Directory.GetCurrentDirectory() + @"\wwwroot\" + existingFilePath;
            using (FileStream stream = File.Create(directoryPath))
            {
                File.Delete(existingFilePath);
                stream.Flush();
            }
        }
    }
}

