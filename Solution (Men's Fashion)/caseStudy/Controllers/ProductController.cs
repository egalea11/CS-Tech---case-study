using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using caseStudy.Models;
using caseStudy.ViewModels;

namespace caseStudy.Controllers
{
    public class ProductController : Controller
    {
        private ProductEntities pe = new ProductEntities();


        public ActionResult ShowProducts()
        {
            ViewBag.listProducts = pe.Products.ToList();
            return View();
        }

        public ActionResult ProductByCatId(int catId)
        {
                return View("Product", new CategoryProducts()
                {
                    Category = pe.Categories.FirstOrDefault(e => e.CategoryId == catId),
                    Products = pe.Products.Where(x => x.CategoryId == catId).ToList()
                }
            );
        }

        public PartialViewResult RenderSpecials()
        {
            List<Product> specs = pe.Products.Take(3).ToList();
            return PartialView("_Specials", specs);
        }

        public PartialViewResult RenderFeatured()
        {
            List<Product> featured = pe.Products.OrderByDescending(x => x.Price).Take(4).ToList();
            return PartialView("_Featured", featured);
        }

        public ActionResult ProductsBySearch(string search)
        {
            // if search is not empty, search for products with search string in their name
            if(search != "")
            {
                return View("Product", new CategoryProducts()
                    {
                        Category = pe.Categories.FirstOrDefault(),
                        Products = pe.Products.Where(x => x.Name.ToString().ToUpper().Contains(search.ToUpper())).ToList()
                    }
                );
            }
            // else show all products available
            else
            {
                return RedirectToAction("ShowProducts");
            }
        }
    }
}