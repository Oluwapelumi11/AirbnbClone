using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;

namespace AirbnbClone.Services
{
    public class ListingService: IListable
    {
        private AirbnbContext _context;

        public ListingService(AirbnbContext context)
        {
            _context = context;
        }

        Task<Listing> IListable.Create(Listing listing)
        {
            throw new NotImplementedException();
        }

        Task<Listing> IListable.Delete(Listing listing)
        {
            throw new NotImplementedException();
        }

        Task<List<Listing>> IListable.Get()
        {
            throw new NotImplementedException();
        }

        Task<Listing> IListable.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<Listing> IListable.Update(Listing listing)
        {
            throw new NotImplementedException();
        }
    }

}
