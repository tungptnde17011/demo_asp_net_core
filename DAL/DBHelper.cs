using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DBHelper
    {
        public static string GetConnectionString()
        {
            string connectionString = null;

            try
            {
                using (FileStream fileStream = File.OpenRead("ConnectionString.txt"))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        connectionString = streamReader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return connectionString;
        }

        public static MySqlConnection OpenMySqlConnection()
        {
            MySqlConnection mySqlConnection = null;

            try
            {
                mySqlConnection = new MySqlConnection
                {
                    ConnectionString = GetConnectionString()
                };
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return mySqlConnection;
        }
    }
}