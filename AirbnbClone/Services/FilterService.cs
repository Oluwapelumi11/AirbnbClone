using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;

namespace AirbnbClone.Services
{
    public class FilterService : IFilterable
    {
        private AirbnbContext _context;

        public FilterService(AirbnbContext context)
        {
            _context = context;
        }

        Task<List<Listing>> IFilterable.FilterBy(ListingFilter column)
        {
            throw new NotImplementedException();
        }
    }
}
