using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data.Models.DTOs
{
    public class UploadImageDto
    {
        [Required]
        public IFormFile UploadedImage { get; set; }
    }
}
