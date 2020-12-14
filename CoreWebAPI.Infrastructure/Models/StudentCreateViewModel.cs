using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWebAPI.Infrastructure.Models
{
    public class StudentCreateViewModel
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}
