﻿using System;

namespace LibraryManagementSystem.Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatetAt { get; set; }
    }
}
