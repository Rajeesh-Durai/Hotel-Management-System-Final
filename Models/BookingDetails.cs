using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class BookingDetails
    {
        [Key]
        public int BookingId { get; set; }
        [ForeignKey(nameof(CustomerDetails))]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(RoomDetails))]
        public int RoomId { get; set;}
    }
}
