using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Models.DataLayer;

public partial class User
{
    [Key]
    [Column("id")]
    public int? _id { get; set; }

    [Column("username")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Username { get; set; }

    [Column("fullname")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Fullname { get; set; }

    [Column("password")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Password { get; set; }

    [Column("imgUrl")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ImgUrl { get; set; }

    [Column("userMsg")]
    public int? UserMsg { get; set; }

    [Column("hostMsg")]
    public int? HostMsg { get; set; }


    [ForeignKey("UserId")]
    [InverseProperty("Users")]
    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();
}
