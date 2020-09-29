using System;

namespace EncryptDecryptMessage
{
    class Program
    {
        static int KeyIntValue(char singleKey)
        {
            int charValue = 0;
            if ((int)singleKey >= 97)
            {
                charValue = (int)singleKey - 96;
            }
            else
            {
                charValue = (int)singleKey - 64;
            }
            return charValue;
        }

        static string CodePlainText(string plainText, int singleKey)
        {
            string codedMessage = "";

            for (int i = 0; i < plainText.Length; i++)
            {
                if (plainText[i] < 65 || plainText[i] < 97 && plainText[i] > 90 || plainText[i] > 122)
                {
                    continue;
                }
                else if (plainText[i] <= 90 && plainText[i] + singleKey > 90 || plainText[i] >= 97 && plainText[i] + singleKey > 122) 
                {
                    codedMessage += Convert.ToChar(plainText[i] + singleKey - 26);
                }
                else
                {
                    codedMessage += Convert.ToChar(plainText[i] + singleKey);
                }
            }

            return codedMessage;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Programming Exercise 14");
            Console.WriteLine("Encrypting and Decrypting Messages");
            Console.WriteLine("----------------------------------");

            Console.Write("\nEnter plain text: ");
            string plainText = Console.ReadLine();

            Console.Write("\nEnter your single key as an alpha character: ");
            int singleKey = KeyIntValue(Convert.ToChar(Console.ReadLine()));

            string codedMessage = CodePlainText(plainText, singleKey);
            Console.WriteLine($"Encrypted message with single key is [{codedMessage}]");

        }
    }
}
