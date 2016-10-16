using caseStudy.Models;
using System.Collections.Generic;

namespace caseStudy.ViewModels
{
    public class CategoryProducts
    {
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}