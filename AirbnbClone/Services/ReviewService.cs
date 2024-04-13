using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;

namespace AirbnbClone.Services
{
    public class ReviewService :IReviewable
    {
        private AirbnbContext _context;

        public ReviewService(AirbnbContext context)
        {
            _context = context;
        }

        Task<Listing?> IReviewable.Add(Listing listing, Review review)
        {
            throw new NotImplementedException();
        }

        Task<Listing?> IReviewable.Delete(Review review)
        {
            throw new NotImplementedException();
        }

        Task<List<Review>?> IReviewable.Get(Listing listing)
        {
            throw new NotImplementedException();
        }

        Task<List<Review>?> IReviewable.Get(Listing listing, int count)
        {
            throw new NotImplementedException();
        }

        Task<Review> IReviewable.Update(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
