using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IUserContext
    {
        UserDTO Login(UserDTO user);
        bool AdminCheck(string id);
        bool Registration(UserDTO user);
        UserDTO GetUserInfo(string id);
    }
}
