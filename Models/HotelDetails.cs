using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class HotelDetails
    {
        [Key]
        public int HotelId { get; set; }
        [Required]
        public string HotelName { get; set; } = string.Empty;
        [Required]
        public string HotelLocation { get; set;} = string.Empty;
        [Required]
        [Phone]
        public string HotelContactNo { get; set; }= string.Empty;
        [Required]
        public string RoomsAvailable { get; set; } = string.Empty;  
        public ICollection<RoomDetails>? RoomDetails { get; set; }
    }
}
