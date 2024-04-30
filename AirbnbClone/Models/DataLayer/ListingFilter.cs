using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Models.DataLayer;

[Table("ListingFilter")]
public partial class ListingFilter
{
    [Key]
    [Column("listing_id")]
    public int? ListingId { get; set; }

    [Column("likeByUser")]
    public int? LikeByUser { get; set; }

    public int? page { get; set; } 

    [Column("place")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Place { get; set; }

    [Column("label")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Label { get; set; }

    [Column("host_id")]
    public int? HostId { get; set; }

    [Column("isPetAllowed")]
    public bool? IsPetAllowed { get; set; }


    [JsonIgnore]
    [ForeignKey("HostId")]
    [InverseProperty("ListingFilters")]
    public virtual Host? Host { get; set; }

    [JsonIgnore]
    [ForeignKey("ListingId")]
    [InverseProperty("ListingFilter")]
    public virtual Listing? Listing { get; set; } = null!;
}
