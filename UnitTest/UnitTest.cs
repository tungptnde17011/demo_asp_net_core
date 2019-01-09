using System;
using System.Data;
using DAL;
using MySql.Data.MySqlClient;
using Xunit;

namespace UnitTest
{
    public class UnitTest
    {
        // [Fact]
        // public void GetConnectionStringTest()
        // {
        //     Assert.NotNull(DBHelper.GetConnectionString());
        // }

        // [Fact]
        // public void OpenMySqlConnectionTest()
        // {
        //     MySqlConnection mySqlConnection = DBHelper.OpenMySqlConnection();
        //     Assert.True(mySqlConnection.State == ConnectionState.Open);
        //     using (mySqlConnection)
        //     {
        //         string query = @"select * from Users;";
        //         MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
        //         using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
        //         {
        //             if (reader.Read())
        //             {
        //                 Console.WriteLine("{0} - {1} - {2}", reader.GetInt32("user_id"), reader.GetString("user_name"), reader.GetString("user_pwd"));
        //             }
        //         }   
        //     }
        //     Assert.True(mySqlConnection.State == ConnectionState.Closed);            
        // }

        // [Fact]
        // public void DalLoginTest()
        // {
        //     DAL.UsersManager dal_usersManager = new DAL.UsersManager();
        //     int checkLogin = dal_usersManager.Login("tungpt260794", "123456");
        //     Console.WriteLine("checkLogin = {0}", checkLogin);
        //     Assert.True(checkLogin ==  0);
        // }

        [Fact]
        public void BlLoginTest()
        {
            BL.UsersManager bl_usersManager = new BL.UsersManager();
            int checkLogin = bl_usersManager.Login("tungpt260794", "123456");
            Console.WriteLine("checkLogin = {0}", checkLogin);
            Assert.True(checkLogin ==  0);
        }
    }
}
