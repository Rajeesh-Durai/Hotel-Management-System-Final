using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class CustomerDetails
    {
        [Key]
        public int CustId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string CustomerPhoneNo { get; set; }= string.Empty;
        [Required]
        public string CustomerAddress { get; set; }= string.Empty;

        public ICollection<BookingDetails>? BookingDetails { get; set; }
    }
}
