using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Repository.Booking_Details_Services;
using Microsoft.AspNetCore.Authorization;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailsController : ControllerBase
    {
        private readonly IBookingDetailsServices _context;
        public BookingDetailsController(IBookingDetailsServices context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetails>>> GetBookingDetails()
        {
            try
            {
                var details = await _context.GetBookingDetails();
                return Ok(details);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/BookingDetails/5
        [Authorize(Roles ="user")]
       [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetails>> GetBookingDetails(int id)
        {
            try
            {
                var reqDetail = await _context.GetBookingDetails(id);
                return Ok(reqDetail);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

       
    }
}
