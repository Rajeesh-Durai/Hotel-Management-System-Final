using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class RoomDetails
    {
        [Key]
        public int RoomId { get; set; }
        [ForeignKey(nameof(HotelDetails))]
        public int HotelId { get; set; }

        [Required]
        public string RoomType { get; set;} = string.Empty;
        [Required]
        public int ChargePerDay { get; set; }
        public ICollection<BookingDetails>? Bookings { get; set; }
    }
}
