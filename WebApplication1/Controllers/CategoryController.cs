using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        public IRepository<Category> CategoryRepo { get; set; }
        public CategoryController(IRepository<Category> categoryRepo)
        {
            CategoryRepo = categoryRepo;
        }
        [HttpGet]
        public ActionResult <List<Category>> getCategories()
        {
           
            return CategoryRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Category> getById(int id)
        {
            return CategoryRepo.GetDetails(id);
        }

        [HttpDelete]
        public ActionResult deleteCategory(int id)
        {
            Category category = CategoryRepo.GetDetails(id);

            if (category == null)
            {
                return NotFound();
            }
            CategoryRepo.Delete(id);
            return Ok(category);
        }
        [HttpPut]
        public ActionResult put(int id, Category ctgry)
        {
            Category? category = CategoryRepo.GetDetails(id);
            if (id != category.Id)
            {
                //return StatusCode(400);
                return BadRequest();
            }
            if (category != null)
            {
               
                          
                CategoryRepo.Update(id, ctgry);
                return Ok(category);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CategoryRepo.Insert(category);
                    return Created("url", category);
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
