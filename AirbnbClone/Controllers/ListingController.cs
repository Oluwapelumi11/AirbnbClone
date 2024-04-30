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
        public async Task<IActionResult> FilterListing(int likeByUser = 0, string place = "", string label = "", int hostId = 0, bool isPetAllowed = false)
        {
            var filter = new ListingFilter { };
            if (likeByUser != 0) { filter.LikeByUser = likeByUser; }
            if (place != "") { filter.Place = place; }
            if (place != "") { filter.Place = place; }
            if (hostId != 0) { filter.HostId = hostId; }
            filter.IsPetAllowed = isPetAllowed;
            if (filter == null) return Ok(await _service.Get());
            var listings = await _service.Filter(filter);
            if(listings is not null)
            {
                return Ok(listings);
            }
            return NotFound("No listing matches the serach criteria");
        }

        [HttpGet]
        public async Task<IActionResult> Length(int likeByUser = 0, string place="",string label="",int hostId=0, bool isPetAllowed =false )
        {
            var filter = new ListingFilter { };
            if (likeByUser != 0) { filter.LikeByUser = likeByUser; }
            if (place != "") { filter.Place = place; }
            if (place != "") { filter.Place = place; }
            if (hostId != 0) { filter.HostId = hostId; }
            filter.IsPetAllowed = isPetAllowed;
            if (filter == null) return Ok(await _service.Get());

            Console.WriteLine($"{filter.Label}\n\n{filter.IsPetAllowed}\n\n{filter.Place}");
            var listings = await _service.Filter(filter);
            if (listings != null)
            {
                return Ok(listings.Count);
            }
            return Ok(0);
        }
    }
}
