using BookingServices.Data;
using BookingServices.Model;
using BookingServices.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _db;

        public BookingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            try
            {
                await _db.Booking.AddAsync(booking);
                await _db.SaveChangesAsync();
                return await _db.Booking.FindAsync(booking.Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public async Task<(bool, string)> DeleteBookingAsync(Booking booking)
        //{
        //    try
        //    {
        //        var dbBooking = await _db.Booking.FindAsync(booking.Id);
        //        if (dbBooking == null)
        //        {
        //            return (false, "Бронь не найдена");
        //        }
        //        _db.Booking.Remove(booking);
        //        await _db.SaveChangesAsync();
        //        return (true, "Бронь удалена");
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message);
        //    }
        //}

        //public async Task<Booking> GetBookingAsync(Guid id)
        //{
        //    try
        //    {
        //        return await _db.Booking.Include(x => x.servicesObject).FirstOrDefaultAsync(i => i.Id == id);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //public async Task<Booking> UpdateBookingAsync(Booking booking)
        //{
        //    try
        //    {
        //        _db.Entry(booking).State = EntityState.Modified;
        //        await _db.SaveChangesAsync();
        //        return booking;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<List<Booking>> GetBookingsAsync()
        //{
        //    try
        //    {
        //        return await _db.Booking.Include(x => x.servicesObject).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


    }
}
