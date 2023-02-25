using Domain.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Brands :Main
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public string Image { get; set; }
        public bool IsAvailable { get; set; }
        [NotMapped]
        public string Name { get { return GetCurrentLanguages.GetCurrentLang() == "ar" ? NameAr : NameEn; } }
       
        
    }
}
