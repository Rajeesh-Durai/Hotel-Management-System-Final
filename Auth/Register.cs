using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Register
    {
        [Key]
        public int RegId { get; set; }
        public string? Name { get; set; }

        public string EmailId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Roles { get; set; } = string.Empty;
    }
}
