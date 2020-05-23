using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Common.Service.Core;
using eshop.Persistence.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UploadController : ControllerBase
    {
        private readonly IUploadFileService _uploadFileService;

        public UploadController(IUploadFileService uploadFileService)
        {
            _uploadFileService = uploadFileService;
        }


        [HttpPost]
        public IActionResult Upload([FromForm] FileDto fileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   

            if (fileDto.File != null && fileDto.FolderPath != null)
            {                
                return Ok(new { dbPath = _uploadFileService.UploadFile(fileDto.File, fileDto.FolderPath) });
            }

            return BadRequest();
        }


        [HttpDelete]
        public IActionResult Delete([FromBody]FileDto fileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (fileDto.FolderPath != null && fileDto.FileName != null)
            {
                return Ok(new { isDeletedFile = _uploadFileService.DeleteFile(fileDto.FolderPath, fileDto.FileName) });
            }

            return BadRequest();
        }
    }
}