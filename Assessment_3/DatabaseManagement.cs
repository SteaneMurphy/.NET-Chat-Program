﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace Windows_Forms_CORE_CHAT_UGH
{
    public class DatabaseManagement
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "mainDatabase.db");
        string database_URI;

        public DatabaseManagement() 
        {
            database_URI = $"Data Source={filePath};Version=3;";
        }

        public void InitialiseDatabase(string database_URI)
        {
            if (!CheckDatabaseExists())
            {
                CreateDatabaseSchema();
            }
            else 
            {
                if (!CheckTableExists())
                {
                    Console.WriteLine("Schema does not exist, creating");
                    CreateDatabaseSchema();
                }
                else 
                {
                    Console.WriteLine("Schema exists");
                }
            }
        }

        private bool CheckDatabaseExists() 
        {
            if (!File.Exists(filePath)) 
            {
                SQLiteConnection.CreateFile(filePath);
                Console.WriteLine("Database not found, creating database");
                return false;
            }

            Console.WriteLine("Database exists");
            return true;
        }

        private bool CheckTableExists()
        {
            using (SQLiteConnection db = new SQLiteConnection(database_URI))
            {
                db.Open();

                string query = "SELECT name FROM sqlite_master WHERE type='table' AND name='Users'";
                using (SQLiteCommand cmd = new SQLiteCommand(query, db)) 
                {
                    object result = cmd.ExecuteScalar();
                    db.Close();
                    return result != null;
                }
            }
        }

        private void CreateDatabaseSchema() 
        {
            using (SQLiteConnection db = new SQLiteConnection(database_URI)) 
            {
                db.Open();

                string createTable = @"
                    CREATE TABLE IF NOT EXISTS Users (    
                        userID INTEGER PRIMARY KEY AUTOINCREMENT,
                        userName TEXT NOT NULL,
                        email TEXT NOT NULL,
                        password TEXT NOT NULL,
                        wins INTEGER NOT NULL DEFAULT 0,
                        losses INTEGER NOT NULL DEFAULT 0,
                        draws INTEGER NOT NULL DEFAULT 0
                    )";

                using (SQLiteCommand cmd = new SQLiteCommand(createTable, db)) 
                {
                    cmd.ExecuteNonQuery();
                }

                db.Close();
            }
        }

        public Dictionary<string, int[]> ScoresHighestToLowest()
        {
            Dictionary<string, int[]> unsortedScores = new Dictionary<string, int[]>();

            using (SQLiteConnection db = new SQLiteConnection(database_URI))
            {
                db.Open();
                string query = "SELECT userName, wins, losses, draws FROM Users";

                using (SQLiteCommand cmd = new SQLiteCommand(query, db))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Extract the user data from the reader
                            string username = reader["userName"].ToString();
                            int wins = Convert.ToInt32(reader["wins"]);
                            int losses = Convert.ToInt32(reader["losses"]);
                            int draws = Convert.ToInt32(reader["draws"]);

                            // Store the values in the dictionary with the username as the key
                            unsortedScores[username] = new int[] { wins, losses, draws };
                        }
                    }
                }
                db.Close();

                var scores = new Dictionary<string, int[]>(
                    unsortedScores.OrderByDescending(entry => entry.Value[0])
                    .ToDictionary(entry => entry.Key, entry => entry.Value)
                );

                return scores;
            }
        }

        private void RemoveExistingDatabase() 
        {
            
        }

        public void AddEntry(string _username, string _email, string _password) 
        {
            using (SQLiteConnection db = new SQLiteConnection(database_URI))
            {
                db.Open();

                string query = @"INSERT INTO Users (userName, email, password)
                                 VALUES (@userName, @email, @password)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@userName", _username);
                    cmd.Parameters.AddWithValue("@email", _email);
                    cmd.Parameters.AddWithValue("@password", _password);
                    cmd.ExecuteNonQuery();
                }

                db.Close();
            }
        }

        public string QueryUsername(string _username) 
        {
            using (SQLiteConnection db = new SQLiteConnection(database_URI))
            {
                db.Open();
                string userName = null;

                string queryUsername = @"
                    SELECT *
                    FROM Users
                    WHERE userName = @username";

                using (SQLiteCommand cmd = new SQLiteCommand(queryUsername, db))
                {
                    cmd.Parameters.AddWithValue("@username", _username);

                    using (SQLiteDataReader reader = cmd.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                            userName = reader["userName"].ToString();                       
                        }
                    }
                }
                
                db.Close();
                Console.WriteLine(userName);
                return userName;
            }
        }

        public string QueryPassword(string _password)
        {
            using (SQLiteConnection db = new SQLiteConnection(database_URI))
            {
                db.Open();
                string password = null;

                string queryPassword = @"
                    SELECT *
                    FROM Users
                    WHERE password = @password";

                using (SQLiteCommand cmd = new SQLiteCommand(queryPassword, db))
                {
                    cmd.Parameters.AddWithValue("@password", _password);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            password = reader["password"].ToString();
                        }
                    }
                }

                db.Close();
                return password;
            }
        }

        public string QueryEmail(string _email)
        {
            using (SQLiteConnection db = new SQLiteConnection(database_URI))
            {
                db.Open();
                string email = null;

                string queryEmail = @"
                    SELECT *
                    FROM Users
                    WHERE email = @email";

                using (SQLiteCommand cmd = new SQLiteCommand(queryEmail, db))
                {
                    cmd.Parameters.AddWithValue("@email", _email);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            email = reader["password"].ToString();
                        }
                    }
                }

                db.Close();
                return email;
            }
        }

        public string GetURI() 
        {
            return database_URI;
        }
    }
}
