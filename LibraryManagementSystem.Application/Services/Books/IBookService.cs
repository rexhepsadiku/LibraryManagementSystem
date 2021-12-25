using LibraryManagementSystem.Application.Dtos.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Services.Books
{
    public interface IBookService
    {
        Task<IEnumerable<GetBookDto>> GetAll(string search);
        Task<GetBookDto> GetById(int id);
        void Create(CreateBookDto book);
        void Update(UpdateBookDto book);
        void Delete(int id);
        Task<IEnumerable<GetBookDto>> GetBooksByAuthor(int authorId, string search);
        Task<IEnumerable<GetBookDto>> GetBooksByCustomer(int customerId, string search);
        Task<IEnumerable<GetBookDto>> GetBooksByUser(string userId, string search);
    }
}
