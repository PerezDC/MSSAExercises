using System;

namespace EncryptDecryptMessage
{
    public class Program
    {
        public static int KeyIntValue(char singleKey)
        {
            int charValue;
            if (singleKey >= 97)
            {
                charValue = singleKey - 96;
            }
            else
            {
                charValue = singleKey - 64;
            }
            return charValue;
        }

        public static (string, string) EncryptDecryptText(string plainText, string key, bool decrypt = false)
        {
            string codedMessage = "";
            string cleanPlainText = "";
            int keyCounter = 0;

            if (decrypt == false)
            {
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
                        cleanPlainText += plainText[i];
                    }
                    else
                    {
                        codedMessage += (char) (plainText[i] + singleKey);
                        cleanPlainText += plainText[i];
                    }
                    keyCounter++;
                }
            }
            else
            {
                for (int i = 0; i < plainText.Length; i++)
                {
                    if (keyCounter == key.Length)
                    {
                        keyCounter = 0;
                    }

                    int singleKey = KeyIntValue(key[keyCounter]);

                    if (plainText[i] <= 90 && plainText[i] - singleKey < 65 || plainText[i] >= 97 && plainText[i] - singleKey < 97)
                    {
                        codedMessage += (char)(plainText[i] - singleKey + 26);
                    }
                    else
                    {
                        codedMessage += (char)(plainText[i] - singleKey);
                    }
                    keyCounter++;
                }
            }
            return (codedMessage, cleanPlainText);
        }

        public static string GetMultiKey(string plainMultiKey, string cleanPlainText)
        {
            string multiKeyCoded = "";
            int counter = 0;

            for (int i = 0; counter < cleanPlainText.Length; counter++)
            {
                if (i == plainMultiKey.Length)
                {
                    i = 0;
                }
                multiKeyCoded += plainMultiKey[i];
                i++;
            }
            return multiKeyCoded;
        }

        public static string GetContinuousKey(string plainMultiKey, string cleanPlainText)
        {
            string tempKey = plainMultiKey;
            int keySize = cleanPlainText.Length;

            for (int i = 0; tempKey.Length < keySize; i++)
            {
                tempKey += cleanPlainText[i];
            }

            return tempKey;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Programming Exercise 14");
            Console.WriteLine("Encrypting and Decrypting Messages");
            Console.WriteLine("----------------------------------");

            Console.Write("\nEnter plain text: ");
            string plainText = Console.ReadLine();

            Console.Write("Enter your single key as an alpha character: ");
            string singleKey = Console.ReadLine();

            Console.Write("Enter your multi key as alpha characters: ");
            string plainMultiKey = Console.ReadLine();

            Console.WriteLine($"\nYou entered [{plainText}] as plain text");
            Console.WriteLine($"You entered [{singleKey}] as your single key");
            Console.WriteLine($"You entered [{plainMultiKey}] as your multi key");

            var (codedMessageSin, cleanPlainText) = EncryptDecryptText(plainText, singleKey);
            string multiKey = GetMultiKey(plainMultiKey, cleanPlainText);
            string codedMessageMult = EncryptDecryptText(plainText, multiKey).Item1;
            string continuousKey = GetContinuousKey(plainMultiKey, cleanPlainText);
            string codedMessageCont = EncryptDecryptText(plainText, continuousKey).Item1;

            Console.WriteLine($"\nEncrypted message with single key is [{codedMessageSin}]");
            Console.WriteLine($"Encrypted message with multi key is [{codedMessageMult}]");
            Console.WriteLine($"Encrypted message with continuous key is [{codedMessageCont}]");

            Console.WriteLine($"\nDecrypted message with single key is [{EncryptDecryptText(codedMessageSin, singleKey, true).Item1}]");
            Console.WriteLine($"Decrypted message with multi key is [{EncryptDecryptText(codedMessageMult,multiKey, true).Item1}]");
            Console.WriteLine($"Decrypted message with continuous key is [{EncryptDecryptText(codedMessageCont,continuousKey, true).Item1}]");

            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}
