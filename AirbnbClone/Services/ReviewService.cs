using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.Services
{
    public class ReviewService : IReviewable
    {
        private AirbnbContext _context;

        public ReviewService(AirbnbContext context)
        {
            _context = context;
        }

        async Task<Listing?> IReviewable.Add(Listing listing, Review review)
        {
            var list = await _context.Listings.FindAsync(listing.ListingId);
            if (list is not null)
            {
                list.Reviews.Add(review);
                _context.Update(list);
                await _context.SaveChangesAsync();
            }
            return listing;
        }

        async Task<Listing?> IReviewable.Delete(Listing listing, Review review)
        {
            var list = await _context.Listings.FindAsync(listing.ListingId);
            if (list is not null)
            {
                list.Reviews.Remove(review);
                _context.Update(list);
                await _context.SaveChangesAsync();
            }
            return list;
        }

        async Task<List<Review>?> IReviewable.Get(Listing listing)
        {
            var exists = _context.Reviews.Where(r => r.ListingId == listing.ListingId);
            return await exists.ToListAsync();
        }

        Task<List<Review>?> IReviewable.Get(Listing listing, int count)
        {
            throw new NotImplementedException();
        }

        async Task<Review?> IReviewable.Update(Review review)
        {
            var oldreview = await _context.Reviews.FindAsync(review.ReviewId);
            if (oldreview is not null)
            {
                if (review.Listing is not null) oldreview.Listing = review.Listing;
                if (review.Txt is not null) oldreview.Txt = review.Txt;
                //if (review.Reviewer is not null) oldreview.Reviewer = review.Reviewer;
                if (review.At is not null) oldreview.At = review.At;
                _context.Update(review);
                await _context.SaveChangesAsync();
            }
            return oldreview;
        }
    }
}
