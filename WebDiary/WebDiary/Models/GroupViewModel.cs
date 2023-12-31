﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebDiary.Models
{
    public class GroupViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public List<UserViewModel>? Users { get; } = new();
        public ICollection<EventViewModel>? Events { get; } = new List<EventViewModel>();
    }
}