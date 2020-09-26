using System;

namespace PWEncryptAuth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EX 3A - C# - Password Encryption and Authentication");
            /*
             * Interface should have three options:
                  - save a new password for a specific username,
                  - authenticate a specific username/password pair, or
                  - exit the application.
             */
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("\n\tPASSWORD AUTHENTICATION SYSTEM");
            Console.WriteLine("\n\tPlease select one option: .");
            Console.WriteLine("\t1. Establish an account ");
            Console.WriteLine("\t2. Authenticate a user ");
            Console.WriteLine("\t3. Exit the system");
            Console.Write("\n\tEnter selection: ");
            string userInput = Console.ReadLine();
            Console.WriteLine("\n--------------------------------------------------------------------");
            if (userInput == "1")
            {
                UserDetails.CreateNew();

                foreach (var item in UserDetails.usersPasswords)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
            }


        }
    }

}
