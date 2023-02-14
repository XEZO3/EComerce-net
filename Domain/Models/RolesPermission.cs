using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RolesPermission:Main
    {
        [ForeignKey("Roles")]
        public int RolesId { get; set; }
        [ForeignKey("Permessions")]
        public int PermessionsId { get; set; }
        public Roles roles { get; set; }
        
        public Permessions permessions { get; set; }
    }
}
