namespace AirbnbClone.Models.DTOs
{
    public class OrderDto
    {
        public int? _id { get; set; }
        public Buyer? buyer { get; set; }
        public decimal? totalPrice { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }

        public Guest? guests { get; set; }

        public Sta? stay { get; set; }

        public Hos? host { get; set; }

        public string? status { get; set; }

    }




    public class Buyer
    {
        public int? _id { get; set; }
        public string? fullname { get; set; }
    }

    public class Sta
    {
        public int? _id { get; set; }
        public string? name { get; set; }

        public decimal? price { get; set; }
    }

    public class Hos
    {
        public int? _id { get; set; }
        public string? fullname { get; set; }

    }

    public class Guest
    {
        public int? Adults { get; set; }
        public int? Children { get; set; }
        public int? Infants { get; set; }
        public int? Pets { get; set; }
    }

}
