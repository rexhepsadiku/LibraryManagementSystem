using AutoMapper;
using LibraryManagementSystem.Application.Dtos.Borrows;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Services.Borrows
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _repository;
        private readonly IMapper _mapper;
        public BorrowService(IBorrowRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Create(CreateBorrowDto borrow)
        {
            var borrowCreate = _mapper.Map<Borrow>(borrow);
            _repository.Create(borrowCreate);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<IEnumerable<GetBorrowDto>> GetAll(string search)
        {
            var borrows = await _repository.GetAll(search);
            return _mapper.Map<IEnumerable<GetBorrowDto>>(borrows);
        }

        public async Task<GetBorrowDto> GetById(int id)
        {
            var borrow = await _repository.GetById(id);
            return _mapper.Map<GetBorrowDto>(borrow);
        }

        public void Update(UpdateBorrowDto borrow)
        {
            var updatedBorrow = _mapper.Map<Borrow>(borrow);
            _repository.Update(updatedBorrow);
        }
    }
}
