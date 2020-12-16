using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreWebAPI.Infrastructure.Models
{
    public class StudentCreateViewModel
    {
        public int StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        [Required]
        [RegularExpression(@"^([0-9])*$", ErrorMessage = "Invalid Phone Number")]        
        public string PhoneNumber { get; set; }
    }
}
