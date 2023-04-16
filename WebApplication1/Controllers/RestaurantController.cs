using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly ElDbContext ElDbContext;

        public RestaurantController(ElDbContext elDbContext)
        {
               ElDbContext = elDbContext;
        }
        [HttpGet]
       public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            return await ElDbContext.Restaurants.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetRestaurantsById(int id)
        {
            var res= await ElDbContext.Restaurants.FindAsync(id);
            return res == null ? NotFound() : Ok(res);
        } 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateRestaurant(Restaurant resta)
        {
            await ElDbContext.Restaurants.AddAsync(resta);
            await ElDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRestaurantsById), new { id = resta.Id, resta });
        }

    }
}
