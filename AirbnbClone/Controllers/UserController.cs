using Microsoft.AspNetCore.Mvc;

namespace AirbnbClone.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
    }
}
