using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetApp.Models;

namespace TweetApp.Services
{
    class TweetService
    {
        public int PostTweetForUser(string UserEmail, string tweetMessage)
        {
            Tweet Tweet = new Tweet {
                Tweet1 = tweetMessage,
                Email = UserEmail
            };
            using (var db = new twitterContext())
            {
                db.Tweets.Add(Tweet);
               return db.SaveChanges();
            }
        }
        public List<string> GetTweetsByUserId(string userEmail)
        {
            using (var db = new twitterContext())
            {
                return db.Tweets.Where(x => x.Email == userEmail).Select(s => s.Tweet1).ToList();
            }
        }

        public List<User> GetAllUserDetails()
        {
            using (var db = new twitterContext())
            {
                return db.Users.ToList();
            }
        }

        public List<Tweet> GetAllTweet()
        {
            using (var db = new twitterContext())
            {
                return db.Tweets.ToList();
            }
        }
    }
}
