﻿using System.ComponentModel.DataAnnotations;

namespace WebDiary.DAL.Models
{
    public partial class Group
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        [Required]
        public User? User { get; set; }
        public List<User> Users { get; set; } = new();
        public ICollection<Event> Events { get; } = new List<Event>();
    }
}