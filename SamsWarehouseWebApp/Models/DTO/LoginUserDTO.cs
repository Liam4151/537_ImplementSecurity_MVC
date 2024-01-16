﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SamsWarehouseWebApp.Models.DTO
{
    public class LoginUserDTO
    {
        [EmailAddress]
        public string Email { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }

        public string Role { get; set; }

        public string RedirectURL { get; set; } 

    }

    public class RegisterUserDTO : LoginUserDTO
    {
    }
}
