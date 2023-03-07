using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.filters
{
    public class BrandFilter
    {

        public string? Name { get; set; }

       
        public bool? IsAvailable { get; set; }
    }
}
