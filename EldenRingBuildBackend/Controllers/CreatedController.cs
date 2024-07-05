using EldenRingBuildBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EldenRingBuildBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatedController : ControllerBase
    {
        EldenRingDbContext dbContext = new EldenRingDbContext();
        [HttpGet("{id}")]
        public IActionResult GetAllCreated(string id)
        {
            List<Created> result = dbContext.Createds.Where(f => f.UserId == id).Include(f => f.Build).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCreated([FromBody] Created newCreated)
        {
            dbContext.Createds.Add(newCreated);
            dbContext.SaveChanges();
            return Created($"/Created/Api{newCreated.Id}", newCreated);
        }
     
        [HttpDelete("{id}")]
        public IActionResult DeleteCreated(int id)
        {
            Created Result = dbContext.Createds.Find(id);
            if (Result == null)
            {
                return NotFound();
            }
            dbContext.Createds.Remove(Result);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
