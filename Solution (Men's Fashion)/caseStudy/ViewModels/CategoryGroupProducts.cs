using caseStudy.Models;
using System.Collections.Generic;

namespace caseStudy.ViewModels
{
    public class CategoryGroupProducts : BaseViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }




        //public string pName { get; set; }
        //public double pPrice { get; set; }
        //public string pDetails { get; set; }
        //public string pImageLocation { get; set; }

        //public string pCatGroup { get; set; }
        //public string pCategoryName { get; set; }


    }
}