using BookingServices.Data;
using BookingServices.Model;
using BookingServices.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Repository
{
    public class ServicesObjectRepository : IServicesObjectRepository
    { 
        private readonly ApplicationDbContext _db;

        public ServicesObjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ServicesObject> AddServicesObjectAsync(ServicesObject ServicesObject)
        {
            try
            {
                await _db.ServicesObject.AddAsync(ServicesObject);
                await _db.SaveChangesAsync();
                return await _db.ServicesObject.FindAsync(ServicesObject.Id);
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteServicesObjectAsync(ServicesObject ServicesObject)
        {
            try
            {
                var dbServicesObject = await _db.ServicesObject.FindAsync(ServicesObject.Id);
                if(dbServicesObject == null)
                {
                    return (false, "Оборудование не найдено");
                }
                _db.ServicesObject.Remove(dbServicesObject);
                await _db.SaveChangesAsync();
                return (true, "Оборудование удалено");
            }
            catch(Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<ServicesObject> GetServicesObjectAsync(Guid? id, bool includeBooking = false)
        {
            try
            {
                return await _db.ServicesObject.FindAsync(id);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ServicesObject>> GetServicesObjectsAsync()
        {
            try
            {
                return await _db.ServicesObject.ToListAsync();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<ServicesObject> UpdateServicesObjectAsync(ServicesObject ServicesObject)
        {
            try
            {
                _db.Entry(ServicesObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return ServicesObject;
            }
            catch(Exception ex) 
            {
                return null;
            }
        }
    }
}
