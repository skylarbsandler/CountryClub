using CountryClubAPI.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CountryClubAPI.Models;

namespace CountryClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly CountryClubContext _context;

        public BookingsController(CountryClubContext context)
        {
            _context = context;
        }

        //GET: "/api/bookings"
        [HttpGet]
        public IActionResult AllBookings()
        {
            var bookings = _context.Bookings;

            return new JsonResult(bookings);
        }

        [HttpPost]
        public ActionResult CreateBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return BadRequest();
            }
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            Response.StatusCode = 201;
            return new JsonResult(booking);
        }
    }
}
