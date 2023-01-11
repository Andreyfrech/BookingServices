using BookingServices.Model;

namespace BookingServices.Repository.IRepository
{
    public interface IServicesObjectRepository
    {
        Task<List<ServicesObject>> GetServicesObjectsAsync();
        Task<ServicesObject> GetServicesObjectAsync(Guid id, bool includeBooking = false);
        Task<ServicesObject> AddServicesObjectAsync(ServicesObject ServicesObject);
        Task<ServicesObject> UpdateServicesObjectAsync(ServicesObject ServicesObject);
        Task<(bool, string)> DeleteServicesObjectAsync(ServicesObject ServicesObject);
    }
}
