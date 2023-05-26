using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data
{
    public class HotelDBContext:DbContext
    {
        public HotelDBContext(DbContextOptions<HotelDBContext> options) : base(options) { }

        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<HotelDetails> HotelDetails { get; set; }
        public DbSet<RoomDetails> RoomDetails { get; set; }

        public DbSet<BookingDetails> BookingDetails { get; set; }
    }
}
