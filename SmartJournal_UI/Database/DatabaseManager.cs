using System;
using Microsoft.Data.Sqlite;
using System.IO;

namespace SmartJournal_UI.Database
{
    public static class DatabaseManager
    {
        private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "smart_journal.db");
        private static readonly string ConnectionString = $"Data Source={DbPath}";

        public static void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                // Скрипт автоматичного створення таблиць згідно з ДЗ №4
                string createTablesQuery = @"
                    CREATE TABLE IF NOT EXISTS Entries (
                        id TEXT PRIMARY KEY,
                        user_id TEXT NOT NULL,
                        title TEXT NOT NULL,
                        content_text TEXT,
                        mood_score INTEGER CHECK(mood_score BETWEEN 1 AND 5),
                        created_at TEXT NOT NULL,
                        updated_at TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Photos (
                        id TEXT PRIMARY KEY,
                        entry_id TEXT NOT NULL,
                        photo_url TEXT NOT NULL,
                        FOREIGN KEY (entry_id) REFERENCES Entries(id) ON DELETE CASCADE
                    );

                    CREATE TABLE IF NOT EXISTS Tags (
                        id TEXT PRIMARY KEY,
                        name TEXT NOT NULL UNIQUE
                    );

                    CREATE TABLE IF NOT EXISTS Entry_Tags (
                        entry_id TEXT NOT NULL,
                        tag_id TEXT NOT NULL,
                        PRIMARY KEY (entry_id, tag_id),
                        FOREIGN KEY (entry_id) REFERENCES Entries(id) ON DELETE CASCADE,
                        FOREIGN KEY (tag_id) REFERENCES Tags(id) ON DELETE CASCADE
                    );";

                using (var command = new SqliteCommand(createTablesQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}