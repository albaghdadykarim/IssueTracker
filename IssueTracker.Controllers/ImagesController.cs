using EntityFramework.Data.Models.Domain;
using EntityFramework.Data.Models.DTOs;
using IssueTrackerRepo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController :ControllerBase
    {
        private readonly IImageUploaderRepo1 _imageUploaderRepo1;
        public ImagesController(IImageUploaderRepo1 imageUploaderRepo1)
        {
            _imageUploaderRepo1 = imageUploaderRepo1;
        }

        [HttpPost("UploadImage")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageDto uploadedImage)
        {
            if (uploadedImage.UploadedImage == null || uploadedImage.UploadedImage.Length == 0)
            {
                return BadRequest("No image file provided.");
            }

            var result = await _imageUploaderRepo1.UploadImageAsync(uploadedImage.UploadedImage);
            return Ok(result);
        }
        
    }
}
