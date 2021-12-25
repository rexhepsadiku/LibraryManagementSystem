using LibraryManagementSystem.Shared.Models.Books;
using X.PagedList;

namespace LibraryManagementSystem.Shared.Models.Authors
{
    public class DetailsModel
    {
        public GetAuthorModel Author { get; set; }
        public IPagedList<GetBookModel> Books { get; set; }
    }
}
