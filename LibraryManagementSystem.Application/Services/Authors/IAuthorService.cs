using LibraryManagementSystem.Application.Dtos.Authors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Services.Authors
{
    public interface IAuthorService
    {
        Task<IEnumerable<GetAuthorDto>> GetAll(string search);
        Task<GetAuthorDto> GetById(int id);
        void Create(CreateAuthorDto author);
        void Update(UpdateAuthorDto author);
        void Delete(int id);
        Task<IEnumerable<GetAuthorDto>> GetAuthorsByUser(string userId, string search);
    }
}
