using DAL;
using Logic.Encryption;
using Logic.Security.Encryptor;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DTO;

namespace Logic
{
    public class UserLogic
    {
        private readonly IUserContext _context;
        private static readonly Hash Hashing = new Hash();
        private static readonly Encrypting Crypto = new Encrypting();
        public UserLogic(IUserContext context)
        {
            _context = context;
        }

        public bool Login(User user)
        {
            var success = false;
            var input = user.Password;
            var loggedInUser = _context.Login(new UserDTO(user.Username, user.Password, user.Salt));
            loggedInUser.Password = Hashing.GetHash(input, user.Salt);            
            if (HashValid(input, loggedInUser.Salt, loggedInUser.Password))
            { success = true; }
            return success;
        }

        private static bool HashValid(string Input, string Salt, string Password)
        {
            bool Check = Hashing.Validate(Input, Salt, Password);
            return Check;
        }

        public bool AdminCheck(User user)
        {
            return _context.AdminCheck(user.UserID);
        }

        public User GetUserInfo(UserDTO user)
        {
            user = _context.GetUserInfo(user.UserID);
            user = InfoDecryptor(user);
            return user;
        }

        public bool Registration(User user)
        {
            user = HashUser(user);
            user = InfoEncryptor(user);
            return _context.Registration(user);
        }

        private UserDTO InfoEncryptor(UserDTO user)
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

        private UserDTO InfoDecryptor(UserDTO user)
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

        private User HashUser(User user)
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
