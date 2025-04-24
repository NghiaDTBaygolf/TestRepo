using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGit.Data;
using TestGit.Models;
using TestGit.ModelsRequest;

namespace TestGit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EliteClubController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EliteClubController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<EliteClubController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/<EliteClubController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<EliteClubController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewEliteClubPrivilegeModel privilege)
        {
            Console.WriteLine(privilege);
            var newPrivilege = new EliteClubPrivilege
            {
                Code = privilege.Code,
                PrivilegeTitle = privilege.PrivilegeTitle,
                ImageUrl = privilege.ImageUrl,
                DetailUrl = privilege.DetailUrl,
                SortOrder = privilege.SortOrder,
                DisplayStatus = privilege.DisplayStatus
            };
            _context.EliteClubPrivileges.Add(newPrivilege);
            await _context.SaveChangesAsync();
            return Ok();
        }
        // PUT api/<EliteClubController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/<EliteClubController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
