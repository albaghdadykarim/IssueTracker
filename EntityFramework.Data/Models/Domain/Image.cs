using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data.Models.Domain
{
    public class Image
    {
        public int Id { get; set; }
      
        public required string FileName { get; set; }

        public  string FilePath { get; set; }

        public required string ContentType { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
        public string? Description { get; set; }
        public required long Length { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
