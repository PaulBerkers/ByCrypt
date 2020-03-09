using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByCrypt.Classes
{
    public class Database
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; 
                                                Initial Catalog=ByCryptDataBase;Integrated Security=True");

        public void AddUser(string firstName, string Password)
        {
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO Gebruiker (Username, Password) VALUES (@gebruikersnaam, @wachtwoord); ";
            command.Parameters.AddWithValue("@gebruikersnaam", firstName);
            command.Parameters.AddWithValue("@wachtwoord", Password);

            command.ExecuteNonQuery();

            conn.Close();
        }

        public string GetPassword(string UserName)
        {
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "select Password from Gebruiker where Username = @gebruiker; ";
            command.Parameters.AddWithValue("@gebruiker", UserName);

            string value = (string)command.ExecuteScalar();

            return value;
        }
    }
}
