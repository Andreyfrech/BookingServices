using BookingServices.Model;
using BookingServices.Repository;
using BookingServices.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IServicesObjectRepository _servicesObjectRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IServicesObjectRepository servicesObjectRepository, IBookingRepository bookingRepository)
        {
            _servicesObjectRepository = servicesObjectRepository;
            _bookingRepository = bookingRepository;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetBookings()
        //{
        //    var booking = await _bookingRepository.GetBookingsAsync();
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }
        //    return StatusCode(StatusCodes.Status200OK, booking);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetBooking(Guid id)
        //{
        //    Booking booking = await _bookingRepository.GetBookingAsync(id);
        //    if (booking == null)
        //    {
        //        return NoContent();
        //    }
        //    return StatusCode(StatusCodes.Status200OK, booking);
        //}

        [HttpPost]
        public async Task<ActionResult> AddBooking(Booking booking)
        {
            var dbbooking = await _bookingRepository.AddBookingAsync(booking);
            if (dbbooking == null)
            {
                return NotFound();
            }
            ServicesObject servicesObject = await _servicesObjectRepository.GetServicesObjectAsync(booking.ServicesId, false);
            if ((servicesObject.Amount - booking.Amount) >= 0)
                servicesObject.Amount -= booking.Amount;
            ServicesObject dbServices = await _servicesObjectRepository.UpdateServicesObjectAsync(servicesObject);
            if (dbServices == null)
            {
                return NotFound();
            }
            return CreatedAtAction("AddBooking", new { Id = dbbooking.Id }, booking);

        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateBooking(Guid id, Booking booking)
        //{
        //    if (id != booking.Id)
        //    {
        //        return BadRequest();
        //    }

        //    Booking dbBooking = await _bookingRepository.UpdateBookingAsync(booking);
        //    if (dbBooking == null)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBooking(Guid id)
        //{
        //    var booking = await _bookingRepository.GetBookingAsync(id);
        //    (bool status, string message) = await _bookingRepository.DeleteBookingAsync(booking);

        //    if (status == false)
        //    {
        //        return NotFound();
        //    }
        //    return StatusCode(StatusCodes.Status200OK, booking);
        //}
    }
}
