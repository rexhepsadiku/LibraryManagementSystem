using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Persistence.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Create(Book book)
        {
            book.CreatedAt = DateTime.Now;
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _db.Books.FirstOrDefault(x => x.Id == id);
            _db.Books.Remove(book);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Book>> GetAll(string search)
        {
            if (search != null)
            {
                return await _db.Books.Where(x => x.Title.Contains(search))
                    .Include(x => x.Author)
                    .ToListAsync();
            }
            else
            {
                return await _db.Books
                .OrderByDescending(x => x.Id)
                .Include(x => x.Author)
                .ToListAsync();
            }
        }

        public async Task<Book> GetById(int id)
        {
            return await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Book book)
        {
            book.UpdatetAt = DateTime.Now;
            _db.Books.Update(book);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthor(int authorId, string search)
        {
            if (search != null)
            {
                return await _db.Books
                    .Where(x => x.AuthorId == authorId && x.Title.Contains(search))
                    .ToListAsync();
            }
            else
            {
                return await _db.Books
                    .Where(x => x.AuthorId == authorId)
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetBooksByCustomer(int customerId, string search)
        {
            if (search != null)
            {
                return await _db.Borrows
                    .Where(x => x.CustomerId == customerId && x.Book.Title.Contains(search))
                    .Select(x => x.Book).ToListAsync();
            }
            else
            {
                return await _db.Borrows
                    .Where(x => x.CustomerId == customerId)
                    .Select(x => x.Book)
                    .ToListAsync();
            }
        }
    }
}
