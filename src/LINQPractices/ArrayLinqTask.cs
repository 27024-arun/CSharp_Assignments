using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace LINQPractices
{
    internal class ArrayLinqTask
    {
        public void ManipulateArray()
        {
            int[] dataArray = { 97, 7, 18, 1, 1002, 678, 5, 57, 99, 743, 9, 237, 913, 2, 67, 10, 58, 478, 4, 387, 0, 97, 683, 743, 8, 3, 6 };

            Console.Write("The Array data is: ");
            foreach (int data in dataArray)
            {
                Console.Write($"{data} ");
            }

            int secondHigherNumber = dataArray.Distinct().OrderByDescending(data => data).Skip(1).FirstOrDefault();

            Console.WriteLine($"\nThe Second Highest Numeber is : {secondHigherNumber}");
            Console.WriteLine("Enter a Target Number: ");
            int.TryParse(Console.ReadLine(), out int targetNumber);

            var pairs = dataArray
                .SelectMany((value, index) => dataArray.Skip(index + 1).Where(other => value + other == targetNumber)
                .Select(other => new { PairValue1 = value, PairValue2 = other }))
                .ToList();
            if (pairs.Any())
            {
                foreach (var pair in pairs)
                {
                    Console.WriteLine($"{pair.PairValue1} - {pair.PairValue2}");
                }
            }
            else
            {
                Console.WriteLine($"No pairs found");
            }

            Console.WriteLine($"\nEnter any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
