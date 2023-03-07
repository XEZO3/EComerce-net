using DocumentFormat.OpenXml.Spreadsheet;
using Domain.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Products : Main    
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Brands")]
        public int BrandsId { get; set; }      
        public string Avilability { get; set; }
        [NotMapped]
        public string Name { get { return GetCurrentLanguages.GetCurrentLang() == "ar" ? NameAr : NameEn; } }
        [NotMapped]
        public string Description { get { return GetCurrentLanguages.GetCurrentLang() == "ar" ? DescriptionAr : DescriptionEn; } }
        public Brands? brands { get; set; }
        public Category? Category { get; set; }
    }
}
