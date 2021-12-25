using LibraryManagementSystem.Shared.Models.Authors;
using LibraryManagementSystem.Shared.Models.Books;
using LibraryManagementSystem.Shared.Models.Customers;
using X.PagedList;

namespace LibraryManagementSystem.Shared.Models.Accounts
{
    public class UserDetailsModel
    {
        public IPagedList<GetAuthorModel> Authors { get; set; }
        public IPagedList<GetBookModel> Books { get; set; }
        public IPagedList<GetCustomerModel> Customers { get; set; }
    }
}
