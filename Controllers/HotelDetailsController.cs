using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Repository.Hotel_Details_Services;
using Microsoft.AspNetCore.Authorization;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDetailsController : ControllerBase
    {
        private readonly IHotelDetailsServices _context;

        public HotelDetailsController(IHotelDetailsServices context)
        {
            _context = context;
        }
        [Authorize(Roles ="admin")]
        [Authorize(Roles ="user")]
        // GET: api/HotelDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDetails>>> GetHotelDetails()
        {
            try
            {
                var details = await _context.GetHotelDetails();
                return Ok(details);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }

        }
        [Authorize(Roles = "admin")]
        [Authorize(Roles ="user")]
        // GET: api/HotelDetails/5
        [HttpGet("Get Hotel Details")]
            public async Task<ActionResult<HotelDetails>> GetHotelDetails(int id)
            {
                try
                {
                    var reqDetail = await _context.GetHotelDetails(id);
                    return Ok(reqDetail);
                }
                catch (ArithmeticException ex)
                {
                    return NotFound(ex.Message);

                }
            }
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "user")]
        // GET: api/HotelDetails/5
        [HttpGet("By Location")]
        public async Task<ActionResult<HotelDetails>> ByLocation(string location)
        {
            try
            {
                var reqDetail = await _context.ByLocation(location);
                return Ok(reqDetail);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // PUT: api/HotelDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "admin")]
        [HttpPut("Update Hotel Details")]
           public async Task<IActionResult> PutHotelDetails(int id, HotelDetails hotelDetails)
           {
            try
            {
                var update = await _context.PutHotelDetails( id, hotelDetails);
                return Ok(update);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }
        
        // POST: api/HotelDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "admin")]
        [HttpPost]
            public async Task<ActionResult<HotelDetails>> PostHotelDetails(HotelDetails hotelDetails)
            {
            try
            {
                var add = await _context.PostHotelDetails(hotelDetails);
                return Ok(add);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // DELETE: api/HotelDetails/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteHotelDetails(int id)
            {
                    try
                    {
                        var delete = await _context.DeleteHotelDetails(id);
                        return NoContent();
                    }
                    catch (ArithmeticException ex)
                    {
                        return NotFound(ex.Message);

                    }
            }

        [Authorize(Roles = "user")]
        // GET: api/HotelDetails/5
        [HttpGet("Total Rooms")]
        public async Task<ActionResult<int>> TotalRooms(string name)
        {
            try
            {
                var count = await _context.TotalRooms(name);
                return Ok(count);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }
        [Authorize(Roles = "user")]
        // GET: api/HotelDetails/5
        [HttpGet("Room Booking")]
        public async Task<ActionResult<List<BookingTable>>> RoomBooking(string hotelname)
        {
            try
            {
                var booking = await _context.RoomBooking(hotelname);
                return Ok(booking);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }
    }
}
