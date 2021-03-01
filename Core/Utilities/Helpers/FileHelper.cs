using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        //First Value is File Name
        //Second Value is File New Path
        public static string GetPathandName(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string newFileName = Guid.NewGuid().ToString() + fileInfo.Extension;
            //string targetPath = $@"{Environment.CurrentDirectory}\demo\{newFileName}";
            string path = $@"{Environment.CurrentDirectory}\root\uploads";
            string targetPath = $@"{Environment.CurrentDirectory}\root\uploads\{newFileName}";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return targetPath;
        }

        public static string DefaultPath()
        {
            return $@"{Environment.CurrentDirectory}\root\uploads\default.jpg";
        }

        public static string Add(IFormFile file)
        {

            if (file != null && file.Length > 0)
            {
                var targetPath = GetPathandName(file);
                var sourcePath = Path.GetTempFileName();
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                File.Move(sourcePath, targetPath);

                return targetPath;
            }
            else
            {
                return DefaultPath();
            }
        }

        public static bool Delete(string path)
        {
            File.Delete(path);
            if (File.Exists(path))
            {
                return false;
            }
            return true;
        }

        public static string Update(IFormFile file, string path)
        {
            var isDeleted = Delete(path);
            var newPath = Add(file);
            return newPath;
        }
    }
}

