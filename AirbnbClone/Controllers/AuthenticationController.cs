using AirbnbClone.Interfaces;
using AirbnbClone.Models.DataLayer;
using AirbnbClone.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AirbnbClone.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthenticationController : Controller
    {
        private IAuthenticateable _auth;
        private AirbnbContext _context;

        public AuthenticationController(IAuthenticateable auth, AirbnbContext context)
        {
            _auth = auth;
            _context = context;
        }


        [HttpPost]
        public IActionResult Login(LoginDto user)
        {
            var exists = _context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == u.Password);
            if (exists != null)
            {
                //var token = _auth.CreateToken(exists);
                var returnedData = new RestDto<User>
                {
                    Links = new List<LinkDto>
                    {
                        new LinkDto(Url.Action("Login", "User", "Authentication", Request.Scheme)!, "self", "Post"),
                    },
                    Data = exists
                };
                return Ok(exists);
            }
            return Unauthorized(new { message = "Incorrect Credentials" });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto user)
        {
            var exists = _context.Users.Any(u => u.Username == user.Username);
            if (!exists)
            {
                var newuser = new User
                {
                    Username = user.Username,
                    Password = user.Password,
                    Fullname = user.Fullname
                };
                await _context.Users.AddAsync(newuser);
                newuser._id = await _context.SaveChangesAsync();
                return Ok(newuser);
            }
            else
            {
                return BadRequest(new { message = "Account already exists" });
            }
        }


    }





}
