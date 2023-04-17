using BackEndRestaurant.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace BackEndRestaurant.Controllers
{
    public class CategoryBackController : Controller
    {
        //Uri baseAddress = new Uri("https://localhost:7191/api");
        //private readonly HttpClient _client;
        //public CategoryBackController()
        //{
        //    _client = new HttpClient();
        //    _client.BaseAddress = baseAddress;
        //}

        //Another way
        //private string baseAddressstr = "https://localhost:7191/api";


        //Another way 
        APIClient _api = new APIClient();

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    List<Category> CategorytList = new List<Category>();
        //    HttpResponseMessage resonse = _client.GetAsync(_client.BaseAddress + "/Category/getCategories").Result;
        //    if (resonse.IsSuccessStatusCode)
        //    {
        //        string data = resonse.Content.ReadAsStringAsync().Result;
        //        CategorytList = JsonConvert.DeserializeObject<List<Category>>(data);
        //    }
        //    return View(CategorytList);
        //}


        //Another way for index 
        public async Task<IActionResult> Index()
        {
            List<Category> CategorytList = new List<Category>();
            HttpClient Client = _api.Initial();
            HttpResponseMessage resonse = await Client.GetAsync("api/Category/getCategories");
            if (resonse.IsSuccessStatusCode)
           {
               string data = resonse.Content.ReadAsStringAsync().Result;
               CategorytList = JsonConvert.DeserializeObject<List<Category>>(data);
           }
           return View(CategorytList);
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
            }return View();
        }


        //Not Working $%^$%^$%^$%^
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(Category category)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        string message = "";
        //        client.BaseAddress = new Uri(baseAddressstr);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage res = await client.PostAsJsonAsync<Category>("/Category/Post",category);
        //        if (res.IsSuccessStatusCode)
        //        {
        //            message = "Save data successfully";
        //        }
        //        else { message = "Failed to save the damn data"; }
        //        ViewBag.message = message;
        //    }
        //    return View();
        //}
    }
}
