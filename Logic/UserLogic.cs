using DAL;
using DTO;
using Logic.Encryption;
using Logic.Security.Encryptor;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Logic
{
    public class UserLogic
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
        public bool Admin { get; set; } = false;
        public string Salt { get; set; }

        private readonly IUserContext _context;
        private static readonly Hash Hashing = new Hash();
        private static readonly Encrypting Crypto = new Encrypting();
        public UserLogic(IUserContext context)
        {
            _context = context;
        }

        public UserLogic(UserDTO user)
        {
            UserID = user.UserID;
            Username = user.Username;
            Password = user.Password;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Address = user.Address;
            Zipcode = user.Zipcode;
            Place = user.Place;
            Phone = user.Phone;
            Email = user.Email;
            Admin = user.Admin;
            Salt = user.Salt;
        }

        public UserDTO ConvertToDTO(UserLogic user)
        {
            var convertedUser = new UserDTO()
            {
                UserID = user.UserID,
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Address = user.Address,
                Zipcode = user.Zipcode,
                Place = user.Place,
                Phone = user.Phone,
                Email = user.Email,
                Admin = user.Admin,
                Salt = user.Salt
            };
            return convertedUser;
        }

        public bool Login(UserLogic user)
        {
            bool Success = false;
            string Input = user.Password;
            user = new UserLogic(_context.Login(ConvertToDTO(user)));
            user.Password = Hashing.GetHash(Input, user.Salt);            
            if (HashValid(Input, user.Salt, user.Password))
            { Success = true; }
            return Success;
        }

        private static bool HashValid(string Input, string Salt, string Password)
        {
            bool Check = Hashing.Validate(Input, Salt, Password);
            return Check;
        }

        public bool AdminCheck(UserLogic user)
        {
            return _context.AdminCheck(ConvertToDTO(user));
        }

        public UserLogic GetUserInfo(UserLogic user)
        {
            user = new UserLogic(_context.GetUserInfo(ConvertToDTO(user)));
            user = InfoDecryptor(user);
            return user;
        }

        public bool Registration(UserLogic user)
        {
            user = HashUser(user);
            user = InfoEncryptor(user);
            return _context.Registration(ConvertToDTO(user));
        }

        private UserLogic InfoEncryptor(UserLogic user)
        {
            user.Firstname = Crypto.Encrypt(user.Firstname);
            user.Lastname = Crypto.Encrypt(user.Lastname);
            user.Address = Crypto.Encrypt(user.Address);
            user.Zipcode = Crypto.Encrypt(user.Zipcode);
            user.Place = Crypto.Encrypt(user.Place);
            user.Phone = Crypto.Encrypt(user.Phone);
            user.Email = Crypto.Encrypt(user.Email);
            return user;
        }

        private UserLogic InfoDecryptor(UserLogic user)
        {            
            user.Firstname = Crypto.Decrypt(user.Firstname);
            user.Lastname = Crypto.Decrypt(user.Lastname);
            user.Address = Crypto.Decrypt(user.Address);
            user.Zipcode = Crypto.Decrypt(user.Zipcode);
            user.Place = Crypto.Decrypt(user.Place);
            user.Phone = Crypto.Decrypt(user.Phone);
            user.Email = Crypto.Decrypt(user.Email);

            //GET FIELD NAME AND VALUE!!!
            //FieldInfo[] fields = user.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            //for (int i = 0; i < fields.Length; i++)
            //{
            //    var FieldValue = fields[i].GetValue(user).ToString();
            //    string FullFieldName = fields[i].Name;
            //    string TrimmedFieldName = FullFieldName.Remove(FullFieldName.IndexOf('>')).Substring(FullFieldName.IndexOf('<') + 1);
            //}

            return user;
        }

        private UserLogic HashUser(UserLogic user)
        {
            user.Salt = GetSalt();
            user.Password = Hashing.GetHash(user.Password, user.Salt);
            return user;
        }

        private static string GetSalt()
        {
            return Hashing.Salt;
        }
    }
}
