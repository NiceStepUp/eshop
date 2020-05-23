using eshop.Common.Service.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;

namespace eshopService.Core
{
    public class UploadFileService : IUploadFileService
    {
        readonly string _staticFilesFolderName = "StaticFiles";
        readonly string _imagesFolderName = "Images";

        public string UploadFile(IFormFile uploadedFile, string folderPath)
        {
            var folderName = Path.Combine(_staticFilesFolderName, _imagesFolderName, folderPath);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (uploadedFile.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(uploadedFile.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                Directory.CreateDirectory(folderName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    uploadedFile.CopyTo(stream);
                }

                return dbPath;
            }
            throw new Exception("File is not uploaded.");
        }


        /// <summary>
        /// Deletion of the file by its folder path and name
        /// </summary>
        /// <param name="folderPath">Path of folder</param>
        /// <param name="fileName">Name of file</param>
        /// <returns>Whether the file is deleted</returns>
        public bool DeleteFile(string folderPath, string fileName)
        {
            fileName = Path.GetFileName(fileName);
            var fullFileName = Path.Combine(_staticFilesFolderName, _imagesFolderName, folderPath, fileName);

            if (File.Exists(fullFileName))
            {
                File.Delete(fullFileName);
                return true;
            }

            return false;
        }
    }
}
