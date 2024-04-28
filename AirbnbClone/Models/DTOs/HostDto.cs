namespace AirbnbClone.Models.DTOs
{
    public class HostDto
    {
            public long? CreateAt { get; set; }
            public string? Fullname { get; set; }
            public string? Location { get; set; }
            public string? About { get; set; }
            public string? ResponseTime { get; set; }
            public string? ThumbnailUrl { get; set; }
            public string? PictureUrl { get; set; }
            public bool? IsSuperhost { get; set; }
            public int? PolicyNumber { get; set; }
    }
}
