using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Repository.Customer_Details_Services;
using Microsoft.AspNetCore.Authorization;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly ICustomerDetailsServices _context;

        public CustomerDetailsController(ICustomerDetailsServices context)
        {
            _context = context;
        }

        // GET: api/CustomerDetails
        [Authorize(Roles ="admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDetails>>> GetCustomerDetails()
        {
            try
            {
                var details = await _context.GetCustomerDetails();
                return Ok(details);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }
        [Authorize(Roles = "admin")]
        // GET: api/CustomerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetails>> GetCustomerDetails(int id)
        {
            try
            {
                var reqDetail = await _context.GetCustomerDetails(id);
                return Ok(reqDetail);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }


        [Authorize(Roles ="user")]
        // POST: api/CustomerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerDetails>> PostCustomerDetails(CustomerDetails customerDetails)
        {
            try
            {
                var add = await _context.PostCustomerDetails(customerDetails);
                return Ok(add);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

     
    }
}
