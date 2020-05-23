using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Common.Service.Core
{
    public interface IUploadFileService
    {
        string UploadFile(IFormFile file, string relativePath);

        bool DeleteFile(string folderPath, string fileName);
    }
}
