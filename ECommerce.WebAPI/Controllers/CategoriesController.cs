using ECommerce.Domain.Interfaces;
using ECommerce.Models;

namespace ECommerce.WebAPI.Controllers
{
    public class CategoriesController : GenericController<Category>
    {
        public CategoriesController(IGenericUnitOfWork<Category> unit) : base(unit)
        {
        }
    }
}
