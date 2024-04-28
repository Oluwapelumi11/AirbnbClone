using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Models.DataLayer;

[Table("Location")]
public partial class Location
{
    [Key]
    [Column("location_id")]
    public int LocationId { get; set; }

    [Column("country")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Country { get; set; }

    [Column("countryCode")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CountryCode { get; set; }

    [Column("city")]
    [StringLength(100)]
    [Unicode(false)]
    public string? City { get; set; }

    [Column("address")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Address { get; set; }

    [Column("lat", TypeName = "decimal(9, 6)")]
    public decimal? Lat { get; set; }

    [Column("lan", TypeName = "decimal(9, 6)")]
    public decimal? Lan { get; set; }

    [InverseProperty("Location")]
    [JsonIgnore]
    public virtual ICollection<Listing?>? Listings { get; set; }
}
