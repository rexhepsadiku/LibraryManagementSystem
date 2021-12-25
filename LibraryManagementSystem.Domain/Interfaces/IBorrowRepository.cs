using LibraryManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface IBorrowRepository
    {
        Task<IEnumerable<Borrow>> GetAll(string search);
        Task<Borrow> GetById(int id);
        void Create(Borrow borrow);
        void Update(Borrow borrow);
        void Delete(int id);
    }
}
