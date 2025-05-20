using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using BlogApp.Models;

namespace BlogApp.Data
{
    public class BlogRepository
    {
        private readonly string _connectionString;
        private readonly string _dbPath;        public BlogRepository()
        {
            _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "blog.db");
            _connectionString = $"Data Source={_dbPath};Version=3;";
            
            bool dbExists = File.Exists(_dbPath);
            
            if (!dbExists)
            {
                InitializeDatabase();
            }
            else
            {
                // Check if Users table exists, and if not, create it
                EnsureTablesExist();
            }
        }
        
        private void EnsureTablesExist()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                // Check if Users table exists
                bool usersTableExists = false;
                using (var cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='Users'", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        usersTableExists = reader.Read();
                    }
                }
                
                if (!usersTableExists)
                {
                    // Create Users table
                    string createUsersTableSql = @"
                        CREATE TABLE Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL UNIQUE,
                            PasswordHash TEXT NOT NULL,
                            Email TEXT NOT NULL,
                            DisplayName TEXT NOT NULL,
                            IsAdmin INTEGER NOT NULL,
                            CreatedDate TEXT NOT NULL,
                            LastLoginDate TEXT
                        )";
                        
                    using (var command = new SQLiteCommand(createUsersTableSql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    
                    // Create default admin user
                    string createAdminSql = @"
                        INSERT INTO Users (Username, PasswordHash, Email, DisplayName, IsAdmin, CreatedDate)
                        VALUES (@Username, @PasswordHash, @Email, @DisplayName, @IsAdmin, @CreatedDate)";
                        
                    using (var command = new SQLiteCommand(createAdminSql, connection))
                    {
                        command.Parameters.AddWithValue("@Username", "admin");
                        command.Parameters.AddWithValue("@PasswordHash", Models.User.HashPassword("admin123"));
                        command.Parameters.AddWithValue("@Email", "admin@blogapp.com");
                        command.Parameters.AddWithValue("@DisplayName", "Administrator");
                        command.Parameters.AddWithValue("@IsAdmin", 1);
                        command.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        
                        command.ExecuteNonQuery();
                    }
                }
                
                // Check if BlogPosts table exists and has UserId column
                bool blogPostsTableHasUserIdColumn = false;
                using (var cmd = new SQLiteCommand("PRAGMA table_info(BlogPosts)", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["name"].ToString() == "UserId")
                            {
                                blogPostsTableHasUserIdColumn = true;
                                break;
                            }
                        }
                    }
                }
                
                if (!blogPostsTableHasUserIdColumn)
                {
                    // Add UserId column to BlogPosts table if it exists but doesn't have the column
                    bool blogPostsTableExists = false;
                    using (var cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='BlogPosts'", connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            blogPostsTableExists = reader.Read();
                        }
                    }
                    
                    if (blogPostsTableExists)
                    {
                        using (var command = new SQLiteCommand("ALTER TABLE BlogPosts ADD COLUMN UserId INTEGER", connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }private void InitializeDatabase()
        {
            SQLiteConnection.CreateFile(_dbPath);
            
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                // Create BlogPosts table
                string createBlogTableSql = @"
                    CREATE TABLE BlogPosts (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Content TEXT NOT NULL,
                        CreatedDate TEXT NOT NULL,
                        ModifiedDate TEXT NOT NULL,
                        Author TEXT NOT NULL,
                        Category TEXT NOT NULL,
                        IsPublished INTEGER NOT NULL,
                        UserId INTEGER
                    )";
                
                using (var command = new SQLiteCommand(createBlogTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }
                
                // Create Users table
                string createUsersTableSql = @"
                    CREATE TABLE Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        PasswordHash TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        DisplayName TEXT NOT NULL,
                        IsAdmin INTEGER NOT NULL,
                        CreatedDate TEXT NOT NULL,
                        LastLoginDate TEXT
                    )";
                    
                using (var command = new SQLiteCommand(createUsersTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }
                
                // Create default admin user
                string createAdminSql = @"
                    INSERT INTO Users (Username, PasswordHash, Email, DisplayName, IsAdmin, CreatedDate)
                    VALUES (@Username, @PasswordHash, @Email, @DisplayName, @IsAdmin, @CreatedDate)";
                    
                using (var command = new SQLiteCommand(createAdminSql, connection))
                {
                    command.Parameters.AddWithValue("@Username", "admin");
                    command.Parameters.AddWithValue("@PasswordHash", Models.User.HashPassword("admin123"));
                    command.Parameters.AddWithValue("@Email", "admin@blogapp.com");
                    command.Parameters.AddWithValue("@DisplayName", "Administrator");
                    command.Parameters.AddWithValue("@IsAdmin", 1);
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<BlogPost> GetAllPosts()
        {
            List<BlogPost> posts = new List<BlogPost>();
            
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string sql = "SELECT * FROM BlogPosts ORDER BY CreatedDate DESC";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BlogPost post = ReadPostFromDataReader(reader);
                            posts.Add(post);
                        }
                    }
                }
            }
            
            return posts;
        }
        
        public List<BlogPost> GetPostsByCategory(string category)
        {
            List<BlogPost> posts = new List<BlogPost>();
            
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string sql = "SELECT * FROM BlogPosts WHERE Category = @Category ORDER BY CreatedDate DESC";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Category", category);
                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BlogPost post = ReadPostFromDataReader(reader);
                            posts.Add(post);
                        }
                    }
                }
            }
            
            return posts;
        }

        public BlogPost GetPostById(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string sql = "SELECT * FROM BlogPosts WHERE Id = @Id";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ReadPostFromDataReader(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }        public void AddPost(BlogPost post)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string sql = @"
                    INSERT INTO BlogPosts (Title, Content, CreatedDate, ModifiedDate, Author, Category, IsPublished, UserId)
                    VALUES (@Title, @Content, @CreatedDate, @ModifiedDate, @Author, @Category, @IsPublished, @UserId)";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Title", post.Title);
                    command.Parameters.AddWithValue("@Content", post.Content);
                    command.Parameters.AddWithValue("@CreatedDate", post.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@ModifiedDate", post.ModifiedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Author", post.Author);
                    command.Parameters.AddWithValue("@Category", post.Category);
                    command.Parameters.AddWithValue("@IsPublished", post.IsPublished ? 1 : 0);
                    command.Parameters.AddWithValue("@UserId", post.UserId.HasValue ? (object)post.UserId.Value : DBNull.Value);
                    
                    command.ExecuteNonQuery();
                    
                    // Get the last inserted id
                    command.CommandText = "SELECT last_insert_rowid()";
                    post.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }        public void UpdatePost(BlogPost post)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string sql = @"
                    UPDATE BlogPosts 
                    SET Title = @Title, 
                        Content = @Content, 
                        ModifiedDate = @ModifiedDate, 
                        Author = @Author, 
                        Category = @Category, 
                        IsPublished = @IsPublished,
                        UserId = @UserId
                    WHERE Id = @Id";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", post.Id);
                    command.Parameters.AddWithValue("@Title", post.Title);
                    command.Parameters.AddWithValue("@Content", post.Content);
                    command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Author", post.Author);
                    command.Parameters.AddWithValue("@Category", post.Category);
                    command.Parameters.AddWithValue("@IsPublished", post.IsPublished ? 1 : 0);
                    command.Parameters.AddWithValue("@UserId", post.UserId.HasValue ? (object)post.UserId.Value : DBNull.Value);
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePost(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string sql = "DELETE FROM BlogPosts WHERE Id = @Id";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<string> GetAllCategories()
        {
            List<string> categories = new List<string>();
            
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string sql = "SELECT DISTINCT Category FROM BlogPosts ORDER BY Category";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(reader["Category"].ToString());
                        }
                    }
                }
            }
            
            return categories;
        }

        // User authentication methods
        public User GetUserByUsername(string username)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string sql = "SELECT * FROM Users WHERE Username = @Username";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ReadUserFromDataReader(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        
        public User AuthenticateUser(string username, string password)
        {
            User user = GetUserByUsername(username);
            
            if (user != null && user.VerifyPassword(password))
            {
                // Update last login date
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    
                    string sql = "UPDATE Users SET LastLoginDate = @LastLoginDate WHERE Id = @Id";
                    
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@LastLoginDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@Id", user.Id);
                        command.ExecuteNonQuery();
                    }
                }
                
                user.LastLoginDate = DateTime.Now;
                return user;
            }
            
            return null;
        }
        
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string sql = "SELECT * FROM Users ORDER BY Username";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = ReadUserFromDataReader(reader);
                            users.Add(user);
                        }
                    }
                }
            }
            
            return users;
        }
        
        public void AddUser(User user)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string sql = @"
                    INSERT INTO Users (Username, PasswordHash, Email, DisplayName, IsAdmin, CreatedDate, LastLoginDate)
                    VALUES (@Username, @PasswordHash, @Email, @DisplayName, @IsAdmin, @CreatedDate, @LastLoginDate)";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@DisplayName", user.DisplayName);
                    command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin ? 1 : 0);
                    command.Parameters.AddWithValue("@CreatedDate", user.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@LastLoginDate", user.LastLoginDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    
                    command.ExecuteNonQuery();
                    
                    // Get the last inserted id
                    command.CommandText = "SELECT last_insert_rowid()";
                    user.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        
        public void UpdateUser(User user)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string sql = @"
                    UPDATE Users 
                    SET Username = @Username, 
                        PasswordHash = @PasswordHash, 
                        Email = @Email, 
                        DisplayName = @DisplayName, 
                        IsAdmin = @IsAdmin,
                        LastLoginDate = @LastLoginDate
                    WHERE Id = @Id";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@DisplayName", user.DisplayName);
                    command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin ? 1 : 0);
                    command.Parameters.AddWithValue("@LastLoginDate", user.LastLoginDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void DeleteUser(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                // First delete all posts by this user or set them to null
                string updatePostsSql = "UPDATE BlogPosts SET UserId = NULL WHERE UserId = @UserId";
                
                using (var command = new SQLiteCommand(updatePostsSql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", id);
                    command.ExecuteNonQuery();
                }
                
                // Then delete the user
                string sql = "DELETE FROM Users WHERE Id = @Id";
                
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        
        private User ReadUserFromDataReader(SQLiteDataReader reader)
        {
            return new User
            {
                Id = Convert.ToInt32(reader["Id"]),
                Username = reader["Username"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                Email = reader["Email"].ToString(),
                DisplayName = reader["DisplayName"].ToString(),
                IsAdmin = Convert.ToInt32(reader["IsAdmin"]) == 1,
                CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString()),
                LastLoginDate = reader["LastLoginDate"] != DBNull.Value 
                    ? DateTime.Parse(reader["LastLoginDate"].ToString()) 
                    : DateTime.MinValue
            };
        }        private BlogPost ReadPostFromDataReader(SQLiteDataReader reader)
        {
            return new BlogPost
            {
                Id = Convert.ToInt32(reader["Id"]),
                Title = reader["Title"].ToString(),
                Content = reader["Content"].ToString(),
                CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString()),
                ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString()),
                Author = reader["Author"].ToString(),
                Category = reader["Category"].ToString(),
                IsPublished = Convert.ToInt32(reader["IsPublished"]) == 1,
                UserId = reader["UserId"] != DBNull.Value ? Convert.ToInt32(reader["UserId"]) : (int?)null
            };
        }
    }
}
