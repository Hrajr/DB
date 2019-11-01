using DAL;
using System;

namespace iContext
{
    public class Class1
    {
        private static readonly UserContext context = new UserContext();

        public static IUserContext Login()
        {
            return context;
        }
    }
}
