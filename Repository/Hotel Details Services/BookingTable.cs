namespace HotelBooking.Repository.Hotel_Details_Services
{
    public class BookingTable
    {
        public int BookingId { get; set; }
        public string BookingStatus { get; set;} = string.Empty;
        public string HotelName { get; set; } = string.Empty;
        public int RoomId { get; set;}
    }
}
