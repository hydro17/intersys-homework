using System;
using System.Text.RegularExpressions;

namespace Palindrome
{
    class Program_Palindrome
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter a string: ");
            string possiblePalindrome = Console.ReadLine();

            string onlyLettersPossiblePalindrome = getOnlyLetters(possiblePalindrome);
            bool isPallindrome = IsPallindrome(onlyLettersPossiblePalindrome);

            Console.WriteLine(isPallindrome ? "YES" : "NO");
        }

        private static string getOnlyLetters(string str)
        {
            Regex removeNonLetters = new Regex(@"[\W\d_]+");
            string onlyLetters = removeNonLetters.Replace(str, "");

            return onlyLetters;
        }

        private static bool IsPallindrome(string str)
        {
            string possiblePalindrome = str.ToLower();

            for (int i = 0, k = possiblePalindrome.Length - 1; i < k; i++, k--)
            {
                if (possiblePalindrome[i] != possiblePalindrome[k])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
