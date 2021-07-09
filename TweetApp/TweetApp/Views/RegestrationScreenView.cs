using System;
using System.Collections.Generic;
using System.Text;
using TweetApp.Models;
using TweetApp.Services;
using TweetApp.State;

namespace TweetApp.Views
{
    public class RegestrationScreenView
    {

        private AuthenticationService authentication = new AuthenticationService();
        public bool LoadScreen()
        {
            while (true)
            {
                User newUser = new User();
                CommonViews.PrintTitle(Pages.Regestration);
                Console.Write("First Name:");
                newUser.FirstName = CommonViews.CheckForEmptyString();
                Console.Write("Last Name:");
                newUser.LastName = CommonViews.CheckForEmptyString();
          checkGender: Console.Write("Gender(press [M]-Male,[F]-female):");
                string Gender = Console.ReadLine();
                if(Gender.ToUpper() == "M" || Gender.ToUpper() == "F")
                {
                    newUser.Gender = Gender.ToUpper() == "M" ? "Male" : "Female" ;
                }
                else
                {
                    CommonViews.PrintAlert("Enter Correct option.");
                    goto checkGender;
                }

            DateCheck: Console.Write("Date of Birth(in foemat= dd/mm/yyyyy):");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime dob))
                {
                    newUser.DateOfBirth = dob;
                }
                else
                {
                    CommonViews.PrintAlert("Enter Date in Correct Format.");
                    goto DateCheck;
                }
                newUser.Email = CommonViews.GetEmailAndValidate();
                newUser.UserPassword = CommonViews.SetNewPassword();
                if (!authentication.CheckIfUserAlreadyAvilable(newUser.Email))
                {
                    if (authentication.Regestration(newUser) != null)
                    {
                        CommonViews.PrintSuccess("Yours Information saved SuccessFully Thenks For Regestring :).");
                       AppState.currentUser = newUser;
                        return true;
                    }
                    else
                    {
                        CommonViews.PrintAlert("Something Went wrong we can't save your details can yor register again");
                        CommonViews.PrintAlert("Press (any key)to retry Regestration (1)exit to main menu");
                        if (int.TryParse(Console.ReadLine(), out int opt) && opt == 1)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    CommonViews.PrintAlert("User already avilable.");
                    CommonViews.PrintAlert("Press (any key)to retry Regestration (1)exit to main menu");
                    if (int.TryParse(Console.ReadLine(), out int opt) && opt == 1)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
