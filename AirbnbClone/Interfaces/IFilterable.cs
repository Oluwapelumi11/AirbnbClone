using AirbnbClone.Models.DataLayer;

namespace AirbnbClone.Interfaces
{
    public interface IFilterable
    {
        Task<List<Listing>> FilterBy(ListingFilter column);
    }
}
