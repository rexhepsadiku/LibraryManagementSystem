using LibraryManagementSystem.Application.Dtos.Borrows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Services.Borrows
{
    public interface IBorrowService
    {
        Task<IEnumerable<GetBorrowDto>> GetAll(string search);
        Task<GetBorrowDto> GetById(int id);
        void Create(CreateBorrowDto borrow);
        void Update(UpdateBorrowDto borrow);
        void Delete(int id);
    }
}
