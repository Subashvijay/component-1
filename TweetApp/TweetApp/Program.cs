using System;
using TweetApp.Services;
using TweetApp.Views;
using TweetApp.State;

namespace TweetApp
{
    class Program
    {
        static AuthenticationService authentication;
       
       
        static void Main(string[] args)
        {
            authentication = new AuthenticationService();
            LoginScreenView loginScreen = new LoginScreenView();
            HomeScreenView homeScreen = new HomeScreenView();
            RegestrationScreenView regestrationScreen = new RegestrationScreenView();
            AppState.currentUser = null;
            
            while (true)
            {
                try
                {
                    Console.WriteLine("+---------------+------------------+-------------------------+");
                    Console.WriteLine("|(1)Login       |(2)Register       |(3)Forgot Password       |");
                    Console.WriteLine("+---------------+------------------+-------------------------+");
                    Console.WriteLine("Press the option to continue");
                    int optionSelected = CommonViews.CheckValidOptionOrNot(3);
                    switch (optionSelected)
                    {
                        case 1:
                            if (loginScreen.LoadScreen())
                            {
                                homeScreen.LoadScreen();
                            }
                            break;
                        case 2:
                            if (regestrationScreen.LoadScreen())
                            {
                                homeScreen.LoadScreen();
                            }
                            break;
                        case 3:
                            ForgetPassword();
                            break;
                        default:
                            break;
                    };
                }
                catch 
                {
                    CommonViews.PrintAlert("Something Went Wrong with the Service can you try again later.");
                }
            }
        }

        private static void ForgetPassword()
        {
            CommonViews.PrintTitle(Pages.ForgotPassword);
            Console.WriteLine("Enter Email:");
            string email = CommonViews.GetEmailAndValidate();
            if (authentication.CheckIfUserAlreadyAvilable(email))
            {
                CommonViews.PrintSuccess("Password reset link is sent to your regestred email");
            }
            else
            {
                CommonViews.PrintAlert("Entred Email is not regestred");
            }
        }
    }
}
