using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Models.DataLayer;

[PrimaryKey("ListingId", "Amenity")]
public partial class ListingAmenity
{
    [Key]
    [Column("listing_id")]
    public int ListingId { get; set; }

    [Key]
    [Column("amenity")]
    [StringLength(100)]
    [Unicode(false)]
    public string Amenity { get; set; } = null!;

    [ForeignKey("ListingId")]
    [InverseProperty("ListingAmenities")]
    [JsonIgnore]
    public virtual Listing Listing { get; set; } = null!;
}
