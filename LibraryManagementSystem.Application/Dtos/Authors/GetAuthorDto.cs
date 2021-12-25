using System;

namespace LibraryManagementSystem.Application.Dtos.Authors
{
    public class GetAuthorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
    }
}
