using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data.Models.DTOs
{
    public class ProjectDTO
    {
        [Required]
        [MaxLength(100,ErrorMessage ="Max length should be 100")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
