using AutoMapper;
using LibraryManagementSystem.Application.Dtos.Authors;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Create(CreateAuthorDto author)
        {
            var authorCreate = _mapper.Map<Author>(author);
            _repository.Create(authorCreate);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<IEnumerable<GetAuthorDto>> GetAll(string search)
        {
            var authors = await _repository.GetAll(search);
            return _mapper.Map<IEnumerable<GetAuthorDto>>(authors);
        }

        public async Task<GetAuthorDto> GetById(int id)
        {
            var author = await _repository.GetById(id);
            return _mapper.Map<GetAuthorDto>(author);
        }

        public void Update(UpdateAuthorDto author)
        {
            var updatedAuthor = _mapper.Map<Author>(author);
            _repository.Update(updatedAuthor);
        }

        public async Task<IEnumerable<GetAuthorDto>> GetAuthorsByUser(string userId, string search)
        {
            var authors = await _repository.GetAll(search);
            var authorsByUser = authors.Where(x => x.UserId == userId);
            return _mapper.Map<IEnumerable<GetAuthorDto>>(authorsByUser);
        }
    }
}
