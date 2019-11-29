using DTO;
using Models;
using System;

namespace DAL
{
    public class MockUser
    {
        public UserDTO UserMock = new UserDTO()
        {
            UserID = "TestID",
            Username = "TestUsername",
            Password = "TestPassword",
            Firstname = "TestFirstname",
            Lastname = "TestLastname",
            Address = "TestAdmin",
            Zipcode = "TestZipcode",
            Place = "TestPlace",
            Admin = true
        };
    }
}
