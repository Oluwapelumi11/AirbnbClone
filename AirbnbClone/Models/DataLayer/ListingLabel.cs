using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Models.DataLayer;

[PrimaryKey("ListingId", "Label")]
public partial class ListingLabel
{
    [Key]
    [Column("listing_id")]
    public int ListingId { get; set; }

    [Key]
    [Column("label")]
    [StringLength(100)]
    [Unicode(false)]
    public string Label { get; set; } = null!;

    [ForeignKey("ListingId")]
    [InverseProperty("ListingLabels")]
    public virtual Listing Listing { get; set; } = null!;
}
