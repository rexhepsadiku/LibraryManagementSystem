using LibraryManagementSystem.Shared.Models.Books;
using LibraryManagementSystem.Shared.Models.Customers;
using System;

namespace LibraryManagementSystem.Shared.Models.Borrows
{
    public class GetBorrowModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public GetBookModel Book { get; set; }
        public int CustomerId { get; set; }
        public GetCustomerModel Customer { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
    }
}
