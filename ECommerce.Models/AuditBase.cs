using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class AuditBase
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}