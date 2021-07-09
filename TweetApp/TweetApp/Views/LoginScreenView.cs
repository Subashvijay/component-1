using System;
using System.Collections.Generic;
using System.Text;
using TweetApp.Services;
using TweetApp.State;

namespace TweetApp.Views
{
    public class LoginScreenView
    {
        private AuthenticationService authentication = new AuthenticationService();
       
        public bool LoadScreen()
        {
            while (true)
            {
                CommonViews.PrintTitle(Pages.Login);
                Console.Write("Email:");
                string userName = Console.ReadLine();
                Console.Write("Passsword:");
                string pass = CommonViews.ReadPassword();
                var user = authentication.Login(userName, pass);
                if (user != null)
                {
                   AppState.currentUser = user;
                    CommonViews.PrintSuccess("Login Successful.");
                    CommonViews.PrintSuccess($"Welcome {AppState.currentUser.FirstName} {AppState.currentUser.LastName}");
                    return true;
                }
                else
                {
                    Console.WriteLine();
                    CommonViews.PrintAlert("<=== login failed!!! =====>");
                    CommonViews.PrintAlert("Press (any key)to retry login (1)exit to main menu");
                    if (int.TryParse(Console.ReadLine(), out int opt) && opt == 1)
                    {
                        return false;
                    }
                }
            }
        }
    }

   
}
