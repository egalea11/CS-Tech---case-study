namespace caseStudy.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

        [Required]
        public string Details { get; set; }

        public string ImageLocation { get; set; }

        public virtual Category Category { get; set; }
        
    }
}
