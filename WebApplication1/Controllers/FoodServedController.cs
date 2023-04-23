using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodServedController : ControllerBase
    {
        public IRepository<FoodServed> FoodRepo { get; set; }
        public FoodServedController(IRepository<FoodServed> foodRepo)
        {
            FoodRepo = foodRepo;
        }
        [HttpGet]
        public ActionResult<List<FoodServed>> getFoodServed()
        {
            var listOfFoodServed = FoodRepo.GetAll();

            if(listOfFoodServed!=null && listOfFoodServed.Count()>0)
            {
                return Ok(listOfFoodServed);
            }
            return Ok(listOfFoodServed);
        }
        [HttpGet("{id}")]
        public ActionResult<FoodServed> getById(int id)
        {
            return FoodRepo.GetDetails(id);
        }

        [HttpDelete]
        public ActionResult delete(int id)
        {
            FoodServed foodServed = FoodRepo.GetDetails(id);

            if (foodServed == null)
            {
                return NotFound();
            }
            FoodRepo.Delete(id);
            return Ok(foodServed);
        }
        [HttpPut]
        public ActionResult put(int id, FoodServed food)
        {
            FoodServed? foodServed = FoodRepo.GetDetails(id);
            if (id != foodServed.Id)
            {
                //return StatusCode(400);
                return BadRequest();
            }
            if (food != null)
            {


                FoodRepo.UpdateBayza(id, food);
                return Ok(foodServed);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(FoodServed foodServed)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    FoodRepo.Insert(foodServed);
                    return Created("url", foodServed);
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
