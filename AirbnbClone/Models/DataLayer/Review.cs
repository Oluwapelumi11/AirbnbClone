using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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

    [Column("reviewerName")]
    public string? Fullname { get; set; }


    [Column("rimgUrl")]
    public string? UserImg { get; set; }

    [ForeignKey("ListingId")]
    [InverseProperty("Reviews")]
    [JsonIgnore]
    public virtual Listing? Listing { get; set; }


}
