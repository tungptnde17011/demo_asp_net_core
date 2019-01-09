using System;

namespace Persistence
{
    public class User
    {
        public User(){}
    
        public User(int userId, string userName, string userPwd)
        {
            UserId = userId;
            UserName = userName;
            UserPwd = userPwd;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
    }
}
