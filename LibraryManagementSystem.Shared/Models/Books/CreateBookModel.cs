﻿using System;

namespace LibraryManagementSystem.Shared.Models.Books
{
    public class CreateBookModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public string PagesNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string UserId { get; set; }
    }
}
