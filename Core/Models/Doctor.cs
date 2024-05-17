using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Models
{
    public class Doctor : BaseEntity
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; } = null!;
        [MinLength(4)]
        public string Position { get; set; } = null!;

        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }
    }
}
