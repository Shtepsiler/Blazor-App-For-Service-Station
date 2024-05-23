﻿namespace BlazorApp.Extensions.ViewModels.IdentityVMs
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Role { get; set; }
    }
}
