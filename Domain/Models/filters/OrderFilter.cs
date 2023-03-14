using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.filters
{
    public class OrderFilter
    {
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? OrderState { get; set; }
        public string? CustomerNote { get; set; }
        [Range(0, 5)]
        public int? Rate { get; set; }
        public decimal? Total { get; set; }
    }
}
