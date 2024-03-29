﻿namespace WebDiary.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string? Email { get; set; } = null!;
        public string? UserName { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string? NewPassword { get; set; } = null!;
    }
}