using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using WebClient.Helper;
using WebClient.Models;
using WebClient.Models.ViewModel;

namespace WebClient.Controllers
{
    public class ServicesObjectController : Controller
    {
        ServicesBookingApi _api = new ServicesBookingApi();

        public async Task<IActionResult> Index()
        {
            List<ServicesObject> services = new List<ServicesObject>();
            HttpClient hClient = _api.Initial();
            HttpResponseMessage res = await hClient.GetAsync("api/ServicesObject");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                services = JsonConvert.DeserializeObject<List<ServicesObject>>(result);
            }
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicesObject servicesObject)
        {
            if (ModelState.IsValid)
            {
                HttpClient hClient = _api.Initial();
                HttpResponseMessage res = await hClient.PostAsJsonAsync("api/ServicesObject", servicesObject);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            return View(servicesObject);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ServicesObject services = new ServicesObject();
            HttpClient hClient = _api.Initial();
            HttpResponseMessage res = await hClient.GetAsync($"api/ServicesObject/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                services = JsonConvert.DeserializeObject<ServicesObject>(result);
            }
            return View(services);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServicesObject services)
        {
            if (ModelState.IsValid)
            {
                HttpClient hClient = _api.Initial();
                HttpResponseMessage res = await hClient.PutAsJsonAsync($"api/ServicesObject/{services.Id}", services);
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    services = JsonConvert.DeserializeObject<ServicesObject>(result);
                    return RedirectToAction("Index");
                }
            }
            return View(services);
        }
        

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ServicesObject services = new ServicesObject();
            HttpClient hClient = _api.Initial();
            HttpResponseMessage res = await hClient.GetAsync($"api/ServicesObject/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                services = JsonConvert.DeserializeObject<ServicesObject>(result);
            }
            return View(services);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                HttpClient hClient = _api.Initial();
                HttpResponseMessage res = await hClient.DeleteAsync($"api/ServicesObject/{id}");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    //client = JsonConvert.DeserializeObject<Client>(result);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
