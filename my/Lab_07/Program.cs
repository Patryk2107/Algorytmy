using System;
using System.Collections.Generic;

namespace lab_07
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node(T value, Node<T> next = null)
        {
            Value = value;
            Next = next;
        }
    }
    // Ex 3
    public class Stack<T>
    {
        private Node<T> _head;

        public void Push(T value)
        {
            Node<T> node = new Node<T>(value, _head);
            _head = node;
        }

        public T Pop()
        {
            if (IsEmpty()) throw new Exception("Empty Stack");
            T result = _head.Value;
            _head = _head.Next;
            return result;
        }
        public bool IsEmpty()
        {
            return _head == null;
        }
        // Ex 3
        public void Reverse()
        {
            Stack<T> Temp = (Stack<T>)this.MemberwiseClone();
            this._head = null;
            while (!Temp.IsEmpty())
            {
                this.Push(Temp.Pop());
            }
        }
    }
    // Ex 1
    public class LinkedStack<T> : LinkedList<T>
    {
        public void Push(T value)
        {
            AddFirst(value);
        }

        public T Pop()
        {
            T result = First.Value;
            if (First == null) throw new Exception("Empty Stack!");
            RemoveFirst();
            return result;
        }
    }

    public class LinkedQueue<T> : LinkedList<T>
    {
        public void Enqueue(T value)
        {
            AddLast(value);
        }

        public T Dequeue()
        {
            if (First == null) throw new Exception("Empty Queue!");
            T result = First.Value;
            RemoveLast();
            return result;
        }
    }

    // Ex 2
    public class Queue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public void Enqueue(T value)
        {
            Node<T> node = new Node<T>(value);
            _tail.Next = node;
            _tail = node;
        }
        public T Dequeue()
        {
            if (IsEmpty()) throw new Exception("Empty Queue!");
            T result = _head.Value;
            _head = _head.Next;
            return result;
        }
        public bool IsEmpty()
        {
            return _head == null;
        }
    }

    // Ex 5
    public class MyLinkedList<T> : LinkedList<T>
    {
        public LinkedListNode<T> GetElementByIndex(int id)
        {
            if (Count < id) throw new ArgumentException($"There is no element at index {id}");

            LinkedListNode<T> result;
            if ((Count - id) > (Count / 2))
            {
                result = First;
                for (int i = 0; i <= id; i++)
                {
                    result = result.Next;
                }
            }
            else
            {
                result = Last;
                for (int i = Count - 1; i >= id; i--)
                {
                    result = result.Previous;
                }
            }
            return result;
        }
        public void AddAfter(int id, LinkedListNode<T> NewNode)
        {
            base.AddAfter(GetElementByIndex(id), NewNode);
        }

        public void AddBefore(int id, LinkedListNode<T> NewNode)
        {
            base.AddBefore(GetElementByIndex(id), NewNode);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(5);
            stack.Push(7);
            stack.Push(2);

            stack.Reverse();

            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }

            string test = "[(test string) && (untested string) o ((get()=>{value}))]"; // correct
            string test2 = "[(test string) } && (untested string) o ((get()=>{value}))]"; // incorrect

            Console.WriteLine(CheckBrackets(test)); // true
            Console.WriteLine(CheckBrackets(test2)); // false

        }
        // Ex 4
        static public bool CheckBrackets(string str)
        {
            Stack<char> brackets = new Stack<char>();
            char lastBracket = ' ';
            foreach (char x in str)
            {
                if ((x == '[') || (x == '(') || (x == '{'))
                {
                    brackets.Push(x);
                    lastBracket = x;
                }
                else if (((lastBracket == '[') && (x == ']')) || ((lastBracket == '(') && (x == ')')) || ((lastBracket == '{') && (x == '}')))
                {
                    brackets.Pop();
                    if (brackets.IsEmpty()) continue;
                    lastBracket = brackets.Pop();
                    brackets.Push(lastBracket);
                }
                else if ((x == '}') || (x == ')') || (x == ']')) return false;
            }
            return brackets.IsEmpty();
        }
    }
}

