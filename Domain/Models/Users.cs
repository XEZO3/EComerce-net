using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Users:Main
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] salt { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; } 
        public Roles Roles { get; set; }
    }
}
