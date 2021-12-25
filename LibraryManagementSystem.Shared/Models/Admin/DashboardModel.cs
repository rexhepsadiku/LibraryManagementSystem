using LibraryManagementSystem.Shared.Models.Authors;
using LibraryManagementSystem.Shared.Models.Books;
using LibraryManagementSystem.Shared.Models.Borrows;
using LibraryManagementSystem.Shared.Models.Customers;
using System.Collections.Generic;

namespace LibraryManagementSystem.Shared.Models.Admin
{
    public class DashboardModel
    {
        public IEnumerable<GetBookModel> Books { get; set; }
        public IEnumerable<GetAuthorModel> Authors { get; set; }
        public IEnumerable<GetCustomerModel> Customers { get; set; }
        public IEnumerable<GetBorrowModel> Borrows { get; set; }
    }
}
