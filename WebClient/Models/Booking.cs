using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid ServicesId { get; set; }
        public int? Amount { get; set; }

        [ForeignKey("ServicesId")]
        public virtual ServicesObject? servicesObject { get; set; }
    }
}
