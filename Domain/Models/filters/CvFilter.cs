using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.filters
{
    public class CvFilter
    {
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public string?  CityName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? CompanyName { get; set; }

        public string? CompanyField { get; set; }
//public string 
    }
}
