using HotelBooking.Models;

namespace HotelBooking.Repository.Room_Details_Services
{
    public interface IRoomDetailsServices
    {
        Task<IEnumerable<RoomDetails>> GetRoomDetails();
        Task<RoomDetails> GetRoomDetails(int id);
        Task<List<string>> ByPriceRange(int chargeperday);

    }
}
