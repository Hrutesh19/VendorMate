
using System.ComponentModel.DataAnnotations;

namespace VendorMate.Models
{
    public class PurchaseOrderDetails
    {
        public long ID { get; set; }

        [Required]
        public long OrderID { get; set; }

        [Required]
        public long MaterialID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int ItemQuantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Rate must be greater than zero.")]
        public decimal ItemRate { get; set; }

        [Display(Name = "Item Value")]
        public decimal ItemValue => ItemQuantity * ItemRate;



        [StringLength(500)]
        public required string ItemNotes { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpectedDate { get; set; }
    }
}
