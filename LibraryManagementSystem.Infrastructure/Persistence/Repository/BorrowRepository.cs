using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Persistence.Repository
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly ApplicationDbContext _db;
        public BorrowRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Create(Borrow borrow)
        {
            borrow.CreatedAt = DateTime.Now;
            _db.Borrows.Add(borrow);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var borrow = _db.Borrows.FirstOrDefault(x => x.Id == id);
            _db.Borrows.Remove(borrow);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Borrow>> GetAll(string search)
        {
            if(search != null)
            {
                return await _db.Borrows.Where(x => x.Book.Title.Contains(search) || x.Customer.FirstName.Contains(search))
                    .Include(x => x.Book)
                    .Include(x => x.Customer)
                    .ToArrayAsync();
            }
            else
            {
                return await _db.Borrows
                .OrderByDescending(x => x.Id)
                .Include(x => x.Book)
                .Include(x => x.Customer)
                .ToListAsync();
            }
            
        }

        public async Task<Borrow> GetById(int id)
        {
            return await _db.Borrows.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Borrow borrow)
        {
            borrow.UpdatetAt = DateTime.Now;
            _db.Borrows.Update(borrow);
            _db.SaveChanges();
        }
    }
}
