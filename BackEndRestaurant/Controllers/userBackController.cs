using BackEndRestaurant.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace BackEndRestaurant.Controllers
{
    public class UserBackController : Controller
    {
        APIClient _api = new APIClient();
        // GET: UserBackController
        public async Task<IActionResult> Index()
        {

            HttpClient Client = _api.Initial();
            try
            {
                var UsersList = await Client.GetFromJsonAsync<List<User>>("api/User/getUsers");
                return View(UsersList);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: UserBackController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserBackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserBackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserBackController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserBackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserBackController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserBackController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}