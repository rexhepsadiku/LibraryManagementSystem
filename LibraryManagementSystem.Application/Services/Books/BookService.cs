using AutoMapper;
using LibraryManagementSystem.Application.Dtos.Books;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Create(CreateBookDto book)
        {
            var bookCreate = _mapper.Map<Book>(book);
            _repository.Create(bookCreate);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<IEnumerable<GetBookDto>> GetAll(string search)
        {
            var books = await _repository.GetAll(search);
            return _mapper.Map<IEnumerable<GetBookDto>>(books);
        }

        public async Task<IEnumerable<GetBookDto>> GetBooksByAuthor(int authorId, string search)
        {
            var books = await _repository.GetBooksByAuthor(authorId, search);
            return _mapper.Map<IEnumerable<GetBookDto>>(books);
        }

        public async Task<IEnumerable<GetBookDto>> GetBooksByCustomer(int customerId, string search)
        {
            var books = await _repository.GetBooksByCustomer(customerId, search);
            return _mapper.Map<IEnumerable<GetBookDto>>(books);
        }

        public async Task<IEnumerable<GetBookDto>> GetBooksByUser(string userId, string search)
        {
            var books = await _repository.GetAll(search);
            var bookByUser = books.Where(x => x.UserId == userId);
            return _mapper.Map<IEnumerable<GetBookDto>>(bookByUser);
        }

        public async Task<GetBookDto> GetById(int id)
        {
            var book = await _repository.GetById(id);
            return _mapper.Map<GetBookDto>(book);
        }

        public void Update(UpdateBookDto book)
        {
            var updatedBook = _mapper.Map<Book>(book);
            _repository.Update(updatedBook);
        }
    }
}
