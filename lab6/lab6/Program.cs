using System;

namespace lab6
{
    class PriorityQueue
    {
        public readonly static int Capacity = 5;
        public int[] _arr = new int[Capacity];
        public int last = -1;

        private int leftChild(int parent)
        {
            return 2 * parent + 1;
        }
        private int rightChild(int parent)
        {
            return 2 * parent + 2;
        }
        private int Parent(int child)
        {
            return (child - 1) / 2;
        }

        public bool Insert(int value)
        {
            if(Count() == Capacity)
            {
                return false;
            }
            last++;
            _arr[last] = value;

            RebuildUp(last);
            return true;
        }

        private void RebuildUp(int node)
        {
            while (node>0) {
                int parent = Parent(node);
                if (_arr[node] > _arr[parent])
                {
                    int temp = _arr[node];
                    _arr[node] = _arr[parent];
                    _arr[parent] = temp;

                    node = parent;
                }
                else
                {
                    break;
                }
            }
        }
        public int Remove()
        {
            int removed = _arr[0];
            _arr[0] = _arr[last - 1];
            Rebuilddown();
        }

        private void Rebuilddown()
        {
            int node = 0;
            while(node >= last)
            {
                int leftChildValue = _arr[leftChild(node)];
                int rightChildValue = _arr[rightChild(node)];
                if (_arr[node] > leftChildValue && _arr[node] > rightChildValue)
                {
                    break;
                }

            }
        }
        public int Count()
        {
            return last + 1;
        }
    }
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
            Console.WriteLine(queue.Count());

            PriorityQueue priorityQueue = new PriorityQueue();
            priorityQueue.Insert(7);
            priorityQueue.Insert(2);
            priorityQueue.Insert(9);
            priorityQueue.Insert(3);
            Console.WriteLine("heap");
            foreach(int item in priorityQueue._arr)
            {
                Console.WriteLine(item);
            }
        }
 
        
    }
}
