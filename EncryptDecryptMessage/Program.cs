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

        static (string, string) CodePlainText(string plainText, string key)
        {
            string codedMessage = "";
            string cleanPlainText = "";
            int keyCounter = 0;

                for (int i = 0; i < plainText.Length; i++)
                {
                    if (keyCounter == key.Length)
                    {
                        keyCounter = 0;
                    }

                    int singleKey = KeyIntValue(key[keyCounter]);

                    if (plainText[i] < 65 || plainText[i] < 97 && plainText[i] > 90 || plainText[i] > 122)
                    {
                        continue;
                    }
                    if (plainText[i] <= 90 && plainText[i] + singleKey > 90 ||
                             plainText[i] >= 97 && plainText[i] + singleKey > 122)
                    {
                        codedMessage += (char) (plainText[i] + singleKey - 26);
                        cleanPlainText += (char) (plainText[i] + singleKey);
                    }
                    else
                    {
                        codedMessage += (char) (plainText[i] + singleKey);
                        cleanPlainText += (char) (plainText[i] + singleKey);
                    }

                    keyCounter++;
                }

            return (codedMessage, cleanPlainText);
        }

        static string GetMultiKey(string multiKeyPlain, string cleanPlainText)
        {
            string multiKeyCoded = "";
            int counter = 0;

            for (int i = 0; counter < cleanPlainText.Length; counter++)
            {
                if (i == multiKeyPlain.Length)
                {
                    i = 0;
                }
                multiKeyCoded += multiKeyPlain[i];
                i++;
            }
            return multiKeyCoded;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Programming Exercise 14");
            Console.WriteLine("Encrypting and Decrypting Messages");
            Console.WriteLine("----------------------------------");

            Console.Write("\nEnter plain text: ");
            string plainText = Console.ReadLine();

            Console.Write("\nEnter your single key as an alpha character: ");
            string singleKey = Console.ReadLine();

            Console.Write("\nEnter your multi key as alpha characters: ");
            string plainMultiKey = Console.ReadLine();

            Console.WriteLine($"\nYou entered [{plainText}] as plain text");
            Console.WriteLine($"You entered [{singleKey}] as you single key");
            Console.WriteLine($"You entered [{plainMultiKey}] as your multi key");

            var (codedMessageSingle, cleanPlainText) = CodePlainText(plainText, singleKey);
            string multiKey = GetMultiKey(plainMultiKey, cleanPlainText);
            string codedMessageMulti = CodePlainText(plainText, multiKey).Item1;

            Console.WriteLine($"\nEncrypted message with single key is [{codedMessageSingle}]");
            Console.WriteLine($"Encrypted message with multi key is [{codedMessageMulti}]");
            Console.WriteLine("Encrypted message with continuous key is [{}]");
        }
    }
}
