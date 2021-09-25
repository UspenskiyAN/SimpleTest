using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SimpleTest.Models
{
    public class User : IdentityUser<int>
    {
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.##}")]
        [Range(0.01, float.MaxValue)]
        public float Salary { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
