using System;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UsersManager
    {
        public int Login(string userName, string userPwd)
        {
            int checkLogin = 0;

            try
            {
                using(MySqlConnection mySqlConnection = DBHelper.OpenMySqlConnection())
                {
                    string query = @"select * from Users where user_name = @user_name and user_pwd = @user_pwd";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                    mySqlCommand.Parameters.AddWithValue("@user_name", userName);
                    mySqlCommand.Parameters.AddWithValue("@user_pwd", userPwd);
                    using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            checkLogin = 0;
                        }
                        else
                        {
                            checkLogin = 2;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                checkLogin = 1;
            }

            return checkLogin;
        }
    }
}
