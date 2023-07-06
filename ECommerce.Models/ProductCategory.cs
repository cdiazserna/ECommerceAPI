namespace ECommerce.Models
{
    public class ProductCategory : AuditBase
    {
        public Product Product { get; set; } = null!;

        public Category Category { get; set; } = null!;
    }
}