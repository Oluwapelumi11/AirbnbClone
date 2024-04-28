namespace AirbnbClone.Models.DTOs
{
    public class ReviewDto
    {
        public long? At { get; set; }

        public string? txt { get; set;}

        public By? By { get; set; }
        
    }


    public class By
    {
        public int? _id { get; set; }
        public string? fullname { get; set; }
        public string? imgUrl { get; set; }
    }
}
