using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommonDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int requiredArrLength = GetArrayLength2To20();

            int[] arrOfInt = GetArrayOfIntegers(requiredArrLength);

            Console.WriteLine($"Most occuring digit is {GetMostOccuringDigit(arrOfInt)}");
        }

        private static int GetMostOccuringDigit(int[] arrOfInt)
        {
            string arrOfIntAsStringOfDigits = getOnlyDigits(String.Join("", arrOfInt));

            char[] arrOfDigits = arrOfIntAsStringOfDigits.ToCharArray();

            var countOfOccurrencesOfDigits = arrOfDigits.GroupBy(
                key_digit => key_digit, 
                digit => digit, //digit, when equal to key_digit, is added to collection of digits assigned to key_digit
                (key_digit, value_collectionOfdigits) => new
                {
                    Digit = int.Parse(key_digit.ToString()),
                    Count = value_collectionOfdigits.Count()
                }
                ).ToArray();

            //foreach (var item in countOfOccurrencesOfDigits)
            //{
            //    Console.WriteLine($"{item.Digit} : {item.Count}");
            //}

            int maxOccurenceCount = countOfOccurrencesOfDigits.Max(d => d.Count);

            return countOfOccurrencesOfDigits.Where(d => d.Count == maxOccurenceCount).Max(d => d.Digit);
        }

        private static string getOnlyDigits(string str)
        {
            Regex removeNonDigits = new Regex(@"[^\d]+");
            string onlyDigits = removeNonDigits.Replace(str, "");

            return onlyDigits;
        }

        private static int[] GetArrayOfIntegers(int requiredArrLength)
        {
            int[] arrOfInt = new int[requiredArrLength];
            bool isArrOfIntOk;

            do
            {
                Console.Write($"Enter {requiredArrLength} integers separated by spaces: ");

                try
                {
                    arrOfInt = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(i => int.Parse(i))
                        .ToArray();

                    if (arrOfInt.Length == requiredArrLength)
                    {
                        isArrOfIntOk = true;
                    }
                    else
                    {
                        Console.WriteLine($"\nThe array should contain {requiredArrLength} elements. Try again.");
                        isArrOfIntOk = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"\nElements of the array should be integers. Try again.");
                    isArrOfIntOk = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"\nAt least one of the given numbers is greater than {Int32.MaxValue} (max integer) " +
                        $"or less than {Int32.MinValue} (min integer).");
                    isArrOfIntOk = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nSomething went wrong. Try again.");
                    isArrOfIntOk = false;
                }

            } while (!isArrOfIntOk);

            return arrOfInt;
        }

        private static int GetArrayLength2To20()
        {
            int arrLength;
            bool isInteger, isInRange;

            do
            {
                isInRange = false;

                Console.Write("Enter array length: ");
                isInteger = int.TryParse(Console.ReadLine(), out arrLength);

                if (!isInteger)
                {
                    Console.WriteLine("\nArray length has to be an integer.");
                }
                else
                {
                    if (arrLength < 2 || arrLength > 20)
                    {
                        Console.WriteLine("\nArray length must be between 2 and 20.");
                        isInRange = false;
                    }
                    else
                    {
                        isInRange = true;
                    }
                }

            } while (!isInteger || !isInRange);

            return arrLength;
        }
    }
}
