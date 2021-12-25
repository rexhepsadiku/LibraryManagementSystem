using System;

namespace LibraryManagementSystem.Application.Dtos.Borrows
{
    public class CreateBorrowDto
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
    }
}
