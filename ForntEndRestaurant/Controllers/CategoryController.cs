using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace ForntEndRestaurant.Controllers
{
    public class CategoryController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7191/api");
        private readonly HttpClient _client;
        public CategoryController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Category> CategorytList = new List<Category>();
            HttpResponseMessage resonse = _client.GetAsync(_client.BaseAddress + "/Category/getCategories").Result;
            if (resonse.IsSuccessStatusCode)
            {
                string data = resonse.Content.ReadAsStringAsync().Result;
                CategorytList = JsonConvert.DeserializeObject<List<Category>>(data);
            }
            return View(CategorytList);
        }

    }
}
