using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ServiceRespone
{
    public class CategoryRespone:Main
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
    }
}
