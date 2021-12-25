using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Persistence.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _db;
        public AuthorRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Create(Author author)
        {
            author.CreatedAt = DateTime.Now;
            _db.Authors.Add(author);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _db.Authors.FirstOrDefault(x => x.Id == id);
            _db.Authors.Remove(author);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Author>> GetAll(string search)
        {
            if(search != null)
            {
                return await _db.Authors.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search)).ToListAsync();
            }
            else
            {
                return await _db.Authors
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
            }
        }

        public async Task<Author> GetById(int id)
        {
            return await _db.Authors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Author author)
        {
            author.UpdatetAt = DateTime.Now;
            _db.Authors.Update(author);
            _db.SaveChanges();
        }
    }
}
