using LibraryManagementSystem.Application.Dtos.Books;
using LibraryManagementSystem.Application.Dtos.Customers;
using System;

namespace LibraryManagementSystem.Application.Dtos.Borrows
{
    public class GetBorrowDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public GetBookDto Book { get; set; }
        public int CustomerId { get; set; }
        public GetCustomerDto Customer { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
    }
}
