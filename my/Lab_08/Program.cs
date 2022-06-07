using System;
using System.Collections.Generic;

namespace Lab_08
{
    record Student(string Name, int Ects);

    class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 7, 1, 3, 9, 7, 3, 8, 5 };
            Array.Sort(arr);
            int result = Array.BinarySearch(arr, 5);

            if (result >= 0)
            {
                Console.WriteLine("5 znajduje się pod indeksem " + result);
            }

            else
            {
                Console.WriteLine("Brak w tablicy");
            }

            // ---

            Student[] students =
            {
                new Student("Ewa", 30),
                new Student("Gosia", 45),
                new Student("Basia", 30),
                new Student("Bartek", 19),
                new Student("Kamil", 21),
                new Student("Sebastian", 28),
                new Student("Filip", 20),
                new Student("Grzesiu", 45),
                new Student("Krzysiu", 20),
                new Student("Monika", 64)
            };

            Array.Sort(students, (s1, s2) => s1.Name.CompareTo(s2.Name));
            Console.WriteLine(string.Join<Student>('\n', students));

            Console.WriteLine();

            Array.Sort(students, (s1, s2) => -s1.Ects.CompareTo(s2.Ects));
            Console.WriteLine(string.Join<Student>('\n', students));

            Array.Sort(students, new StudentComparator());
            int std = Array.BinarySearch<Student>(students, new Student("Bartek", 19), new StudentComparator());
            Console.WriteLine("Szukany student jest pod indeksem " + std);

            Console.WriteLine();

            // --- 

            TreeNode<int> root = new TreeNode<int> { Value = 16 };
            root.Left = new TreeNode<int>() { Value = 10 };
            root.Right = new TreeNode<int>() { Value = 20 };
            root.Left.Left = new TreeNode<int>() { Value = 5 };
            root.Left.Right = new TreeNode<int>() { Value = 12 };
            root.Right.Left = new TreeNode<int>() { Value = 17 };
            root.Right.Right = new TreeNode<int>() { Value = 29 };

            BST<int> tree = new BST<int>() { Root = root };
            Console.WriteLine(tree.Contains(20));
            Console.WriteLine(tree.Contains(10));
            Console.WriteLine(tree.Contains(12));

            Console.WriteLine(tree.Insert(50));
            Console.WriteLine(tree.Insert(13));
            Console.WriteLine(tree.Insert(16));

            Console.WriteLine(tree.Contains(50));
            Console.WriteLine(tree.Contains(13));
            Console.WriteLine(tree.Contains(16));
        }
    }

    class BST<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; init; }

        public bool Contains(T value)
        {
            TreeNode<T> node = Root;
            while (node != null)
            {
                //sprwadz czy node.Value = value
                //sprwadz czy node.Value jest wieksze od valuei jesli tak przypisz do node Lewy potomoek
                //w przeciwnym razie przypisz do node prawy potomek
                int treeCompare = node.Value.CompareTo(value);
                if (treeCompare == 0)
                {
                    return true;
                }

                if (treeCompare > 0)
                {
                    node = node.Left;
                }

                else
                {
                    node = node.Right;
                }
            }
            return false;
        }

        public bool Insert(T value)
        {
            TreeNode<T> node = Root;
            TreeNode<T> parent = null;
            while (node != null)
            {
                int treeCompare = node.Value.CompareTo(value);
                if (treeCompare == 0)
                {
                    return false;
                }
                parent = node;
                if (treeCompare > 0)
                {
                    node = node.Left;
                }

                else
                {
                    node = node.Right;
                }
            }

            if (parent.Value.CompareTo(value) > 0)
            {
                parent.Left = new TreeNode<T> { Value = value };
            }

            else
            {
                parent.Right = new TreeNode<T> { Value = value };
            }
            return true;
        }
    }


    class StudentComparator : IComparer<Student>
    {
        public int Compare(Student s1, Student s2)
        {
            int compare = -(s1.Ects.CompareTo(s2.Ects));
            if (compare == 0)
            {
                return s1.Name.CompareTo(s2.Name);
            }
            return compare;
        }
    }
}