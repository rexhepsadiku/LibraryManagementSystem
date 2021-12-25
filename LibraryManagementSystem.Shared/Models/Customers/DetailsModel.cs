using LibraryManagementSystem.Shared.Models.Books;
using X.PagedList;

namespace LibraryManagementSystem.Shared.Models.Customers
{
    public class DetailsModel
    {
        public GetCustomerModel Customer { get; set; }
        public IPagedList<GetBookModel> Books { get; set; }
    }
}
