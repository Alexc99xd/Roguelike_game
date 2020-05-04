using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Controller
{
    public class KeyPressStack<T>
    {
        private List<T> items = new List<T>();

        public void Push(T item)
        {
            items.Add(item);
        }

        public T Peek()
        {
            if (items.Count == 0)
            {
                return default;
            }
            return items[items.Count - 1];
        }

        public T Pop()
        {
            if (items.Count == 0)
            {
                return default;
            }
            T temp = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return temp;
        }

        public void Remove(T itemToRemove)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(itemToRemove))
                {
                    items.RemoveAt(i);
                    break;
                }
            }
        }

        public int Length()
        {
            return items.Count;
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
