using System;
using System.Collections.Generic;

#nullable disable

namespace TweetApp.Models
{
    public partial class Tweet
    {
        public int TweetId { get; set; }
        public string Tweet1 { get; set; }
        public string Email { get; set; }

        public virtual User EmailNavigation { get; set; }
    }
}
