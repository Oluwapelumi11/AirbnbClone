using AirbnbClone.Models.DataLayer;

namespace AirbnbClone.Interfaces
{
    public interface IListable
    {
        Task<Listing> Create(Listing listing);
        Task<Listing> Update(Listing listing);
        Task<Listing> Delete(Listing listing);
        Task<List<Listing>> Get();
        Task<Listing> Get(int id);
    }
}
