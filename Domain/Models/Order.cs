using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order:Main
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        [Column("OrderStatus")]
        
        public string OrderState {get; set; }
        public string CustomerNote { get; set; }
        public List<OrderItem> Items { get; set; }
        [Range(0, 5)]
        public int Rate { get; set; }
        public decimal Total { get; set; }
        public Order()
        {
            Items = new List<OrderItem>();
        }
        //public DateTime OrderDate { get; set; }
    }
}
