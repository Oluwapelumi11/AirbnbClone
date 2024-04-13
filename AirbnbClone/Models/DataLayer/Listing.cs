using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Models.DataLayer;

[Table("Listing")]
public partial class Listing
{
    [Key]
    [Column("listing_id")]
    public int ListingId { get; set; }

    [Column("type")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Type { get; set; }

    [Column("name")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("price", TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }

    [Column("summary")]
    [Unicode(false)]
    public string? Summary { get; set; }

    [Column("capacity")]
    public int? Capacity { get; set; }

    [Column("roomType")]
    [StringLength(100)]
    [Unicode(false)]
    public string? RoomType { get; set; }

    [Column("bathrooms")]
    public int? Bathrooms { get; set; }

    [Column("bedrooms")]
    public int? Bedrooms { get; set; }

    [Column("host_id")]
    public int? HostId { get; set; }

    [Column("location_id")]
    public int? LocationId { get; set; }

    [Column("statCleanliness", TypeName = "decimal(3, 2)")]
    public decimal? StatCleanliness { get; set; }

    [Column("statCommunication", TypeName = "decimal(3, 2)")]
    public decimal? StatCommunication { get; set; }

    [Column("statCheckIn", TypeName = "decimal(3, 2)")]
    public decimal? StatCheckIn { get; set; }

    [Column("statAccuracy", TypeName = "decimal(3, 2)")]
    public decimal? StatAccuracy { get; set; }

    [Column("statLocation", TypeName = "decimal(3, 2)")]
    public decimal? StatLocation { get; set; }

    [Column("statValue", TypeName = "decimal(3, 2)")]
    public decimal? StatValue { get; set; }

    [ForeignKey("HostId")]
    [InverseProperty("Listings")]
    public virtual Host? Host { get; set; }

    [InverseProperty("Listing")]
    public virtual ICollection<ListingAmenity> ListingAmenities { get; set; } = new List<ListingAmenity>();

    [InverseProperty("Listing")]
    public virtual ListingFilter? ListingFilter { get; set; }

    [InverseProperty("Listing")]
    public virtual ICollection<ListingImgUrl> ListingImgUrls { get; set; } = new List<ListingImgUrl>();

    [InverseProperty("Listing")]
    public virtual ICollection<ListingLabel> ListingLabels { get; set; } = new List<ListingLabel>();

    [ForeignKey("LocationId")]
    [InverseProperty("Listings")]
    public virtual Location? Location { get; set; }

    [InverseProperty("Listing")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("ListingId")]
    [InverseProperty("Listings")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
