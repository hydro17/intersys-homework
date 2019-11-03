using System;
using System.Linq;

namespace DigitSum
{
    class Program_DigitSum
    {
        static void Main(string[] args)
        {
            int requiredArrLength = GetArrayLength();
            int[] arrOfPositiveInt = GetArrayOfPositiveIntegers(requiredArrLength);

            Console.WriteLine(GetArrayIndexForHighestNumberWithMaxSumOfDigits(arrOfPositiveInt));
        }

        private static int GetArrayIndexForHighestNumberWithMaxSumOfDigits(int[] arr)
        {
            return Array.IndexOf(arr, GetHighestNumberWithMaxSumOfDigits(arr));
        }

        private static int GetHighestNumberWithMaxSumOfDigits(int[] arrOfPositiveInt)
        {
            var numbersAndSumOfDigits = arrOfPositiveInt
                            .Select(positiveNumber => new
                            {
                                Number = positiveNumber,
                                SumOfDigits = SumOfDigitsOfPositiveNumber(positiveNumber)
                            }).ToArray();

            int maxSumOfDigits = numbersAndSumOfDigits.Max(number => number.SumOfDigits);

            int highestNumberWithMaxSumOfDigits = numbersAndSumOfDigits
                .Where(number => number.SumOfDigits == maxSumOfDigits)
                .Max(number => number.Number);

            return highestNumberWithMaxSumOfDigits;
        }

        private static int SumOfDigitsOfPositiveNumber(int positiveNumber)
        {
            char[] digitsAsChars = positiveNumber.ToString().ToCharArray();

            int sumOfDigits = 0;

            foreach (char digitAsChar in digitsAsChars)
            {
                sumOfDigits += int.Parse(digitAsChar.ToString());
            }

            return sumOfDigits;
 
            //Is this solution KISS rule violation?
            //return positiveNumber.ToString().ToCharArray()
            //    .Aggregate(
            //        seed: 0,
            //        func: (sum, digitAsChar) => sum + int.Parse(digitAsChar.ToString())
            //    );
        }

        private static int[] GetArrayOfPositiveIntegers(int requiredArrLength)
        {
            int[] arrOfInt = new int[requiredArrLength];
            bool isArrOfIntOk;

            do
            {
                //Console.Write($"Enter {requiredArrLength} positive integers separated by spaces: ");

                try
                {
                    arrOfInt = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(i => int.Parse(i))
                        .ToArray();

                    if (arrOfInt.Length == requiredArrLength)
                    {
                        if (AreAllNumbersInArrayPositive(arrOfInt))
                        {
                            isArrOfIntOk = true;
                        }
                        else
                        {
                            Console.WriteLine("\nSome numbers in the array are not positive. Try again.");
                            isArrOfIntOk = false;
                        }
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

        private static bool AreAllNumbersInArrayPositive(int[] arr)
        {
            foreach (int i in arr)
            {
                if (i < 0) return false;
            }

            return true;
        }

        private static int GetArrayLength()
        {
            int arrLength;
            bool isInteger;

            do
            {
                //Console.Write("Enter array length: ");
                isInteger = int.TryParse(Console.ReadLine(), out arrLength);

                if (!isInteger)
                {
                    Console.WriteLine("\nArray length has to be an integer.");
                }

            } while (!isInteger);

            return arrLength;
        }
    }
}
