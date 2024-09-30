namespace VendorMate.Models;
using System.ComponentModel.DataAnnotations;

public class PurchaseOrderHeader
{
    [Key]
    public long ID { get; set; }

    [Required]
    public required string OrderNumber { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    public long VendorID { get; set; }

    public required string Notes { get; set; }

    public decimal OrderValue { get; set; }

    public required string OrderStatus { get; set; }
}