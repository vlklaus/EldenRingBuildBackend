using EldenRingBuildBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace EldenRingBuildBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        EldenRingDbContext dbContext = new EldenRingDbContext();
        [HttpGet("{id}")] 
        public IActionResult GetAllFavorites(string id)
        {
            List<Favorite> result = dbContext.Favorites.Where(f => f.UserId == id).Include(f => f.Build).ToList();
            return Ok(result);
        }

        [HttpPost] 
        public IActionResult AddFavorite([FromBody] Favorite newFavorite)
        {
            dbContext.Favorites.Add(newFavorite);
            dbContext.SaveChanges();
            return Created($"/Favorite/Api{newFavorite.Id}", newFavorite);
        }

        [HttpDelete("{id}")] 
        public IActionResult DeleteFavorite(int id)
        {
            Favorite Result = dbContext.Favorites.Find(id);
            if(Result == null)
            {
                return NotFound();
            }
            dbContext.Favorites.Remove(Result);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
