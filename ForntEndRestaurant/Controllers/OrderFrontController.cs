using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace ForntEndRestaurant.Controllers
{
    public class OrderFrontController : Controller
    {
        //Uri baseAddress = new Uri("https://localhost:7191/api");

        //private readonly HttpClient _client;
        //public OrderFrontController()
        //{
        //_client = new HttpClient();
        //_client.BaseAddress = baseAddress;
        //}
        private string baseAddress = "https://localhost:7191/api";
        public IActionResult Create()
        {

            //List<Order> CategorytList = new List<Order>();
            //HttpResponseMessage resonse = _client.PostAsync(_client.BaseAddress + "/OrderFront/Post").Result;
            //if (resonse.IsSuccessStatusCode)
            //{
            //    string data = resonse.Content.ReadAsStringAsync().Result;
            //    CategorytList = JsonConvert.DeserializeObject<List<Order>>(data);
            //}
            //return View(CategorytList);
            //SelectList Foodserved = new SelectList(context.Departments.ToList(), "Dept_Id", "Dept_Name");
            //ViewBag.Departments = Departments;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
           
            using (var client = new HttpClient())
            {
                string message = "";
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.PostAsJsonAsync<Order>("/Order/Post",order);
                if (res.IsSuccessStatusCode)
                {
                    message = "Save data successfully";
                } else { message = "Failed to save the damn data"; }
                ViewBag.message = message;
            }
            return View();
        }
    }
}
