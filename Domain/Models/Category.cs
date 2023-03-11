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
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
        [NotMapped]
        public string? Name { get { return GetCurrentLanguages.GetCurrentLang() == "ar" ? NameAr : NameEn; } }
        [NotMapped]
        public string? Description { get { return GetCurrentLanguages.GetCurrentLang() == "ar" ? DescriptionAr : DescriptionEn; } }
    }
}
