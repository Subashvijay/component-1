

using System;
using System.Collections.Generic;
using TweetApp.Models;
using TweetApp.Services;
using TweetApp.State;

namespace TweetApp.Views
{
    public class HomeScreenView
    {
        private TweetService tweetService = new TweetService();
        private AuthenticationService authentication = new AuthenticationService();

        enum MainOptions
        {
            Post_a_tweet,
            View_my_tweets,
            View_all_tweets,
            View_All_Users,
            Reset_Password,
            Logout
        }

        public  void LoadScreen()
        {
            while (true)
            {
                CommonViews.PrintTitle(Pages.Home);
                List<string> options = new List<string> {
                    "Post a tweet",
                    "View my tweets",
                    "View all tweets",
                    "View All Users",
                    "Reset Password",
                    "Logout" };
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"{options[i]}---->[{i + 1}]");
                }
                int selectedOptions = CommonViews.CheckValidOptionOrNot(options.Count);
                switch ((MainOptions)selectedOptions - 1)
                {
                    case MainOptions.Post_a_tweet:
                        {
                            Console.WriteLine("Enter Your Tweet");
                            string tweet = CommonViews.CheckForEmptyString();
                            if (tweetService.PostTweetForUser(AppState.currentUser.Email, tweet) > 0)
                            {
                                CommonViews.PrintSuccess("Tweet added successfully.");
                            }
                            else
                            {
                                CommonViews.PrintAlert("Posting tweet failed.");
                            }
                        }
                        break;

                    case MainOptions.View_my_tweets:
                        {
                            List<string> tweets = tweetService.GetTweetsByUserId(AppState.currentUser.Email);
                            if (tweets.Count > 0)
                            {
                                int count = 1;
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                tweets.ForEach(x => { Console.WriteLine($"[{count}]--\" {x} \""); count++; });
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                CommonViews.PrintWarning("you dont have any tweets");
                            }
                        }
                        break;

                    case MainOptions.View_all_tweets:
                        {
                            List<Tweet> tweets = tweetService.GetAllTweet();
                            if (tweets.Count > 0)
                            {

                                int count = 1;
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                tweets.ForEach(x => { Console.WriteLine($"[{count}]--\" {x.Tweet1} \"---by:{x.Email}"); count++; });
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                CommonViews.PrintWarning("there is no tweets avilable");
                            }
                        }
                        break;
                    case MainOptions.View_All_Users:
                        {
                            List<User> users = tweetService.GetAllUserDetails();
                            if (users.Count > 0)
                            {

                                int count = 1;
                                users.ForEach(x => {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"[{count}] User name: {x.FirstName} UserId: {x.Email} Gender: {x.Gender} "); count++;
                                    Console.ForegroundColor = ConsoleColor.White;
                                });
                            }

                        }
                        break;
                    case MainOptions.Reset_Password:
                        {
                        changePass: Console.WriteLine("Enter the Old PassWord:");
                            string oldPass = CommonViews.ReadPassword();
                            if (AppState.currentUser.UserPassword != oldPass)
                            {
                                CommonViews.PrintAlert("Entered Password is wrong Please enter the correct pass");
                                goto changePass;
                            }

                            string newPass = CommonViews.SetNewPassword();
                            if (AppState.currentUser.UserPassword == newPass)
                            {
                                CommonViews.PrintAlert("New and old password are same.");
                                break;
                            }
                            AppState.currentUser.UserPassword = newPass;
                            if (authentication.ResetPassword(AppState.currentUser))
                            {
                                CommonViews.PrintSuccess("Password update successfully.");
                            }
                            else
                            {
                                CommonViews.PrintAlert("Error while updating the password.");
                            }

                        }
                        break;
                    case MainOptions.Logout:
                        AppState.currentUser = null;
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
