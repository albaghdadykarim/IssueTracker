using EntityFramework.Data.Models.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTrackerRepo
{
    public interface IImageUploaderRepo1
    {
        public Task<Image> UploadImageAsync(IFormFile uploadedImage);
        
    }
}
