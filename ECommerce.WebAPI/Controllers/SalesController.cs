using ECommerce.Domain.Interfaces;
using ECommerce.Models;

namespace ECommerce.WebAPI.Controllers
{
    public class SalesController : GenericController<Sale>
    {
        public SalesController(IGenericUnitOfWork<Sale> unit) : base(unit)
        {
        }
    }
}
