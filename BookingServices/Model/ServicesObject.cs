using System.ComponentModel.DataAnnotations;

namespace BookingServices.Model
{
    public class ServicesObject
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Amount { get; set; }

    }
}
