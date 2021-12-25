using System;

namespace LibraryManagementSystem.Shared.Models.Authors
{
    public class GetAuthorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
    }
}
