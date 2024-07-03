using AdCom.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AdCom
{
    static class DataBase
    {
        static public readonly string connectionString;

        static DataBase()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static User SignIn(string login, string password)
        {
            User user = new User();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand("SignIn", connection);
                
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (!reader.HasRows) 
                    return null;

                user.FullName = reader[0].ToString();
                user.Role = reader[1].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"При получении данных о пользователе произошла ошибка.\n{ex.Message}");
                return null;
            }
            finally
            {
                connection.Close();
            }
            return user;
        }
    }
}
