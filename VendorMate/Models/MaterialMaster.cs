namespace VendorMate.Models;


using System.ComponentModel.DataAnnotations;
public class MaterialMaster
{
    [Key]
    public long ID { get; set; }

    [Required]
    [StringLength(5)]
    public required string Code { get; set; }

    [Required]
    [StringLength(150)]
    public required string ShortText { get; set; }

    public string LongText { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public required string Unit { get; set; }

    [Required]
    public int ReorderLevel { get; set; }

    [Required]
    public int MinOrderQuantity { get; set; }

    [Required]
    public bool IsActive { get; set; }
}