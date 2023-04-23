using BackEndRestaurant.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebApplication1.Models;

namespace BackEndRestaurant.Controllers
{
    public class FoodServedBackController : Controller
    {
        APIClient _api = new APIClient();


       
        public async Task<IActionResult> Index()
        {

            //var orders = db.FoodServed.Include(o => o.Category);


            //ViewBag.Customers = db.Customers.ToList();
            //return View(orders.ToList());

            HttpClient Client = _api.Initial();
            try
            {
                var foodServedList = await Client.GetFromJsonAsync<List<FoodServed>>("api/FoodServed");
                return View(foodServedList);
            }
            catch (Exception e)
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Category Category = new Category();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Category/getById/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                Category = JsonConvert.DeserializeObject<Category>(data);
            }
            return View(Category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            HttpClient Client = _api.Initial();

            var PostCategory = Client.PostAsJsonAsync<Category>("api/Category/Post", category);
            PostCategory.Wait();
            var data = PostCategory.Result;
            if (data.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            return View();
        }



        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7191/api/");
                var putTask = client.PutAsJsonAsync<Category>("Category/Put", category);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View(category);
        }


        public IActionResult Delete(int id)
        {
            using (var Client = new HttpClient())
            {
                //    Client.BaseAddress = new Uri("https://localhost:7191/api");
                Client.BaseAddress = new Uri("https://localhost:7191/api/");
                var deleteCategory = Client.DeleteAsync($"Category/DeleteCategory/{id}");
                deleteCategory.Wait();
                var result = deleteCategory.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

    }
}
