using HotelBooking.Models;

namespace HotelBooking.Repository.Customer_Details_Services
{
    public interface ICustomerDetailsServices
    {
        Task<IEnumerable<CustomerDetails>> GetCustomerDetails();
        Task<CustomerDetails> GetCustomerDetails(int id);
        Task<CustomerDetails> PostCustomerDetails(CustomerDetails customerDetails);
    }
}
