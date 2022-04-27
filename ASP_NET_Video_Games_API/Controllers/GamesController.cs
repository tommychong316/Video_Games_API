using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{   // api/Games
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GamesController(ApplicationDbContext context)
        {
               _context = context;
        }

        [HttpGet]
        public IActionResult GetGames()
        {
            var allVideoGames = _context.VideoGames.Select(vg => vg).Distinct();

            return Ok(allVideoGames);
        }

        [HttpGet("{id}")]
        public IActionResult GetGamesByPublisher(int id)
        {
            var videoGames = _context.VideoGames.Where(vg => vg.Id == id);
            return Ok(videoGames);
        } 
    }
}
