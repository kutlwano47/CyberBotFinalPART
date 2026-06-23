using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CyberSecurityBotGUI.Classes
{
    public class DatabaseManager
    {
        private string connectionString =
            "server=localhost;database=CyberSecurityBot;uid=root;pwd=tumisho;";

        public void AddTask(string title, string description, string reminder)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query =
                    "INSERT INTO Tasks (Title, Description, Reminder, Completed) " +
                    "VALUES (@title, @description, @reminder, false)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@reminder", reminder);

                cmd.ExecuteNonQuery();
            }
        }

        public List<string> GetTasks()
        {
            List<string> tasks = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Tasks";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tasks.Add(
                        $"{reader["Id"]} | " +
                        $"{reader["Title"]} | " +
                        $"{reader["Description"]} | " +
                        $"{reader["Reminder"]}");
                }
            }

            return tasks;
        }
    }
}