using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IRepository<User> UserRepo { get; set; }
        public UserController(IRepository<User> userRepo)
        {
            UserRepo = userRepo;
        }
        [HttpGet]
        public ActionResult<List<User>> getUsers()
        {
            return UserRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<User> getById(int id)
        {
            return UserRepo.GetDetails(id);
        }

        [HttpDelete]
        public ActionResult delete(int id)
        {
           User user = UserRepo.GetDetails(id);

            if (user == null)
            {
                return NotFound();
            }
            UserRepo.Delete(id);
            return Ok(user);
        }
        [HttpPut]
        public ActionResult put(int id, User user)
        {
            User? userr = UserRepo.GetDetails(id);
            if (id != user.Id)
            {
                //return StatusCode(400);
                return BadRequest();
            }
            if (userr != null)
            {


                UserRepo.UpdateBayza(id, userr);
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserRepo.Insert(user);
                    return Created("url", user);
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
