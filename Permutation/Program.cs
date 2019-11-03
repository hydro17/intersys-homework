﻿using System;
using System.Linq;

namespace Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first array.");
            int[] firstArrOf11Int = GetArrayOfIntegers(11);

            Console.WriteLine("\nEnter the second array.");
            int[] secondArrOf11Int = GetArrayOfIntegers(11);

            Console.WriteLine("\n" + (AreArraysMutuallyPermutable(firstArrOf11Int, secondArrOf11Int) ? "YES" : "NO"));

            //numberOfElement
            //var groupedByElementsOfFirstArray = firstArrOf11Int.GroupBy(
            //    i => i, //key_number 
            //    i => i, //value added to value_collectOfNumbers
            //    (key_number, value_collectOfNumbers) => new
            //        {
            //            Number = key_number,
            //            Count = value_collectOfNumbers.Count()
            //        }
            //    );

            //foreach (var g in groupedByIntOfFirstArr)
            //{
            //    Console.WriteLine($"{g.Number} : {g.Count}");
            //}
        }

        private static bool AreArraysMutuallyPermutable(int[] firstArrOf11Int, int[] secondArrOf11Int)
        {
            return firstArrOf11Int.OrderBy(i => i).SequenceEqual(secondArrOf11Int.OrderBy(i => i));
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
                catch (Exception)
                {
                    Console.WriteLine("\nSomething went wrong. Try again.");
                    isArrOfIntOk = false;
                }

            } while (!isArrOfIntOk);

            return arrOfInt;
        }
    }
}
