using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Repository.Hotel_Details_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository.Room_Details_Services
{
    public class RoomDetailsServices:IRoomDetailsServices
    {
        private readonly HotelDBContext _context;
        public RoomDetailsServices(HotelDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RoomDetails>> GetRoomDetails()
        {
            return await _context.RoomDetails.ToListAsync();//return all the values in the table
        }
        public async Task<RoomDetails> GetRoomDetails(int id)
        {
            var reqDetail = await _context.RoomDetails.FirstOrDefaultAsync(val => val.RoomId == id);// retur
            if (reqDetail == null)
            {
                throw new ArithmeticException("Not available");
            }
            return reqDetail;
        }

        public async Task<List<string>> ByPriceRange(int chargeperday)
        {
            var join = await (from room in _context.RoomDetails
                              join hotel in _context.HotelDetails on room.HotelId equals hotel.HotelId where room.ChargePerDay< chargeperday
                              select hotel.HotelName
                             ).ToListAsync();
            return join;
        }
       


    }
}
