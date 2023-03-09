using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class ProductDto
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public int CategoryId { get; set; }
        public int BrandsId { get; set; }
        public string Avilability { get; set; }

    }
}
