using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IUserContext
    {
        UserDTO Login(UserDTO user);
        bool AdminCheck(UserDTO user);
        bool Registration(UserDTO user);
        UserDTO GetUserInfo(UserDTO user);
    }
}
