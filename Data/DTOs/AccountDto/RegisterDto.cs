using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs.AccountDto
{
    public class RegisterDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Surname { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
