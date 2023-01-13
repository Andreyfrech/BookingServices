using BookingServices.Model;

namespace BookingServices.Repository.IRepository
{
    public interface IBookingRepository
    {
        Task<Booking> AddBookingAsync(Booking booking);


    }
}
