using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Repository.Hotel_Details_Services
{
    public interface IHotelDetailsServices
    {
        Task<IEnumerable<HotelDetails>> GetHotelDetails();
        Task<HotelDetails> GetHotelDetails(int id);
        Task<List<HotelDetails>> PutHotelDetails(int id, HotelDetails hotelDetails);

        Task<HotelDetails> PostHotelDetails(HotelDetails hotelDetails);
        Task<HotelDetails>? DeleteHotelDetails(int id);
        Task<object>? ByLocation(string location);
        Task<int> TotalRooms(string name);

        Task<List<BookingTable>> RoomBooking(string name);
    }
}
