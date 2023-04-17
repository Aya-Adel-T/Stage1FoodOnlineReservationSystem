using ForntEndRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace ForntEndRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //string baseURL = "https://localhost:7191/";
        Uri baseAddress = new Uri("https://localhost:44388/api");
        private readonly HttpClient _client;
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index() {
            //List<Category> CategorytList = new List<Category>();
            //HttpResponseMessage resonse = _client.GetAsync(_client.BaseAddress + "/Category/getCategories").Result;
            //if (resonse.IsSuccessStatusCode) { 
            //string data = resonse.Content.ReadAsStringAsync().Result;
            //    CategorytList = JsonConvert.DeserializeObject<List<Category>>(data);
            //}
            //return View(CategorytList);


            //===============-=-======================-=-===========-=-================
            //public async Task<IActionResult> Index()

            //Calling the web api and populating the data in view using datatable 
            //DataTable dt= new DataTable();
            //using (var Client =new HttpClient())
            //{
            //    Client.BaseAddress= new Uri(baseURL);
            //    Client.DefaultRequestHeaders.Accept.Clear();
            //    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage getData = await Client.GetAsync("Category");
            //    if (getData.IsSuccessStatusCode) 
            //    { 
            //      string results = getData.Content.ReadAsStringAsync().Result;
            //        dt=JsonConvert.DeserializeObject<DataTable>(results);

            //    }
            //    else Console.WriteLine("Error Calling API");

            //}




            return View();
        }

        private MediaTypeWithQualityHeaderValue MediaTypeWithQualityHeaderValue(string v)
        {
            throw new NotImplementedException();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}