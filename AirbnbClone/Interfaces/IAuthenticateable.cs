using AirbnbClone.Models.DataLayer;
using AirbnbClone.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AirbnbClone.Interfaces
{
    public interface IAuthenticateable
    {
        public string CreateToken(User user);

        public int GetId(ClaimsIdentity identity);
    }
}
