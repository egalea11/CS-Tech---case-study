using caseStudy.Models;

namespace caseStudy.Controllers
{
    public class Item
    {
        private Product pr = new Product();
        private int quantity;

        public Item() { }

        public Item(Product product, int quantity)
        {
            this.pr = product;
            this.Quantity = quantity;
        }

        public Product Pr
        {
            get
            {
                return pr;
            }

            set
            {
                pr = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }
    }
}