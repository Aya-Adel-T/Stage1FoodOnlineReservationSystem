using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        public IRepository<Restaurant> RestaurantRepo { get; set; }
        public RestaurantController(IRepository<Restaurant> restaurantRepo)
        {
            RestaurantRepo = restaurantRepo;
        }
        [HttpGet]
        public ActionResult<List<Restaurant>> getRestaurants()
        {

            return RestaurantRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Restaurant> getById(int id)
        {
            return RestaurantRepo.GetDetails(id);
        }

        [HttpDelete]
        public ActionResult delete(int id)
        {
           Restaurant restaurant = RestaurantRepo.GetDetails(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            RestaurantRepo.Delete(id);
            return Ok(restaurant);
        }
        [HttpPut]
        public ActionResult put(int id, Restaurant rstrnt)
        {
            Restaurant? restaurant = RestaurantRepo.GetDetails(id);
            if (id != restaurant.Id)
            {
                //return StatusCode(400);
                return BadRequest();
            }
            if (restaurant != null)
            {


                RestaurantRepo.Update(id, rstrnt);
                return Ok(restaurant);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RestaurantRepo.Insert(restaurant);
                    return Created("url", restaurant);
                    // return 201 & Url is the place where you added the object
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message); // Return 400!
                }
            }
            return BadRequest();
        }
    }
}
