using System;
using System.Collections.Generic;

namespace SmartJournal_UI.Database
{
    // Модель таблиці Entries
    public class DbEntry
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ContentText { get; set; } = string.Empty;
        public int MoodScore { get; set; } // Значення від 1 до 5
        public string CreatedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public string UpdatedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // Навігаційні властивості для зв'язків
        public List<DbPhoto> Photos { get; set; } = new List<DbPhoto>();
        public List<DbTag> Tags { get; set; } = new List<DbTag>();
    }

    // Модель таблиці Photos
    public class DbPhoto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string EntryId { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
    }

    // Модель таблиці Tags
    public class DbTag
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
    }
}