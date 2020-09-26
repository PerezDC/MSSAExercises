using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace PWEncryptAuth
{
    class UserDetails
    {
        public static Dictionary<string, string> usersPasswords = new Dictionary<string, string>();

        public static void CreateNew()
        {
            string userName = NewUsername();
            string userPassword = NewPassword();

            usersPasswords.Add(userName, userPassword);
            Console.WriteLine($"\n\n\tThanks {userName}! Username and password saved!");
        }

        static string NewUsername()
        {
            Console.Write("\n\tEnter a username: ");
            string userId = Console.ReadLine();
            if (usersPasswords.ContainsKey(userId))
            {
                Console.Write("\tUsername taken! Try another: ");
                userId = Console.ReadLine();
            }

            Console.WriteLine($"\t{userId} is available.");
            return userId;
        }

        static string NewPassword()
        {
            string unEncryptPwd, encryptedPwd;

            Console.Write("\tEnter a password: ");
            unEncryptPwd = Console.ReadLine();
            //TODO: add encryption body

            return encryptedPwd;
        }


    }

}
