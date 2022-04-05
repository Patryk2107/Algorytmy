using System;

namespace lab6
{
    class IntQueue
    {
        public readonly static int Capacity = 10;
        private int[] _arr = new int[Capacity];
        private int last = -1;
        private int first = -1;
        private int _count = 0;
        public bool Insert(int value)
        {
            if (IsFull())
            {
                throw new Exception();
            }
            _count++;
            last = ++last % Capacity;
            _arr[last] = value ;
            return true;
        }

        public int Remove()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            _count--;
            int result = _arr[first];
            first = ++first % Capacity;
            return result;
        }

        public int Count()
        {
            return _count;
        }
        public bool IsEmpty()
        {
            return _count == 0;
        }
        public bool IsFull()
        {
            return _count == Capacity;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            IntQueue queue = new IntQueue();
            queue.Insert(4);
            queue.Insert(8);
            queue.Insert(3);
            if(queue.Count() == 3 )
            {
                Console.WriteLine("OK");
            }
            if (queue.Remove() == 4)
            {
                Console.WriteLine("OK");
            }
            if (queue.Count() == 2)
            {
                Console.WriteLine("OK");
            }

        }
        
    }
}
