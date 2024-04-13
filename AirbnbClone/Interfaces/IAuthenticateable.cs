using AirbnbClone.Models.DataLayer;
using AirbnbClone.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AirbnbClone.Interfaces
{
    public interface IAuthenticateable
    {
        public string CreateToken(User user);

        public string ClaimIdentity(IdentityRole identity);

        public IActionResult Login(UserDto user);

        public IActionResult Register(UserDto user);



    }
}
