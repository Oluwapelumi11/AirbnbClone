using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Models.DataLayer;

[PrimaryKey("ListingId", "ImgUrl")]
public partial class ListingImgUrl
{
    [Key]
    [Column("listing_id")]
    public int ListingId { get; set; }

    [Key]
    [Column("imgUrl")]
    [StringLength(255)]
    [Unicode(false)]
    public string ImgUrl { get; set; } = null!;

    [ForeignKey("ListingId")]
    [InverseProperty("ListingImgUrls")]
    public virtual Listing Listing { get; set; } = null!;
}
