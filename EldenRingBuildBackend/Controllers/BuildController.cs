using EldenRingBuildBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EldenRingBuildBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildController : ControllerBase
    {

        EldenRingDbContext dbContext = new EldenRingDbContext();
        [HttpGet]
        public IActionResult GetAllBuilds()
        {
            List<Build> result = dbContext.Builds.ToList();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Build result = dbContext.Builds.Find(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBuild([FromBody] Build newBuild)
        {
            dbContext.Builds.Add(newBuild);
            dbContext.SaveChanges();
            return Created($"/Build/Api{newBuild.Id}", newBuild);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBuild(int id)
        {
            Build Result = dbContext.Builds.Find(id);
            if (Result == null)
            {
                return NotFound();
            }
            dbContext.Builds.Remove(Result);
            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBuild(int id, [FromBody] Build targetBuild)
        {
            if (id != targetBuild.Id) { return BadRequest(); }
            if (!dbContext.Builds.Any(f => f.Id == id)) { return NotFound(); }
            dbContext.Builds.Update(targetBuild);
            dbContext.SaveChanges();
            return NoContent();
        }


    }
}
