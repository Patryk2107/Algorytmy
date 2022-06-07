using System;

namespace Lab_06
{
    class Program
    {
        static void Main(string[] args)
        {
            IntQueue queue = new IntQueue();
            queue.Insert(4);
            queue.Insert(2);
            queue.Insert(1);
            queue.Insert(4);
            queue.Insert(2);
            queue.Insert(1);
            queue.Insert(4);
            queue.Insert(2);
            queue.Insert(1);
            queue.Insert(4);
            queue.Insert(2);
            queue.Insert(1);

            Console.WriteLine(queue.Remove());
            Console.WriteLine(queue.Remove());

            queue.Insert(6);

            Console.WriteLine("Size:" + queue.Count);

            Console.WriteLine(queue.Remove());
            Console.WriteLine(queue.Remove());

        }
    }

    class IntQueue
    {
        public readonly static int Capacity = 10;
        private int[] table = new int[Capacity];
        private int last = 0;
        private int first = 0;
        private int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool Insert(int value)
        {
            if (isFull()) return false;

            if (last == Capacity) last = 0;

            table[last++] = value;
            count++;
            return true;
        }

        public int Remove()
        {
            if (isEmpty()) throw new Exception("Kolejka pusta!");
            count--;
            return table[first++];
        }

        public bool isEmpty()
        {
            return count == 0;
        }

        public bool isFull()
        {
            return count == Capacity;
        }

    }

}
