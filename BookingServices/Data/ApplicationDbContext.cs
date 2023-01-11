using BookingServices.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace BookingServices.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Booking> Booking { get; set; }
        public DbSet<ServicesObject> ServicesObject  { get; set; }
    }
}
