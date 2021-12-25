using LibraryManagementSystem.Application.Dtos.Authors;
using System;

namespace LibraryManagementSystem.Application.Dtos.Books
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public GetAuthorDto Author { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public string PagesNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string UserId { get; set; }
    }
}
