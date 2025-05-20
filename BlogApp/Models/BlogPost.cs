using System;

namespace BlogApp.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
        public int? UserId { get; set; }
        
        public BlogPost()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            IsPublished = false;
            UserId = null;
        }
        
        public override string ToString()
        {
            return $"{Title} ({Category}) - {CreatedDate.ToShortDateString()}";
        }
    }
}
