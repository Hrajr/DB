﻿using System;
using Models;

namespace DTO
{
    public class UserDTO
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Place { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
        public string Salt { get; set; }

        public UserDTO(string username, string password, string salt)
        {
            Username = username;
            Password = password;
            Salt = salt;
        }

        public UserDTO()
        {
        }
    }
}
