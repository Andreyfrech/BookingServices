using BookingServices.Model;

namespace BookingServices.Repository.IRepository
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetBookingsAsync();
        Task<Booking> GetBookingAsync(Guid id);
        Task<Booking> AddBookingAsync(Booking booking);
        Task<Booking> UpdateBookingAsync(Booking booking);
        Task<(bool, string)> DeleteBookingAsync(Booking booking);

    }
}
