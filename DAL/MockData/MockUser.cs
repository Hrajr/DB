using Models;
using System;

namespace DAL
{
    public class MockUser
    {
        public User UserMock = new User()
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
