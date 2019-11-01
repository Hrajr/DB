using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserContext
    {
        User Login(User user);
        bool AdminCheck(User user);
        bool Registration(User user);
        User GetUserInfo(User user);
    }
}
