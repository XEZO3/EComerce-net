using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int roleId { get; set; }
        public CustomerDto customer { get; set; }
        public RegisterDto()
        {
            this.customer = new CustomerDto();
        }
       }
}
