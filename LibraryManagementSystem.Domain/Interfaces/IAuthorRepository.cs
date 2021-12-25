using LibraryManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll(string search);
        Task<Author> GetById(int id);
        void Create(Author author);
        void Update(Author author);
        void Delete(int id);
    }
}
