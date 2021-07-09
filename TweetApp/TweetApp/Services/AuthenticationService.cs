using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetApp.Models;

namespace TweetApp.Services
{
    public class AuthenticationService
    {

        public User Login(string Email,string password)
        {
            using (var db = new twitterContext())
            {
                var user = db.Users.Where(x => x.Email == Email && x.UserPassword == password).FirstOrDefault();
                if(user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public string Regestration(User user)
        {
            int count;
            using (var db = new twitterContext())
            {
                db.Users.Add(user);
                count = db.SaveChanges();
            }
            if (count > 0)
            {
                return user.FirstName;
            }
            return null;
        }

        public bool CheckIfUserAlreadyAvilable(string email)
        {
            using (var db = new twitterContext())
            {
               var users = db.Users.Where(x => x.Email == email).ToList();
                if(users.Count == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public bool ResetPassword(User user)
        {
            using (var db = new twitterContext())
            {
                db.Users.Update(user);
                db.SaveChanges();
                return true;
            }
        }
    }
}
