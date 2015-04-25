using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    public class ItemType
    {
        public ItemType(ReturnLocation returnLocation, int leftIndex, int rightIndex, int pivotIndex)
        {
            ReturnLocation = returnLocation;
            LeftIndex = leftIndex;
            RightIndex = rightIndex;
            PivotIndex = pivotIndex;
        }

        public ReturnLocation ReturnLocation { get; set; }
        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }
        public int PivotIndex { get; set; }
    }
}
