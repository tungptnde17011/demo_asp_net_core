using System;

namespace BL
{
    public class UsersManager
    {
        DAL.UsersManager dal_usersManager = new DAL.UsersManager();

        public int Login(string userName, string userPwd)
        {
            int checkLogin = 0;

            checkLogin = dal_usersManager.Login(userName, userPwd);

            return checkLogin;
        }
    }
}
