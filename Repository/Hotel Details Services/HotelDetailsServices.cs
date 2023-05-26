using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository.Hotel_Details_Services
{
    public class HotelDetailsServices:IHotelDetailsServices
    {
        private readonly HotelDBContext _context;
        public HotelDetailsServices(HotelDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HotelDetails>> GetHotelDetails()
        {
            return await _context.HotelDetails.ToListAsync();//return all the values in the table
        }
        public async Task<HotelDetails> GetHotelDetails(int id)
        {
            var reqDetail= await _context.HotelDetails.FirstOrDefaultAsync(val=> val.HotelId==id);// return the data which matches with input
            if (reqDetail==null) 
            {
                throw new ArithmeticException("Not available");
            }
            return reqDetail;
        }
        public async Task<List<HotelDetails>> PutHotelDetails(int id, HotelDetails hotelDetails)
        {
            var update = await _context.HotelDetails.FindAsync(id);
            if (update == null)
            {
                throw new ArithmeticException("Not available");
            }
            update.HotelId = hotelDetails.HotelId;
            update.HotelName = hotelDetails.HotelName;
            update.HotelContactNo= hotelDetails.HotelContactNo;
            update.HotelLocation = hotelDetails.HotelLocation;
            update.RoomDetails = hotelDetails.RoomDetails;
            await _context.SaveChangesAsync();
            return await _context.HotelDetails.ToListAsync();
        }
        public async Task<HotelDetails> PostHotelDetails(HotelDetails hotelDetails)
        {
            await _context.HotelDetails.AddAsync(hotelDetails);
            await _context.SaveChangesAsync();
            return hotelDetails;
        }
        public async Task<HotelDetails>? DeleteHotelDetails(int id)
        {
            var delete= await _context.HotelDetails.FirstOrDefaultAsync(x=> x.HotelId== id);
            _context.HotelDetails.Remove(delete);
            await _context.SaveChangesAsync();
            return delete;
        }
    
        //Filtering Hotels based on Location
        public async Task<object>? ByLocation(string location)
        {
            var reqHotel=await _context.HotelDetails.FirstOrDefaultAsync(x=>x.HotelLocation==location);
            if(reqHotel==null)
            {
                throw new ArithmeticException("Not available");
            }
            return reqHotel.HotelName;  
        }
        //counting the total number of rooms available by passing hotel name and joining bot the table by HotelId and counting the RoomId
        public async Task<int> TotalRooms(string name)
        {
            var total = await (from hotel in _context.HotelDetails
                              join room in _context.RoomDetails on hotel.HotelId equals room.HotelId where hotel.RoomsAvailable == "Available" && hotel.HotelName==name
                              select room.RoomId 
                             ).ToListAsync();
           
            return total.Count;
        }
        //Booking the tickets and displaying it in a buffered table named BookingTable and returning it
        public async Task<List<BookingTable>> RoomBooking(string name)
        {
            var booking=  (from room in _context.RoomDetails
                                join hotel in _context.HotelDetails on room.HotelId equals hotel.HotelId
                                join book in _context.BookingDetails on room.RoomId equals book.RoomId
                                where hotel.RoomsAvailable== "Available" && hotel.HotelName== name
                                select new BookingTable()
                                {
                                    BookingId=book.BookingId,
                                    HotelName=hotel.HotelName,
                                    BookingStatus="Success",
                                    RoomId=room.RoomId

                                }).ToListAsync();
            return await booking;
        }
       
    }
}
