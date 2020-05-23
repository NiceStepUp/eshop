using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Persistence.Core.Dtos
{
    public class FileDto
    {
        public IFormFile File { get; set; }

        public string FolderPath { get; set; }

        public string FileName { get; set; }
    }
}
