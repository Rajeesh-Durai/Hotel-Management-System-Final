
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data
{
    public class RegContext:DbContext
    {
        public RegContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Register> Registers { get; set; }
    }
}
