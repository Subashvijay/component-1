

using System;
using System.Text.RegularExpressions;

namespace TweetApp.Views
{
    enum Pages
    {
        Login,
        Home,
        Regestration,
        ForgotPassword
    }
    static class CommonViews
    {


        public static string ReadPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }

        public static int CheckValidOptionOrNot(int limit)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int num) && num <= limit && num != 0)
                {
                    return num;
                }
                else
                {
                    PrintAlert("Enter correct options !!!");
                }
            }
        }


        public static void PrintTitle(Pages type)
        {
            Console.WriteLine();
            Console.WriteLine("+===================================================================+");
            switch (type)
            {
                case Pages.Login:
                    Console.WriteLine("|                       Login                                       |");
                    break;
                case Pages.Regestration:
                    Console.WriteLine("|                       Registration                                |");
                    break;
                case Pages.Home:
                    Console.WriteLine("|                      [^v^]tweet app                               |");
                    break;
                case Pages.ForgotPassword:
                    Console.WriteLine("|                       Forgot Password                              |");
                    break;
                default:
                    break;
            }
            Console.WriteLine("+===================================================================+");
        }


        public static void PrintAlert(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string GetEmailAndValidate()
        {
        EmailCheck: Console.Write("Email:");
            string email = Console.ReadLine();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                return email;
            }
            else
            {
                PrintAlert("Enter Corrent Email Format.");
                goto EmailCheck;
            }
        }

        public static string SetNewPassword()
        {
        PassWordCheck: Console.Write("Enter Password(min 8 characters):");
            string pass = CommonViews.ReadPassword();
            if (pass.Length < 8)
            {
                CommonViews.PrintAlert("Passsword Must be Minimum 8 Characters.");
                goto PassWordCheck;
            }
            Console.Write("Confirm Password:");
            string confPass = CommonViews.ReadPassword();
            if (pass == confPass)
            {
              return  pass;
            }
            else
            {
                CommonViews.PrintAlert("Password and confirm password are not same.");
                goto PassWordCheck;
            }

        }

        public static string CheckForEmptyString()
        {
          checkString:  string  val= Console.ReadLine();
            if(string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val))
            {
                PrintAlert("Value Should not be Empty !!");
                goto checkString;
            }
            return val;
        }

    }
}
