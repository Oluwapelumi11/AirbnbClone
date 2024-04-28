using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Models.DataLayer;

public partial class AirbnbContext : DbContext
{
    public AirbnbContext()
    {
    }

    public AirbnbContext(DbContextOptions<AirbnbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Host> Hosts { get; set; }

    public virtual DbSet<Listing> Listings { get; set; }

    public virtual DbSet<ListingAmenity> ListingAmenities { get; set; }

    public virtual DbSet<ListingFilter> ListingFilters { get; set; }

    public virtual DbSet<ListingImgUrl> ListingImgUrls { get; set; }

    public virtual DbSet<ListingLabel> ListingLabels { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Order> Orders { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-29GRVC2\\SQLSERVERNEW;Database=AirbnbCloneDb;User Id=sa;Password=mad,man$;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Host>(entity =>
        {
            entity.HasKey(e => e.HostId).HasName("PK__Host__A397C7AEE232B358");
        });

        modelBuilder.Entity<Listing>(entity =>
        {
            entity.HasKey(e => e.ListingId).HasName("PK__Listing__89D817742A5ED1B7");

            entity.HasOne(d => d.Host).WithMany(p => p.Listings).HasConstraintName("FK__Listing__host_id__44FF419A");

            entity.HasOne(d => d.Location).WithMany(p => p.Listings).HasConstraintName("FK__Listing__locatio__45F365D3");

            entity.HasMany(d => d.Users).WithMany(p => p.Listings)
                .UsingEntity<Dictionary<string, object>>(
                    "ListingLikedByUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ListingLi__user___59FA5E80"),
                    l => l.HasOne<Listing>().WithMany()
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ListingLi__listi__59063A47"),
                    j =>
                    {
                        j.HasKey("ListingId", "UserId").HasName("PK__ListingL__6243F404862A6FE6");
                        j.ToTable("ListingLikedByUsers");
                        j.IndexerProperty<int>("ListingId").HasColumnName("listing_id");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                    });
        });

        modelBuilder.Entity<ListingAmenity>(entity =>
        {
            entity.HasKey(e => new { e.ListingId, e.Amenity }).HasName("PK__ListingA__F2B0D0F1CF9269A4");

            entity.HasOne(d => d.Listing).WithMany(p => p.ListingAmenities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ListingAm__listi__534D60F1");
        });

        modelBuilder.Entity<ListingFilter>(entity =>
        {
            entity.HasKey(e => e.ListingId).HasName("PK__ListingF__89D81774CF6A2297");

            entity.Property(e => e.ListingId).ValueGeneratedNever();

            entity.HasOne(d => d.Host).WithMany(p => p.ListingFilters).HasConstraintName("FK__ListingFi__host___49C3F6B7");

            entity.HasOne(d => d.Listing).WithOne(p => p.ListingFilter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ListingFi__listi__48CFD27E");
        });

        modelBuilder.Entity<ListingImgUrl>(entity =>
        {
            entity.HasKey(e => new { e.ListingId, e.ImgUrl }).HasName("PK__ListingI__AF217F5416DBF50A");

            entity.HasOne(d => d.Listing).WithMany(p => p.ListingImgUrls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ListingIm__listi__5070F446");
        });

        modelBuilder.Entity<ListingLabel>(entity =>
        {
            entity.HasKey(e => new { e.ListingId, e.Label }).HasName("PK__ListingL__AD5A28AFBE899D07");

            entity.HasOne(d => d.Listing).WithMany(p => p.ListingLabels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ListingLa__listi__5629CD9C");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__771831EAB1B20E67");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__60883D90C73E7D5E");

            entity.HasOne(d => d.Listing).WithMany(p => p.Reviews).HasConstraintName("FK__Review__listing___4CA06362");

            //entity.HasOne(d => d.Reviewer).WithMany(p => p.Reviews).HasConstraintName("FK__Review__reviewer__4D94879B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e._id).HasName("PK__Users__3213E83FC7291D1E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
