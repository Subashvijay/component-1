using System;
using System.Collections.Generic;

#nullable disable

namespace TweetApp.Models
{
    public partial class User
    {
        public User()
        {
            Tweets = new HashSet<Tweet>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}
