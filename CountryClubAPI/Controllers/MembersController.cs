using CountryClubAPI.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CountryClubAPI.Models;

namespace CountryClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly CountryClubContext _context;

        public MembersController(CountryClubContext context)
        {
            _context = context;
        }

        //GET: "/api/members"
        [HttpGet]
        public IActionResult AllMembers()
        {
            var members = _context.Members;

            return new JsonResult(members);
        }

        //Get: "/api/members/:id"
        [HttpGet("{memberId}")]
        public ActionResult GetMemberfromId(int memberId)
        {
            var member = _context.Members.Find(memberId);

            if (member is null)
            {
                return NotFound();
            }

            Response.StatusCode = 200;

            return new JsonResult(member);
        }

        //POST: "/api/members"
        [HttpPost]
        public ActionResult CreateMember(Member member)
        {
            if(!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return BadRequest();
            }
            _context.Members.Add(member);
            _context.SaveChanges();

            Response.StatusCode = 201;
            return new JsonResult(member);
        }

        [HttpPut("{memberId}")]
        public ActionResult UpdateMember(int memberId, Member member)
        {
            var existingMember = _context.Members.Find(memberId);

            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
            }

            existingMember.LastName = member.LastName;
            existingMember.FirstName = member.FirstName;
            existingMember.Address = member.Address;
            existingMember.ZipCode = member.ZipCode;
            existingMember.Telephone = member.Telephone;
            existingMember.RecommendedBy = member.RecommendedBy;
            existingMember.JoinDate = member.JoinDate;

            _context.Members.Update(existingMember);
            _context.SaveChanges();

            Response.StatusCode = 204;
            return new JsonResult(existingMember); ;
        }

        [HttpDelete("{memberId}")]
        public ActionResult DeleteMemberfromId(int memberId)
        {
            var members = _context.Members;
            var member = members.Find(memberId);

            if (member is null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            _context.SaveChanges();

            Response.StatusCode = 204;
            return new JsonResult(members);
        }
    }
}
