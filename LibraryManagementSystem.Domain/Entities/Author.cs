using LibraryManagementSystem.Domain.Entities.Base;
using System;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
    }
}
