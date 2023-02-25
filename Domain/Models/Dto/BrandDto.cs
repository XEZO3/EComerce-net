using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class BrandDto
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public string Image { get; set; }
        public bool IsAvailable { get; set; }
    }
}
