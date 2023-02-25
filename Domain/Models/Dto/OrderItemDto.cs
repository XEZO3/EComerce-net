using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class OrderItemDto
    {
        
        public int OrderId { get; set; }
        
        public int ProductsId { get; set; }
        public int Quantity { get; set; }
       
    }
}
