using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    public class Stack
    {
        private List<ItemType> _container;

        public Stack()
        {
            _container = new List<ItemType>();
        }

        public bool IsEmpty()
        {
            return _container.Count == 0;
        }

        public void MakeEmpty()
        {
            _container.Clear();
        }

        public void Push(ItemType item)
        {
            _container.Add(item);
        }

        public ItemType Pop()
        {
            if (IsEmpty())
                return null;

            var poppedItem = _container[_container.Count - 1];
            _container.Remove(poppedItem);

            return poppedItem;
        }
    }
}
