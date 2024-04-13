using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;
using AirbnbClone.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AirbnbClone.Services
{
    public class AuthenticationService : IAuthenticateable
    {
        private readonly string _jwtSecret;
        private readonly string _issuer;
        private readonly string _audience;

        public AuthenticationService( string jwtSecret, string issuer, string audience)
        {
            _jwtSecret = jwtSecret;
            _audience = audience;
            _issuer = issuer;
        }

        public string CreateToken(User user)
        {
            throw new NotImplementedException();
        }

        public int GetId(ClaimsIdentity identity)
        {
            throw new NotImplementedException();
        }

    }
}
