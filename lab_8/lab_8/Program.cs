using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_8
{
    record Student(string Name, int Ects);

    class TreeNode<T>
    {
        public T Values { get; set; }

        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 7, 1, 3, 9, 7, 3, 8, 5 };
            Array.Sort(arr);
            int i = Array.BinarySearch(arr, 3);
            if (i >= 0)
            {
                Console.WriteLine("5 znajduje się pod indeksem " + i);
            }
            else
            {
                Console.WriteLine("Nie ma takiej liczby");
            }
            Student[] students =
            {
                new Student("Ewa", 45),
                new Student("Staszek", 33),
                new Student("Robert", 22),
                new Student("Jan", 14),
                new Student("Ola", 14),
                new Student("Adam", 14),
            };
            Array.Sort(students, (s1, s2) =>
            {
                int compare = -s1.Ects.CompareTo(s2.Ects);
                if (compare == 0)
                {
                    return s1.Name.CompareTo(s2.Name);
                }
                //compare == 0 to s1 identyczne z s2
                //compare < 0 to s1 mniejsze od s2
                //compare > 0 to s1 > s2
                return compare;
            });
            Console.WriteLine(string.Join<Student>("\n", students));
            int std = Array.BinarySearch<Student>(students, new Student("Ewa", 45), new StudentComparator());
            Console.WriteLine("Szukany student jest pod indeksem " + std);

            TreeNode<int> root = new TreeNode<int> { Values = 16 };
            root.Left = new TreeNode<int>() { Values = 10 };
            root.Right = new TreeNode<int>() { Values = 20 };
            root.Left.Left = new TreeNode<int>() { Values = 5 };
            root.Left.Right = new TreeNode<int>() { Values = 12 };
            root.Right.Left = new TreeNode<int>() { Values = 17 };
            root.Right.Right = new TreeNode<int>() { Values = 29 };

            BST<int> tree = new BST<int>() { Root = root };
            Console.WriteLine(tree.Contains(12));
            Console.WriteLine(tree.Contains(13));
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
                if (node.Values.CompareTo(value) == 0)
                {
                    return true;
                }
                if (node.Values.CompareTo(value) > 0)
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

    }
    class StudentComparator : IComparer<Student>
    {
        public int Compare(Student s1, Student s2)
        {

            int compare = -s1.Ects.CompareTo(s2.Ects);
            if (compare == 0)
            {
                return s1.Name.CompareTo(s2.Name);
            }
            //compare == 0 to s1 identyczne z s2
            //compare < 0 to s1 mniejsze od s2
            //compare > 0 to s1 > s2
            return compare;
        }
    }
}
