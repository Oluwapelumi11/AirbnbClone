using AirbnbClone.Models.DataLayer;

namespace AirbnbClone.Interfaces
{
    public interface IReviewable
    {
        Task<List<Review>?> Get(Listing listing);
        Task<List<Review>?> Get(Listing listing, int count);

        Task<Listing?> Add(Listing listing, Review review);

        Task<Listing?> Delete(Review review);

        Task<Review> Update(Review review);
    }
}
