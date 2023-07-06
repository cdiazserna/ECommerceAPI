using ECommerce.Helpers.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Sale : AuditBase
    {
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        [Display(Name = "Fecha/Hora")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Date { get; set; }

        public User? User { get; set; }

        //public string? UserId { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentarios pedido")]
        public string? Remarks { get; set; }

        [Display(Name = "Calificación")]
        public int Qualification { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentarios calificación")]
        public string? Comments { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public ICollection<SaleDetail>? SaleDetails { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "Líneas")]
        public int Lines => SaleDetails == null ? 0 : SaleDetails.Count;

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Display(Name = "Cantidad")]
        public float Quantity => SaleDetails == null ? 0 : SaleDetails.Sum(sd => sd.Quantity);

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Valor")]
        public decimal Value => SaleDetails == null ? 0 : SaleDetails.Sum(sd => sd.Value);
    }
}