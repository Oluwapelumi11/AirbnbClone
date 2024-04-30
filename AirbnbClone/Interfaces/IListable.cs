using AirbnbClone.Models.DataLayer;
using AirbnbClone.Models.DTOs;

namespace AirbnbClone.Interfaces
{
    public interface IListable
    {
        Task<List<CreateListingDto>> Filter(ListingFilter filter);

        Task<Listing> Create(CreateListingDto listing);
        Task<Listing?> Update(CreateListingDto listing);
        Task<Listing?> Delete(int id);
        Task<List<CreateListingDto>> Get();
        Task<CreateListingDto?> Get(int id);
        Task<List<CreateListingDto?>?> Get(string user);
    }
}
