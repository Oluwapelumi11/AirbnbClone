using AirbnbClone.Models.DataLayer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AirbnbClone.Models.DTOs
{
    public class CreateListingDto
    {
        public int? _id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public List<string?>? ImgUrls { get; set; }
        public decimal? Price { get; set; }
        public string? Summary { get; set; }
        public int? Capacity { get; set; }
        public List<string>? Amenities { get; set; }
        public int? Bathrooms { get; set; }
        public int? Bedrooms { get; set; }
        public string? RoomType { get; set; }
        public HostDto? Host { get; set; }
        public LocationDTO? Loc { get; set; }
        public List<ReviewDto?>? Reviews { get; set; }
        public List<string?>? LikedByUsers { get; set; }
        public List<string>? Labels { get; set; }
        public StatReviewsDTO? StatReviews { get; set; }

    }
}
