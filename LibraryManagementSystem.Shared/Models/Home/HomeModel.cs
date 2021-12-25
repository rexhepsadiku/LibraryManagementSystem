using LibraryManagementSystem.Shared.Models.Books;
using LibraryManagementSystem.Shared.Models.Customers;
using X.PagedList;

namespace LibraryManagementSystem.Shared.Models.Home
{
    public class HomeModel
    {
        public IPagedList<GetBookModel> BooksBorrowedByCustomer { get; set; }
        public GetCustomerModel Customer { get; set; }
    }
}
