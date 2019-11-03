using System;
using System.Linq;

namespace ReverseArray
{
    class Program_ReverseArray
    {
        static void Main(string[] args)
        {
            int requiredArrLength = GetArrLength();
            Console.WriteLine();

            int[] arrOfInt = GetArrayOfIntegers(requiredArrLength);

            Array.Reverse(arrOfInt);
            Console.WriteLine(String.Join(" ", arrOfInt));
            //Console.WriteLine("Reversed integers: " + String.Join(" ", arrOfInt));
        }

        private static int[] GetArrayOfIntegers(int requiredArrLength)
        {
            int[] arrOfInt = new int[requiredArrLength];
            bool isArrOfIntOk;

            do
            {
                //Console.Write($"Enter {requiredArrLength} integers separated by spaces: ");

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
                catch (Exception)
                {
                    Console.WriteLine("\nSomething went wrong. Try again.");
                    isArrOfIntOk = false;
                }

            } while (!isArrOfIntOk);

            return arrOfInt;
        }

        private static int GetArrLength()
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
