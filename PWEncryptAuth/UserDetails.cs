using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
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
            Console.Write("\tEnter a password: ");
            string unEncryptPwd = Console.ReadLine();
            string encryptedPwd = EncryptPass(unEncryptPwd);
            return encryptedPwd;
        }

        static string EncryptPass(string clearText)
        {
            string pwdHash = "vInSoN0)!";
            byte[] pwdBytes = Encoding.Unicode.GetBytes(clearText);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(pwdHash, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(pwdBytes, 0, pwdBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string DecryptPass(string password)
        {
            string pwdHash = "vInSoN0)!";
            password = password.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(pwdHash, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    password = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return password;
        }

        public static void AuthUser()
        {
            Console.WriteLine("\tLOGIN MENU");
            Console.Write("\tEnter username: ");
            string userName = Console.ReadLine();

            if (usersPasswords.ContainsKey(userName))
            {
                Console.Write("\tEnter password: ");
                string userPwd = EncryptPass(Console.ReadLine());

                if (usersPasswords.ContainsKey(userName))
                {
                    foreach (KeyValuePair<string, string> user in usersPasswords)
                    {
                        if (user.Key == userName && user.Value == userPwd)
                        {
                            Console.WriteLine($"\tWelcome {userName}! (USER AUTHENTICATED)");
                            break;
                        }

                        else if (user.Key == userName && user.Value != userPwd)
                        {
                            Console.WriteLine("\tIncorrect Password - Try Again");
                            AuthUser();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\tUsername doesn't exist. Try establishing a new account!");
            }
        }
    }
}