using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class CustomerDto
    {
        public int UsersId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
