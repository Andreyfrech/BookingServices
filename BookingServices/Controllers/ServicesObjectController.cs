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
        private readonly IBookingRepository _bookingRepository;

        public ServicesObjectController(IServicesObjectRepository servicesObjectRepository, IBookingRepository bookingRepository)
        {
            _servicesObjectRepository = servicesObjectRepository;
            _bookingRepository = bookingRepository;
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
        [HttpPost]
        public async Task<ActionResult> AddServicesObject(ServicesObject servicesObject)
        {
            var dbServices = await _servicesObjectRepository.AddServicesObjectAsync(servicesObject);
            if(dbServices == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetServicesObject", new { id = dbServices.Id }, servicesObject);

        }
        [HttpPost("{id}")]
        public async Task<ActionResult> Booking(Guid id, Booking booking)
        {
            var dbbooking = await _bookingRepository.AddBookingAsync(booking);
            if (dbbooking == null)
            {
                return NotFound();
            }
            ServicesObject servicesObject = await _servicesObjectRepository.GetServicesObjectAsync(id, false);
            if((servicesObject.Amount - booking.Amount) >= 0)
            servicesObject.Amount -= booking.Amount;
            ServicesObject dbServices = await _servicesObjectRepository.UpdateServicesObjectAsync(servicesObject);
            if (dbServices == null)
            {
                return NotFound();
            }
            return CreatedAtAction("AddBooking", new { Id = dbbooking.Id }, booking);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServicesObject(Guid id, ServicesObject servicesObject)
        {
            if (id != servicesObject.Id)
            {
                return BadRequest();
            }

            ServicesObject dbServices = await _servicesObjectRepository.UpdateServicesObjectAsync(servicesObject);
            if (dbServices == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicesObject(Guid id)
        {
            var services = await _servicesObjectRepository.GetServicesObjectAsync(id, false);
            (bool status, string message) = await _servicesObjectRepository.DeleteServicesObjectAsync(services);

            if (status == false)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, services);
        }
    }
}
