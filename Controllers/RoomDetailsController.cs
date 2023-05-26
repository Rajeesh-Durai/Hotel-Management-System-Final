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
using HotelBooking.Repository.Room_Details_Services;
using Microsoft.AspNetCore.Authorization;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomDetailsController : ControllerBase
    {
        private readonly IRoomDetailsServices _context;

        public RoomDetailsController(IRoomDetailsServices context)
        {
            _context = context;
        }
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "user")]
        // GET: api/RoomDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDetails>>> GetRoomDetails()
        {
            try
            {
                var details = await _context.GetRoomDetails();
                return Ok(details);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }

        }
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "user")]
        // GET: api/RoomDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDetails>> GetRoomDetails(int id)
        {
            try
            {
                var reqDetail = await _context.GetRoomDetails(id);
                return Ok(reqDetail);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }

        }
        [Authorize(Roles ="user")]
        [HttpGet("{chargeperday}")]
        public async Task<ActionResult<List<string>>> ByPriceRange(int chargeperday)
        {
            try
            {
                var reqDetail = await _context.ByPriceRange(chargeperday);
                return Ok(reqDetail);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }

        }
        

    }
}
