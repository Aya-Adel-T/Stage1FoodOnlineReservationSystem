﻿using BackEndRestaurant.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace BackEndRestaurant.Controllers
{
    public class FoodServedBackController : Controller
    {
        APIClient _api = new APIClient();
       
        public async Task<IActionResult> Index()
        {

            HttpClient Client = _api.Initial();
            try
            {
                var foodServedList = await Client.GetFromJsonAsync<List<FoodServed>>("api/FoodServed/getFoodServed");
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
            FoodServed foodServed = new FoodServed();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/FoodServed/getById/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                foodServed = JsonConvert.DeserializeObject<FoodServed>(data);
            }
            return View(foodServed);
        }

        public IActionResult Create()
        {


            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(FoodServed foodServed)
        {

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/FoodServed/Post", foodServed); 
            if (res.IsSuccessStatusCode)
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
        public async Task<ActionResult> Edit(int id, FoodServed foodServed)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync("api/FoodServed/Put", foodServed);

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View(foodServed);
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpClient Client = _api.Initial();
                HttpResponseMessage res = await Client.DeleteAsync($"api/FoodServed/delete/{id}");
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            return View();
        }
    }
}