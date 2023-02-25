using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Customer:Main
    {
        [ForeignKey("Users")]
        public int UsersId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Users User { get; set; }
    }
}
