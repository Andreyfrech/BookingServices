using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class ServicesObject
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Amount { get; set; }

        public List<Booking>? Bookings { get; set; }
    }
}
