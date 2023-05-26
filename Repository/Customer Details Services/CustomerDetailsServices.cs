using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository.Customer_Details_Services
{
    public class CustomerDetailsServices:ICustomerDetailsServices
    {
        private readonly HotelDBContext _context;
        public CustomerDetailsServices(HotelDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CustomerDetails>> GetCustomerDetails()
        {
            return await _context.CustomerDetails.ToListAsync();//return all the values in the table

        }
        public async Task<CustomerDetails> GetCustomerDetails(int id)
        {
            var reqDetail = await _context.CustomerDetails.FirstOrDefaultAsync(val => val.CustId == id);// retur
            if (reqDetail == null)
            {
                throw new ArithmeticException("Not available");
            }
            return reqDetail;
        }
        public async Task<CustomerDetails> PostCustomerDetails(CustomerDetails customerDetails)
        {
            await _context.CustomerDetails.AddAsync(customerDetails);
            await _context.SaveChangesAsync();
            return customerDetails;
        }

    }
}
