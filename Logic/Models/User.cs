using System;
using System.ComponentModel.DataAnnotations;
using DTO;

namespace Models
{
    public class User
    {
        public string UserID { get; set; }
        [StringLength(50, MinimumLength = 8, ErrorMessage = "The lenght of your username should be between 8 and 50 characters!")]
        [Required(ErrorMessage = "Username field is required!")]
        public string Username { get; set; }
        [StringLength(50, MinimumLength = 8, ErrorMessage = "The lenght of your password should be between 8 and 50 characters!")]
        [Required(ErrorMessage = "Password field is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Place { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; } = false;
        public string Salt { get; set; }

        public User()
        {

        }

        public User(UserDTO user)
        {
            UserID = user.UserID;
            Username = user.Username;
            Password = user.Password;
            Salt = user.Salt;
        }

        public string FullName()
        {
            string FullName = Firstname + " " + Lastname;
            return FullName;
        }
    }
}
