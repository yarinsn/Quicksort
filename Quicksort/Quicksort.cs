using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    public static class Quicksort
    {
        public static void RecursiveQuicksort(List<int> items, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
                return;

            var pivotIndex = Partition(items, leftIndex, rightIndex);

            RecursiveQuicksort(items, leftIndex, pivotIndex - 1);
            RecursiveQuicksort(items, pivotIndex + 1, rightIndex);
        }

        public static void IterativeQuicksort(List<int> items, int leftIndex, int rightIndex)
        {
            var stack = new Stack();
            var currIteration = new ItemType(ReturnLocation.Start, leftIndex, rightIndex, -1);
            ItemType nextIteration = null;

            stack.Push(currIteration);

            while (!stack.IsEmpty())
            {
                currIteration = stack.Pop();

                if (currIteration.ReturnLocation == ReturnLocation.Start)
                {
                    if (currIteration.LeftIndex >= currIteration.RightIndex)
                        continue;
                    else
                    {
                        var pivotIndex = Partition(items, currIteration.LeftIndex, currIteration.RightIndex);

                        currIteration = new ItemType(ReturnLocation.AfterFirst, currIteration.LeftIndex, currIteration.RightIndex, pivotIndex);
                        stack.Push(currIteration);

                        nextIteration = new ItemType(ReturnLocation.Start, currIteration.LeftIndex, currIteration.PivotIndex - 1, -1);
                        stack.Push(nextIteration);
                    }
                }
                else if (currIteration.ReturnLocation == ReturnLocation.AfterFirst)
                {
                    currIteration.ReturnLocation = ReturnLocation.AfterSecond;
                    stack.Push(currIteration);

                    nextIteration = new ItemType(ReturnLocation.Start, currIteration.PivotIndex + 1, currIteration.RightIndex, -1);
                    stack.Push(nextIteration);
                }
                else if (currIteration.ReturnLocation == ReturnLocation.AfterSecond)
                    continue; //do nothing
            }
        }

        private static int Partition(List<int> items, int pivotIndex, int otherIndex)
        {
            var isPivotOnTheLeft = pivotIndex < otherIndex;

            if (items[pivotIndex] < items[otherIndex] ^ isPivotOnTheLeft)
                Swap(items, ref pivotIndex, ref otherIndex, ref isPivotOnTheLeft);

            PrintItems(items);

            if (isPivotOnTheLeft)
                otherIndex--;
            else
                otherIndex++;

            if (otherIndex == pivotIndex)
                return pivotIndex;
            else
                return Partition(items, pivotIndex, otherIndex);
        }

        private static void Swap(List<int> userInput, ref int index1, ref int index2, ref bool isPivotOnTheLeft)
        {
            //swapping items
            userInput[index1] = userInput[index1] + userInput[index2];
            userInput[index2] = userInput[index1] - userInput[index2];
            userInput[index1] = userInput[index1] - userInput[index2];

            //swapping indexs
            index1 = index1 + index2;
            index2 = index1 - index2;
            index1 = index1 - index2;
            isPivotOnTheLeft = !isPivotOnTheLeft;
        }

        private static void PrintItems(List<int> items)
        {
            StringBuilder itemsStr = new StringBuilder();
            foreach (var item in items)
                itemsStr.Append(string.Format("{0} ", item));

            Console.WriteLine(itemsStr.ToString());
            Console.ReadLine();
        }
    }
}
