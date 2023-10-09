using Microsoft.AspNetCore.Mvc;

namespace CountryClubAPI.Controllers
{
    public class FacilitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
