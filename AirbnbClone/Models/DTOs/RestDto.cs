namespace AirbnbClone.Models.DTOs
{
    public class RestDto<T>
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();

        public T Data { get; set; } = default!;

        public int? RecordCount { get; set; } = default!;
    }
}
