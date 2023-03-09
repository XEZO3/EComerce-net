using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.filters
{
    public class ProductFilter
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        
        public int? CategoryId { get; set; }
        public int? BrandsId { get; set; }
        public string? Avilability { get; set; }
    }
}
