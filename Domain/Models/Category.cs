using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.common;
namespace Domain.Models
{
    public class Category:Main
    {
        
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        [NotMapped]
        public string Name { get { return GetCurrentLanguages.GetCurrentLang() == "ar" ? NameAr : NameEn; } }
    }
}
