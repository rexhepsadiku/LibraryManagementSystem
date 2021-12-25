using LibraryManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll(string search);
        Task<Book> GetById(int id);
        void Create(Book book);
        void Update(Book book);
        void Delete(int id);
        Task<IEnumerable<Book>> GetBooksByAuthor(int authorId, string search);
        Task<IEnumerable<Book>> GetBooksByCustomer(int customerId, string search);
    }
}
