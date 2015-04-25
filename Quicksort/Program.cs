using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> userItems = null;

            while (userItems == null)
            {
                userItems = GetInputFromUser();

                if (userItems == null)
                {
                    Console.WriteLine("Invalid input, please try again.");
                    Console.WriteLine(Environment.NewLine);
                }
            }

            Console.WriteLine("Recursive Quicksort");
            Console.WriteLine("===================");
            Quicksort.RecursiveQuicksort(new List<int>(userItems), 0, userItems.Count - 1);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Iterative Quicksort");
            Console.WriteLine("===================");
            Quicksort.IterativeQuicksort(new List<int>(userItems), 0, userItems.Count - 1);
        }

        static List<int> GetInputFromUser()
        {
            Console.Write("Please insert the amount of numbers following the numbers themselves with at least one whitespace between them: ");
            var inputString = Console.ReadLine();

            if (string.IsNullOrEmpty(inputString))
                return null;

            var stringNumbers = inputString.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var stringNumbersLength = stringNumbers.Length;

            var numbers = new List<int>();
            for (int i = 0; i < stringNumbersLength; i++)
            {
                int tempNum;
                if (!int.TryParse(stringNumbers[i], out tempNum))
                    return null;

                if (i != 0) //ignoring the length since using the list's "Count" property
                    numbers.Add(tempNum);
            }

            return numbers;
        }
    }
}
