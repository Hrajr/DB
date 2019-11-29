using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL
{
    public interface IUserContext
    {
        UserInfo Login(UserInfo user);
        bool AdminCheck(UserInfo user);
        bool Registration(UserInfo user);
        UserInfo GetUserInfo(UserInfo user);
    }
}
