using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;
using AirbnbClone.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection;

namespace AirbnbClone.Services
{
    public class ListingService : IListable
    {
        private AirbnbContext _context;
        private IHostable _host;

        public ListingService(AirbnbContext context,IHostable host)
        {
            _context = context;
            _host = host;
        }

        public async Task<List<CreateListingDto>> Filter(string label)
        {
            var listings = await  _context.Listings
                .Where(l => l.ListingLabels!.Any(ll => ll.Label == label)).ToListAsync();
            var listing2 = await _context.Listings
                .Where(l => l.ListingAmenities!.Any(la => la.Amenity == label)).ToListAsync();
            foreach(var listing in listing2)
            {
                if(!listing2.Contains(listing))
                listings.Add(listing);
            }
            var listingDtos = new List<CreateListingDto>();
            if (listings != null)
            {
                foreach (var listing in listings)
                {
                    Console.WriteLine($"help this is {listing.Location?.Address}");
                    CreateListingDto listingDto = new CreateListingDto
                    {
                        _id = listing.ListingId,
                        Type = listing.Type,
                        Name = listing.Name,
                        Price = listing.Price,
                        Summary = listing.Summary,
                        Capacity = listing.Capacity,
                        RoomType = listing.RoomType,
                        LikedByUsers = listing.LikedByUsers != null ? listing.LikedByUsers.Split(",").ToList() : new List<string>(),
                        ImgUrls = await _context.ListingImgUrls.Where(i => i.ListingId == listing.ListingId).Select(l => l.ImgUrl!).ToListAsync(),
                        Bathrooms = listing.Bathrooms,
                        Bedrooms = listing.Bedrooms,
                        Host = await _host.GetbyId(listing.HostId!.Value),
                        Loc = await GetLocationById(listing.LocationId.Value),
                        StatReviews = new StatReviewsDTO
                        {
                            Cleanliness = listing.StatCleanliness,
                            Communication = listing.StatCommunication,
                            CheckIn = listing.StatCheckIn,
                            Accuracy = listing.StatAccuracy,
                            Value = listing.StatValue,
                            Location = listing.StatLocation
                        }
                    };

                    listingDto.Amenities = await _context.ListingAmenities.Where(l => l.ListingId == listingDto._id).Select(l => l.Amenity).ToListAsync();
                    listingDto.Labels = await _context.ListingLabels.Where(l => l.ListingId == listingDto._id).Select(l => l.Label).ToListAsync();

                    listingDtos.Add(listingDto);
                }
            }
            return listingDtos;
        }



        async Task<Listing> IListable.Create(CreateListingDto listing)
        {
            

            var newListing = new Listing
            {

                Type = listing.Type,

                Name = listing.Name,

                Price = listing.Price,

                Summary = listing.Summary,

                Capacity = listing.Capacity,

                RoomType = listing.RoomType,
                

                Bathrooms = listing.Bathrooms,

                Bedrooms = listing.Bedrooms,
                Host = new AirbnbClone.Models.DataLayer.Host
                {
                    CreateAt = listing.Host!.CreateAt,
                    Fullname = listing.Host!.Fullname!,
                    ResponseTime = listing.Host!.ResponseTime,
                    PictureUrl = listing.Host.PictureUrl ?? listing.Host.ThumbnailUrl!,
                    IsSuperhost = listing.Host!.IsSuperhost,
                    PolicyNumber = listing.Host!.PolicyNumber
                },
                Location = new Location
                {
                    Country = listing.Loc!.Country!,
                    CountryCode = listing.Loc!.CountryCode!,
                    City = listing.Loc!.City!,
                    Address = listing.Loc!.Address!,
                    Lan = (decimal)listing.Loc!.Lan!,
                    Lat = (decimal)listing.Loc!.Lat!,
                },
             
                    StatCleanliness  = listing.StatReviews!.Cleanliness,
                    StatCommunication = listing.StatReviews!.Communication,
                    StatCheckIn = listing.StatReviews!.CheckIn,
                    StatAccuracy = listing.StatReviews.Accuracy,
                    StatValue = listing.StatReviews.Value,

                    
                    
            };
            if (newListing.ListingImgUrls == null) newListing.ListingImgUrls = new List<ListingImgUrl?> { };
            foreach(var imgurls in listing.ImgUrls!)
            {
                if(imgurls != null)
                {
                    newListing.ListingImgUrls
                     .Add(new ListingImgUrl { ImgUrl = imgurls });
                }
            }
           

            if (listing.Labels != null)
            {
                var listinglabels = new List<ListingLabel> { };
                foreach (var label in listing.Labels)
                {
                    listinglabels.Add(new ListingLabel { Label = label});
                }
                newListing.ListingLabels = listinglabels.Count > 0 ?  listinglabels : null ;
            }
            if (listing.Amenities != null)
            {
                var listingamenities = new List<ListingAmenity> { };
                foreach (var a in listing.Amenities)
                {
                    listingamenities.Add(new ListingAmenity { Amenity = a });
                }
                newListing.ListingAmenities = listingamenities.Count > 0 ? listingamenities : null;
            }
            await _context.Listings.AddAsync(newListing);
            newListing.ListingId = await _context.SaveChangesAsync();
            return newListing;
        }

        async Task<Listing?> IListable.Delete(int id)
        {
            var exists = await _context.Listings.FirstOrDefaultAsync(l => l.ListingId == id);
            if (exists != null)
            {
                _context.Listings.Remove(exists);
                await _context.SaveChangesAsync();
            }
            return exists!;
        }

        async Task<List<CreateListingDto>> IListable.Get()
        {
            var listings = await _context.Listings.ToListAsync();
            Console.WriteLine($"{listings.Count} listing list created");
            var listingDtos = new List<CreateListingDto>();
            
            if(listings != null)
            {
            foreach(var listing in listings)
            {
                    Console.WriteLine($"help this is {listing.Location?.Address}");
                    CreateListingDto listingDto = new CreateListingDto
                    {
                        _id = listing.ListingId,
                        Type = listing.Type,
                        Name = listing.Name,
                        Price = listing.Price,
                        Summary = listing.Summary,
                        Capacity = listing.Capacity,
                        RoomType = listing.RoomType,
                        LikedByUsers = listing.LikedByUsers != null? listing.LikedByUsers.Split(",").ToList() : new List<string>(),
                ImgUrls =  await _context.ListingImgUrls.Where(i=> i.ListingId == listing.ListingId).Select(l=> l.ImgUrl!).ToListAsync(),
                Bathrooms = listing.Bathrooms,
                Bedrooms = listing.Bedrooms,
                Host = await _host.GetbyId(listing.HostId!.Value),
                Loc = await GetLocationById(listing.LocationId.Value),
                 StatReviews = new StatReviewsDTO
                {
                    Cleanliness = listing.StatCleanliness,
                    Communication = listing.StatCommunication,
                    CheckIn = listing.StatCheckIn,
                    Accuracy = listing.StatAccuracy,
                    Value = listing.StatValue,
                    Location = listing.StatLocation
                }
            };

                    listingDto.Amenities = await _context.ListingAmenities.Where(l => l.ListingId == listingDto._id).Select(l => l.Amenity).ToListAsync();
                    listingDto.Labels = await _context.ListingLabels.Where(l => l.ListingId == listingDto._id).Select(l => l.Label).ToListAsync();

                listingDtos.Add(listingDto);
                Console.WriteLine($"Recored of {listingDto.Name} was added");
            }
            }
            return listingDtos;
        }

        async Task<CreateListingDto?> IListable.Get(int id)
        {
            var listing = await _context.Listings.FirstOrDefaultAsync(l => l.ListingId == id);
            CreateListingDto listingDto = new CreateListingDto { };
            if (listing != null)
            {

                listingDto = new CreateListingDto
                {
                    _id = listing.ListingId,
                    Type = listing.Type,
                    Name = listing.Name,
                    Price = listing.Price,
                    Summary = listing.Summary,
                    Capacity = listing.Capacity,
                    RoomType = listing.RoomType,
                    LikedByUsers = listing.LikedByUsers != null ? listing.LikedByUsers.Split(",").ToList() : new List<string>(),
                    ImgUrls = await _context.ListingImgUrls.Where(i => i.ListingId == listing.ListingId).Select(l => l.ImgUrl!).ToListAsync(),
                    Bathrooms = listing.Bathrooms,
                    Bedrooms = listing.Bedrooms,
                    Host = await _host.GetbyId(listing.HostId!.Value),
                    Loc = await GetLocationById(listing.LocationId.Value),
                    StatReviews = new StatReviewsDTO
                    {
                        Cleanliness = listing.StatCleanliness,
                        Communication = listing.StatCommunication,
                        CheckIn = listing.StatCheckIn,
                        Accuracy = listing.StatAccuracy,
                        Value = listing.StatValue,
                        Location = listing.StatLocation
                    },
                  
                };

                listingDto.Amenities = await _context.ListingAmenities.Where(l => l.ListingId == listingDto._id).Select(l => l.Amenity).ToListAsync();
                listingDto.Labels = await _context.ListingLabels.Where(l => l.ListingId == listingDto._id).Select(l => l.Label).ToListAsync();
                listingDto.Reviews = await _context.Reviews.Where(l => l.ListingId == listingDto._id).Select(l => ConvertToReviewDto(l)).ToListAsync();

            }

            return listingDto;
        }
        async Task<List<CreateListingDto?>?> IListable.Get(string user)
        {
            var listings = await _context.Listings.Where(l => l.Host!.Fullname == user).ToListAsync();
            var listingDtos = new List<CreateListingDto>();

            if (listings != null)
            {
                foreach (var listing in listings)
                {
                    
                    CreateListingDto listingDto = new CreateListingDto
                    {
                        _id = listing.ListingId,
                        Type = listing.Type,
                        Name = listing.Name,
                        Price = listing.Price,
                        Summary = listing.Summary,
                        Capacity = listing.Capacity,
                        RoomType = listing.RoomType,
                        LikedByUsers = listing.LikedByUsers != null ? listing.LikedByUsers.Split(",").ToList() : new List<string>(),
                        ImgUrls = await _context.ListingImgUrls.Where(i => i.ListingId == listing.ListingId).Select(l => l.ImgUrl!).ToListAsync(),
                        Bathrooms = listing.Bathrooms,
                        Bedrooms = listing.Bedrooms,
                        Host = await _host.GetbyId(listing.HostId!.Value),
                        Loc = await GetLocationById(listing.LocationId.Value),
                        StatReviews = new StatReviewsDTO
                        {
                            Cleanliness = listing.StatCleanliness,
                            Communication = listing.StatCommunication,
                            CheckIn = listing.StatCheckIn,
                            Accuracy = listing.StatAccuracy,
                            Value = listing.StatValue,
                            Location = listing.StatLocation
                        },

                     Amenities = await _context.ListingAmenities.Where(l => l.ListingId == listing.ListingId).Select(l => l.Amenity).ToListAsync(),
                    Labels = await _context.ListingLabels.Where(l => l.ListingId == listing.ListingId).Select(l => l.Label).ToListAsync(),
                    Reviews = await _context.Reviews.Where(l => l.ListingId == listing.ListingId).Select(l => ConvertToReviewDto(l)).ToListAsync(),

                };
                    listingDtos.Add(listingDto);

                }


           
            }
            return listingDtos;
        }
    

        async Task<Listing?> IListable.Update(CreateListingDto listing)
        {
            var oldlist = await _context.Listings.FirstOrDefaultAsync(l => l.ListingId == listing._id!.Value);
            if (oldlist is not null)
            {

                oldlist.ListingId = listing._id!.Value;

                oldlist.Type = listing.Type;

                oldlist.Name = listing.Name;

                oldlist.Price = listing.Price;

                oldlist.Summary = listing.Summary;

                oldlist.Capacity = listing.Capacity;
                oldlist.LikedByUsers = listing.LikedByUsers != null && listing?.LikedByUsers.Count != 0 ? string.Join(',', listing!.LikedByUsers) : string.Empty;

                oldlist.RoomType = listing.RoomType;

                oldlist.Bathrooms = listing.Bathrooms;

                oldlist.Bedrooms = listing.Bedrooms;
                
                
                oldlist.StatCleanliness = listing.StatReviews!.Cleanliness;
                oldlist.StatCommunication = listing.StatReviews!.Communication;
                oldlist.StatCheckIn = listing.StatReviews!.CheckIn;
                oldlist.StatAccuracy = listing.StatReviews.Accuracy;
                oldlist.StatValue = listing.StatReviews.Value;

                var oldlistHost = await _context.Hosts.FirstOrDefaultAsync(h => h.HostId == oldlist.HostId);
                if(oldlistHost != null)
                {
                    oldlistHost!.CreateAt = listing.Host?.CreateAt != null ? listing.Host.CreateAt : 0;
                    oldlistHost!.Fullname = listing.Host!.Fullname!;
                    oldlistHost!.ResponseTime = listing.Host!.ResponseTime;
                    oldlistHost!.PictureUrl = listing.Host.PictureUrl ?? listing.Host!.ThumbnailUrl!;
                    oldlistHost!.IsSuperhost = listing.Host!.IsSuperhost;
                    oldlistHost!.PolicyNumber = listing.Host!.PolicyNumber;
                    
                }
                var oldlistLocation = await _context.Locations.FirstOrDefaultAsync(l => l.LocationId == oldlist.LocationId);
                if(oldlistLocation != null)
                {
                    oldlist.Location!.Country = listing.Loc!.Country!;
                    oldlist.Location!.CountryCode = listing.Loc!.CountryCode!;
                    oldlist.Location!.City = listing.Loc!.City!;
                    oldlist.Location!.Address = listing.Loc!.Address!;
                    oldlist.Location!.Lan = (decimal)listing.Loc!.Lan!;
                    oldlist.Location!.Lat = (decimal)listing.Loc!.Lat!;
                }
            var oldlistAmenity = await _context.ListingAmenities.Where(la => la.ListingId == listing._id).Select(la => la.Amenity).ToListAsync();
            if(oldlistAmenity != null)
            {
                if(listing.Amenities != null)
                {
                    oldlist.ListingAmenities = new List<ListingAmenity?> { };
                    foreach (var amenity in listing.Amenities)
                    {
                        if (amenity != null)
                        {
                                if (!oldlistAmenity.Contains(amenity))
                                {
                                      oldlist.ListingAmenities.Add(new ListingAmenity { Amenity = amenity });
                                }
                        }                       
                    }
                    foreach(var oldamenity in oldlistAmenity)
                        {
                            if(oldamenity != null)
                            {
                                if (!listing.Amenities.Contains(oldamenity))
                                {
                                    _context.ListingAmenities.Remove(new ListingAmenity { ListingId= listing._id.Value,Amenity =oldamenity });
                                }
                            }
                        }
                }
            }

 


            var oldlistLabel = await _context.ListingLabels.Where(la => la.ListingId == listing._id).Select(la => la.Label).ToListAsync();
                if (oldlistLabel != null)
                {
                    if (listing.Labels != null)
                    {
                        oldlist.ListingLabels = new List<ListingLabel?> { };
                        foreach (var label in listing.Labels)
                        {
                            if (label != null && !oldlistLabel.Contains(label))
                            {
                                oldlist.ListingLabels.Add(new ListingLabel { Label = label });
                            }
                        }
                        foreach (var oldlabel in oldlistLabel)
                        {
                            if (oldlabel != null)
                            {
                                if (!listing.Labels.Contains(oldlabel))
                                {
                                    _context.ListingLabels.Remove(new ListingLabel { ListingId = listing._id.Value, Label = oldlabel });
                                }
                            }
                        }
                    }
                }

                var oldlistReview = await _context.Reviews.Where(la => la.ListingId == listing._id).ToListAsync();
                if (oldlistReview != null)
                    
                {
                    if (listing.Reviews != null)
                    {
                        oldlist.Reviews = new List<Review?> { };
                        foreach (var review in listing.Reviews)
                        {
                            if (review != null && !oldlistReview.Contains(ConvertToReview(review)))
                            {
                                oldlist.Reviews.Add(ConvertToReview(review));
                            }
                        }
                        foreach (var oldreview in oldlistReview)
                        {
                            if (oldreview != null)
                            {
                                if (!listing.Reviews.Contains(ConvertToReviewDto(oldreview)))
                                {
                                    _context.Reviews.Remove(oldreview);
                                }
                            }
                        }
                    }
                }


                await _context.SaveChangesAsync();
            }
            return oldlist!;
        }


        async Task<LocationDTO> GetLocationById(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.LocationId == id);
            if(location != null)
            {
                var locationDto = new LocationDTO
                {
                    Country = location?.Country,
                    CountryCode = location?.CountryCode,
                    City = location?.City,
                    Address = location?.Address,
                    Lan = (double)location?.Lan!,
                    Lat = (double)location.Lat!
                };
                return locationDto;
                
            }
            return null!;
        }

       static Review? ConvertToReview(ReviewDto dto)
        {
            var review = new Review
            {
                At = dto.At,
                Txt = dto.txt,
                ReviewerId= dto.By!._id,
                Fullname = dto.By.fullname,
                UserImg = dto.By.imgUrl,

            };
            return review;
        }

        static ReviewDto ConvertToReviewDto(Review review)
        {
            var dto = new ReviewDto
            {
                At = review.At,
                txt =review.Txt,
                By = new By
                {
                    fullname = review.Fullname,
                    _id = review.ReviewerId,
                    imgUrl = review.UserImg
                } 
            };
            return dto;
        }






        public async Task<List<CreateListingDto>> Filter(ListingFilter filter)
        {
            if (filter == null) return null!;
            var listings = new HashSet<Listing>();
            List<CreateListingDto> listingDtos = new List<CreateListingDto> { };

            List<Listing>? labels,amenities,place,liked;
            if (!string.IsNullOrEmpty(filter.Label))
            {
                string filterLabelLower = filter.Label.ToLower();
                labels = await _context.Listings
                            .Where(l => l.ListingLabels!.Any(ll =>
                                ll.Label.ToLower().Contains(filterLabelLower) ||
                                ll.Label.ToLower().StartsWith(filterLabelLower) ||
                                ll.Label.ToLower().EndsWith(filterLabelLower)))
                            .ToListAsync();
                if (labels != null)
                {
                    foreach(var label in labels)
                    {
                        listings.Add(label);
                    }
                }
            }

                if (!string.IsNullOrEmpty(filter.Label))
                {
                    string filterAmenityLower = filter.Label.ToLower();
                    amenities = await _context.Listings
                                    .Where(l => l.ListingAmenities!.Any(ll =>
                                        ll.Amenity.ToLower().Contains(filterAmenityLower) ||
                                        ll.Amenity.ToLower().StartsWith(filterAmenityLower) ||
                                        ll.Amenity.ToLower().EndsWith(filterAmenityLower)))
                                    .ToListAsync();
                if (amenities != null)
                {
                    foreach (var a in amenities)
                    {
                        listings.Add(a);
                    }
                }
            }

            if (!string.IsNullOrEmpty(filter.Place))
            {
                string filterPlaceLower = filter.Place.ToLower();
                place = await _context.Listings
                            .Where(l => l.Location!.Address != null &&
                                        (l.Location.Address.ToLower().Contains(filterPlaceLower) ||
                                        l.Location.Address.ToLower().StartsWith(filterPlaceLower) ||
                                        l.Location.Address.ToLower().EndsWith(filterPlaceLower)))
                            .ToListAsync();

                if (place != null)
                {
                    foreach (var label in place)
                    {
                        listings.Add(label);
                    }
                }

            }
            if (!string.IsNullOrEmpty(filter.LikeByUser.ToString()) )
            {
                liked = await _context.Listings
                                .Where(l => l.LikedByUsers!.Contains(Convert.ToString(filter!.LikeByUser!)!)).ToListAsync();
                if (liked != null)
                {
                    foreach (var label in liked)
                    {
                        listings.Add(label);
                    }
                }
            }

            if (listings != null)
            {
                foreach (var listing in listings)
                {

                    CreateListingDto listingDto = new CreateListingDto
                    {
                        _id = listing.ListingId,
                        Type = listing.Type,
                        Name = listing.Name,
                        Price = listing.Price,
                        Summary = listing.Summary,
                        Capacity = listing.Capacity,
                        RoomType = listing.RoomType,
                        LikedByUsers = listing.LikedByUsers != null ? listing.LikedByUsers.Split(",").ToList() : new List<string>(),
                        ImgUrls = await _context.ListingImgUrls.Where(i => i.ListingId == listing.ListingId).Select(l => l.ImgUrl!).ToListAsync(),
                        Bathrooms = listing.Bathrooms,
                        Bedrooms = listing.Bedrooms,
                        Host = await _host.GetbyId(listing.HostId!.Value),
                        Loc = await GetLocationById(listing.LocationId.Value),
                        StatReviews = new StatReviewsDTO
                        {
                            Cleanliness = listing.StatCleanliness,
                            Communication = listing.StatCommunication,
                            CheckIn = listing.StatCheckIn,
                            Accuracy = listing.StatAccuracy,
                            Value = listing.StatValue,
                            Location = listing.StatLocation
                        },

                        Amenities = await _context.ListingAmenities.Where(l => l.ListingId == listing.ListingId).Select(l => l.Amenity).ToListAsync(),
                        Labels = await _context.ListingLabels.Where(l => l.ListingId == listing.ListingId).Select(l => l.Label).ToListAsync(),
                        Reviews = await _context.Reviews.Where(l => l.ListingId == listing.ListingId).Select(l => ConvertToReviewDto(l)).ToListAsync(),

                    };
                    listingDtos.Add(listingDto);

                }



            }
            return listingDtos;

        }

    }
}

