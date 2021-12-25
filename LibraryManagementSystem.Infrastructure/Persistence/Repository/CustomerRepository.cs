using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Persistence.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Create(Customer customer)
        {
            customer.CreatedAt = DateTime.Now;
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.Id == id);
            _db.Customers.Remove(customer);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Customer>> GetAll(string search)
        {
            if(search != null)
            {
                return await _db.Customers.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search)).ToListAsync();
            }
            else
            {
                return await _db.Customers
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
            }
        }

        public async Task<Customer> GetById(int id)
        {
            return await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Customer customer)
        {
            customer.UpdatetAt = DateTime.Now;
            _db.Customers.Update(customer);
            _db.SaveChanges();
        }
    }
}
