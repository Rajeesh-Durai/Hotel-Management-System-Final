using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository.Booking_Details_Services
{
    public class BookingDetailsServices :IBookingDetailsServices
    {
        private readonly HotelDBContext _context;
        public BookingDetailsServices(HotelDBContext context)
        {
            _context = context;
        }
       public async Task<IEnumerable<BookingDetails>> GetBookingDetails()
        {
            return await _context.BookingDetails.ToListAsync();
        }
        public async Task<BookingDetails> GetBookingDetails(int id)
        {
            var reqDetail = await _context.BookingDetails.FirstOrDefaultAsync(val => val.BookingId == id);// return the data which matches with input
            if (reqDetail == null)
            {
                throw new ArithmeticException("Not available");
            }
            return reqDetail;
        }
 
    }
}
