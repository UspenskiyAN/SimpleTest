using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTest.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.##}")]
        [Range(0.01, float.MaxValue)]
        public float Salary { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        public static UserViewModel FromUser(User User)
        {
            return new UserViewModel { 
                Birthday = User.Birthday, 
                Email = User.Email, 
                Id = User.Id,
                Salary = User.Salary,
                UserName = User.UserName };
        }
    }
}
