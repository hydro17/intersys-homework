using System;
using System.Collections.Generic;
using System.Linq;

namespace ExistingPowersOf2
{
    class Program_ExistingPowersOf2
    {
        static void Main(string[] args)
        {
            IList<uint> uIntegers = GetAnyNumberOfNumbers();

            IEnumerable<uint> uniquePowersOf2_OrderedAsc = GetUniquePowersOf2_OrderedAsc(uIntegers);

            Console.WriteLine(GetComaSeparatedStringOrNA(uniquePowersOf2_OrderedAsc));
        }

        private static IEnumerable<uint> GetUniquePowersOf2_OrderedAsc(IList<uint> uIntegers)
        {
            var uniquePowersOf2_OrderedAsc = uIntegers
                            .SelectMany(ui => GetAllPowersOf2(ui))
                            .Distinct()
                            .OrderBy(i => i);

            return uniquePowersOf2_OrderedAsc;
        }

        private static string GetComaSeparatedStringOrNA(IEnumerable<uint> collection)
        {
            return collection.Count() > 0 ? String.Join(", ", collection) : "NA";
        }

        private static IList<uint> GetAnyNumberOfNumbers()
        {
            IList<uint> uIntegers = new List<uint>();

            while (true)
            {
                string inputStr = Console.ReadLine();

                // Return collection 'uIntegers' when entered empty string
                if (inputStr == "")
                {
                    return uIntegers;
                }

                uIntegers.Add(uint.Parse(inputStr));
            }
        }

        private static IList<uint> GetAllPowersOf2(uint number)
        {
            IList<uint> powersOf2 = new List<uint>();

            for (int i = 0; i <= 31; i++)
            {
                uint powerOf2 = (uint)Math.Pow(2, i) & number;

                if (powerOf2 != 0)
                {
                    powersOf2.Add(powerOf2);
                }
            }

            return powersOf2;
        }
    }
}
