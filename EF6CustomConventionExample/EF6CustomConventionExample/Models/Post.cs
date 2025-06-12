using System;

namespace EF6CustomConventionExample.Models
{
    public class Post
    {
        public int Key { get; set; } // Primary key detected by custom convention
        public string Title { get; set; }
        public string Content { get; set; }
    }
}