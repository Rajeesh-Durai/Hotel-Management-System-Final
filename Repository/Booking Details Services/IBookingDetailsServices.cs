using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Repository.Booking_Details_Services
{
    public interface IBookingDetailsServices
    {
        Task<IEnumerable<BookingDetails>> GetBookingDetails();
        Task<BookingDetails> GetBookingDetails(int id);

    }
}
