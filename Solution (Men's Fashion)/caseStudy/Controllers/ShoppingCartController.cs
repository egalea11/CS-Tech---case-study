using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using caseStudy.Models;

namespace caseStudy.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ProductEntities pe = new ProductEntities();

        public ActionResult Index()
        {
            return View();
        }
        
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Pr.ProductId == id)
                    return i;
            }
            return -1;
        }

        [HttpGet]
        public ActionResult AddToCart(int id, int qty)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(pe.Products.Find(id), qty));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                    cart.Add(new Item(pe.Products.Find(id), qty));
                else
                    cart[index].Quantity += qty;
                Session["cart"] = cart;
            }

            return View("Cart");
        }

        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;

            return View("Cart");
        }


        [HttpGet]
        public ActionResult Cart()
        {
            ViewBag.ListProduct = this.pe.Products.ToList();
            return View("Cart");
        }

        public ActionResult RefreshCart()
        {
            return View("Cart");
        }

        [HttpPost]
        public ActionResult Cart(FormCollection fc)
        {
            List<int> toDeleteProductIds = fc.GetValues("productId").Select(e => int.Parse(e)).ToList();
            List<Item> cart = (List<Item>)Session["cart"];

            // get all items that their product id do not exist in ids list
            List<Item> notDeleted = cart.Where(
                        // check if productid exists in ids to be deleted
                        cartItem => toDeleteProductIds.FirstOrDefault(toDeleteId => toDeleteId == cartItem.Pr.ProductId) == default(int)
                    ).ToList();

            Session["cart"] = notDeleted;

            return View("Cart");
        }
    }
}