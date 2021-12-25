using System;

namespace LibraryManagementSystem.Shared.Models.Borrows
{
    public class CreateBorrowModel
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
    }
}
