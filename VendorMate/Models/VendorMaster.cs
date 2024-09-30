namespace VendorMate.Models;

using System;
using System.ComponentModel.DataAnnotations;

public class VendorMaster
{
    [Key]
    public long ID { get; set; }

    [Required]
    [StringLength(5)]
    public required string Code { get; set; }

    [Required]
    [StringLength(150)]
    public required string Name { get; set; }

    [StringLength(255)]
    public required string AddressLine1 { get; set; }

    [StringLength(255)]
    public required string AddressLine2 { get; set; }

    [Required]
    [StringLength(150)]
    public required string ContactEmail { get; set; }

    [Required]
    [StringLength(10)]
    public required string ContactNo { get; set; }

    [Required]
    public DateTime ValidTillDate { get; set; }

    [Required]
    public bool IsActive { get; set; }
}