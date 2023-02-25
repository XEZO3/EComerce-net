using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderItem:Main
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Products")]
        public int ProductsId { get; set; }
        public int Quantity { get; set; }
        public Products products { get; set; }
        public Order Order { get; set; }
    }
}
