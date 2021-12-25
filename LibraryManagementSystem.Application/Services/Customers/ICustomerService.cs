using LibraryManagementSystem.Application.Dtos.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Services.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<GetCustomerDto>> GetAll(string search);
        Task<GetCustomerDto> GetById(int id);
        void Create(CreateCustomerDto customer);
        void Update(UpdateCustomerDto customer);
        void Delete(int id);
        int RandomLibraryId();
        void SendEmail(string emailTo, string sms);
        Task<IEnumerable<GetCustomerDto>> GetCustomersByUser(string userId, string search);
    }
}
