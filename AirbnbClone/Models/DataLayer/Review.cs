using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Models.DataLayer;

[Table("Review")]
public partial class Review
{
    [Key]
    [Column("review_id")]
    public int ReviewId { get; set; }

    [Column("listing_id")]
    public int? ListingId { get; set; }

    [Column("at")]
    public long? At { get; set; }

    [Column("txt")]
    [Unicode(false)]
    public string? Txt { get; set; }

    [Column("reviewer_id")]
    public int? ReviewerId { get; set; }

    [ForeignKey("ListingId")]
    [InverseProperty("Reviews")]
    public virtual Listing? Listing { get; set; }

    [ForeignKey("ReviewerId")]
    [InverseProperty("Reviews")]
    public virtual User? Reviewer { get; set; }
}
