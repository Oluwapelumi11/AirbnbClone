using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Models.DataLayer;

public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("fullname")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Fullname { get; set; }

    [Column("password")]
    [StringLength(255)]
    [Unicode(false)]
    [JsonIgnore]
    public string? Password { get; set; }

    [Column("imgUrl")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ImgUrl { get; set; }

    [Column("userMsg")]
    public int? UserMsg { get; set; }

    [Column("hostMsg")]
    public int? HostMsg { get; set; }

    [InverseProperty("Reviewer")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("UserId")]
    [InverseProperty("Users")]
    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();
}
