using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;
using AirbnbClone.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AirbnbClone.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ListingController : Controller
    {
        private IListable _service;
        public ListingController(IListable service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllListings()
        {

            List<CreateListingDto?>? listings = await _service.Get();
            if (listings == null)
            {
                return NotFound(new { message = "No listings were found" });

            }
            return Ok(new { message = "Retrieved listings successfully", data = listings });
        }

        [HttpGet]
        public async Task<IActionResult> GetUserListings(string user)
        {

            var listings = await _service.Get(user);
            if (listings.Count == 0)
            {
                return NotFound(new { message = "No listings were found" });

            }
            return Ok(new { message = "Retrieved listings successfully", data = listings });
        }

        [HttpGet]
        public async Task<IActionResult> GetListingById(int id)
        {
            var listing = await _service.Get(id);
            if (listing is not null)
                return Ok(new { message = $"Listing {listing.Name} retrieved successfully", data=listing });

            return NotFound(new { message = $"listing {id} was not found on the server" });
        }

        [HttpPost]
        public async Task<IActionResult> CreateListing(CreateListingDto listing)
        {
            return Created("Created Succesfully", new
            {
                message = "Listing added successfully",
                data = await _service.Create(listing)
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateListing(CreateListingDto listing)
        {
            return Ok(new { message = "Listing updated successfully", data = await _service.Update(listing) });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(new { message = "Listing Deleted successfully", data = await _service.Delete(id) });
        }

        [HttpGet]
        public async Task<IActionResult> FilterListing(string label)
        {
            var listings = await _service.Filter(label);
            if(listings == null) return NotFound();
            return Ok(listings);
        }
    }
}
