using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Models.DataLayer;

[Table("Host")]
public partial class Host
{
    [Key]
    [Column("host_id")]
    public int HostId { get; set; }

    [Column("fullname")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Fullname { get; set; }

    [Column("pictureUrl")]
    [StringLength(255)]
    [Unicode(false)]
    public string? PictureUrl { get; set; }

    [Column("createAt")]
    public long? CreateAt { get; set; }

    [Column("isSuperhost")]
    public bool? IsSuperhost { get; set; }

    [Column("policyNumber")]
    public int? PolicyNumber { get; set; }

    [Column("responseTime")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ResponseTime { get; set; }

    [InverseProperty("Host")]
    public virtual ICollection<ListingFilter> ListingFilters { get; set; } = new List<ListingFilter>();

    [InverseProperty("Host")]
    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();
}
