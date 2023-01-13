using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Cryptography.Xml;
using WebClient.Helper;
using WebClient.Models;
using WebClient.Models.ViewModel;

namespace WebClient.Controllers
{
    public class BookingController : Controller
    {
        ServicesBookingApi _api = new ServicesBookingApi();

        public async Task<IActionResult> Booking(Guid? id)
        {
            ServicesObject services = new ServicesObject();
            HttpClient hClient = _api.Initial();
            HttpResponseMessage res = await hClient.GetAsync($"api/ServicesObject/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                services = JsonConvert.DeserializeObject<ServicesObject>(result);
            }

            BookingVM bookingVM = new BookingVM()
            {
                services = services, // new ServicesObject()
                //{
                //    Id = id.Value
                //},
                booking = new Booking()
                {
                    ServicesId = id.Value
                }
            };

            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Booking(BookingVM bookingVM)
        {
            if (ModelState.IsValid)
            {

                HttpClient hClient = _api.Initial();
                HttpResponseMessage res = await hClient.PostAsJsonAsync($"api/Booking", bookingVM.booking);
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    //var result = res.Content.ReadAsStringAsync().Result;
                    //services = JsonConvert.DeserializeObject<ServicesObject>(result);
                    return RedirectToAction("Index");
                }
            }
            return View(bookingVM);
        }

        //public async Task<IActionResult> Index()
        //{

        //    List<Booking> booking = new List<Booking>();
        //    HttpClient hClient = _api.Initial();
        //    HttpResponseMessage res = await hClient.GetAsync("api/Booking");

        //    if (res.IsSuccessStatusCode)
        //    {
        //        var result = res.Content.ReadAsStringAsync().Result;
        //        booking = JsonConvert.DeserializeObject<List<Booking>>(result);
        //    }

        //    return View(booking);
        //}

        //public async Task<IActionResult> Create(int? id)
        // {

        //     List<Booking> booking = new List<Booking>();
        //     HttpClient hClient = _api.Initial();
        //     HttpResponseMessage res = await hClient.GetAsync("api/Client");

        //     if (res.IsSuccessStatusCode)
        //     {
        //         var result = res.Content.ReadAsStringAsync().Result;
        //         booking = JsonConvert.DeserializeObject<List<Booking>>(result);
        //     }

        //     TransferVM transferVM = new TransferVM()
        //     {
        //         Transfer = new Transfer()
        //         {
        //             ClientId = (int)id
        //         },
        //         ClientSelectList = client.Select(i => new SelectListItem
        //         {
        //             Text = i.Name,
        //             Value = i.Id.ToString()
        //         })
        //     };
        //     if (ModelState.IsValid)
        //     {
        //         return View(transferVM);
        //     }
        //     return View(transferVM);
        // }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create(TransferVM transferVM)
        // {
        //     transferVM.Transfer.DateTimeTransfer = DateTime.Now;
        //     if (ModelState.IsValid)
        //     {
        //         HttpClient hClient = _api.Initial();
        //         HttpResponseMessage res = await hClient.PostAsJsonAsync("api/Transfer", transferVM.Transfer);
        //         res.EnsureSuccessStatusCode();
        //         return RedirectToAction("Index");
        //     }
        //     return View(transferVM);
        // }
    }
}
