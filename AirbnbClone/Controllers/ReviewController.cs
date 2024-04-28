using Microsoft.AspNetCore.Mvc;

namespace AirbnbClone.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
