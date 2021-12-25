using LibraryManagementSystem.Domain.Entities.Base;
using System;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Borrow : BaseEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
    }
}
