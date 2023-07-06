using ECommerce.Domain.Interfaces;
using ECommerce.Models;

namespace ECommerce.WebAPI.Controllers
{
    public class TemporalSalesController : GenericController<TemporalSale>
    {
        public TemporalSalesController(IGenericUnitOfWork<TemporalSale> unit) : base(unit)
        {
        }
    }
}
