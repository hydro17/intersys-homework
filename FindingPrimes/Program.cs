using System;
using System.Collections.Generic;
using System.Linq;

namespace FindingPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<(int RangeStart, int RangeEnd)> listOfRangeParameters = GetListOfRangeParameters();

            foreach (var (RangeStart, RangeEnd) in listOfRangeParameters)
            {
                Console.WriteLine(GetCountOfPrimeNumbersInRange(RangeStart, RangeEnd));
            }
        }

        private static int GetCountOfPrimeNumbersInRange(int rangeStart, int rangeEnd)
        {
            IList<int> primeNumbers = new List<int>();

            for (int i = rangeStart; i <= rangeEnd; i++)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }

            return primeNumbers.Count;
        }

        private static bool IsPrime(int number)
        {
            if (number == 1 || (number > 2 && number % 2 == 0))
            {
                return false;
            }

            for (int i = 3; i < number; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static IList<(int, int)> GetListOfRangeParameters()
        {
            int numberOfTestCases = int.Parse(Console.ReadLine());

            var listOfRangeParameters = new List<(int, int)>();

            for (int i = 1; i <= numberOfTestCases; i++)
            {
                int[] rangeParameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => int.Parse(str))
                    .ToArray();

                listOfRangeParameters
                    .Add(ValueTuple.Create(rangeParameters[0], rangeParameters[1]));
            }

            return listOfRangeParameters;
        }
    }
}
