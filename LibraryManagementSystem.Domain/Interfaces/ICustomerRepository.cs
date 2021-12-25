using LibraryManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll(string search);
        Task<Customer> GetById(int id);
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}
