using ECommerce.Domain.Interfaces;
using ECommerce.Models;

namespace ECommerce.WebAPI.Controllers
{
    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IGenericUnitOfWork<Product> unit) : base(unit)
        {
        }
    }
}
