using System;

namespace EF6CustomConventionExample.Models
{
    public class Comment
    {
        public int Key { get; set; } // Primary key detected by custom convention
        public string Text { get; set; }
        public int PostKey { get; set; }
        public Post Post { get; set; }
    }
}
