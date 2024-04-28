using System.ComponentModel.DataAnnotations;

namespace AirbnbClone.Models.DataLayer
{
    public class Order
    {
        [Key]
        public int? _id { get; set; }

        public int? BuyerId { get; set; }
        public string? BuyerName { get; set; }

        public decimal? TotalPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int? GuestAdult { get; set; } 
        public int? Guestchildren { get; set; } 
        public int? Guestinfant { get; set; } 
        public int? Guestpets { get; set; } 

        public int? StayId { get; set; }
        public string? StayName { get; set; }
        public decimal? price  { get; set; }

        public int? HostId { get; set; }
        public string? HostName { get; set; }

        public string? Status { get; set; }
    }

}
