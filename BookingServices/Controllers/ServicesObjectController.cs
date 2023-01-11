using BookingServices.Model;
using BookingServices.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesObjectController : ControllerBase
    {
        private readonly IServicesObjectRepository _servicesObjectRepository;

        public ServicesObjectController(IServicesObjectRepository servicesObjectRepository)
        {
            _servicesObjectRepository = servicesObjectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetServicesObjects()
        {
            var services = await _servicesObjectRepository.GetServicesObjectsAsync();
            if(services == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicesObject(Guid id, bool includeBooking = false)
        {
            ServicesObject servicesObject = await _servicesObjectRepository.GetServicesObjectAsync(id, includeBooking);
            if(servicesObject == null)
            {
                return NoContent();
            }
            return StatusCode(StatusCodes.Status200OK, servicesObject);
        }
        // GET: ServicesObjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicesObjectController/Create
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

        // GET: ServicesObjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicesObjectController/Edit/5
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

        // GET: ServicesObjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicesObjectController/Delete/5
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
