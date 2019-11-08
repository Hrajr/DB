﻿using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class UserContext : IUserContext
    {
        private readonly DB Data = new DB();

        public UserDTO Login(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(Data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("Login", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Username", user.Username));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user.UserID = reader["ID"].ToString();
                        user.Username = reader["Username"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.Salt = reader["Salt"].ToString();
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return user;
        }

        public UserDTO GetUserInfo(string id)
        {
            UserDTO userInfo = new UserDTO();
            using (SqlConnection conn = new SqlConnection(Data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetUserInfo", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserID", id));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        userInfo.Username = reader["Username"].ToString();
                        userInfo.Firstname = reader["Firstname"].ToString();
                        userInfo.Lastname = reader["Lastname"].ToString();
                        userInfo.Address = reader["Address"].ToString();
                        userInfo.Zipcode = reader["Zipcode"].ToString();
                        userInfo.Place = reader["Place"].ToString();
                        userInfo.Phone = reader["Phone"].ToString();
                        userInfo.Email = reader["Email"].ToString();
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return userInfo;
        }

        public bool AdminCheck(string id)
        {
            bool isAdmin = false;

            using (SqlConnection conn = new SqlConnection(Data.con.ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("AdminCheck", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserID", id));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        isAdmin = (bool)reader["Admin"];
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return isAdmin;
        }

        public bool Registration(UserDTO user)
        {
            bool RegistrationSuccess = false;
            using (SqlConnection conn = new SqlConnection(Data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("SignUp", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Username", user.Username));
                    command.Parameters.Add(new SqlParameter("@Password", user.Password));
                    command.Parameters.Add(new SqlParameter("@Firstname", user.Firstname));
                    command.Parameters.Add(new SqlParameter("@Lastname", user.Lastname));
                    command.Parameters.Add(new SqlParameter("@Address", user.Address));
                    command.Parameters.Add(new SqlParameter("@Zipcode", user.Zipcode));
                    command.Parameters.Add(new SqlParameter("@Place", user.Place));
                    command.Parameters.Add(new SqlParameter("@Phone", user.Phone));
                    command.Parameters.Add(new SqlParameter("@Email", user.Email));
                    command.Parameters.Add(new SqlParameter("@Salt", user.Salt));
                    command.Parameters.Add(new SqlParameter("@Admin", user.Admin));

                    command.ExecuteReader();
                    RegistrationSuccess = true;
                }
                catch (Exception e)
                {
                    var a = e;
                    RegistrationSuccess = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return RegistrationSuccess;
        }
    }
}
