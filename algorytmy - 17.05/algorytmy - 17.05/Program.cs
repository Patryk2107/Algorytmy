using algorytmy___17._05;
using System;
using System.Collections.Generic;

namespace algorytmy___17._05
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }



    }

    class Tree<T>
    {
        public Node<T> Root { get; init;}

        public void PreOrderTraversal(Action<Node<T>> action)
        {
            PreOrder(Root, action);
        }
        private void PreOrder(Node<T> node, Action<Node<T>> action)
        {
            if(node == null)
            {
                return;
            }
            action.Invoke(node);
            PreOrder(node.Left, action);
            PreOrder(node.Right, action);
        }
        public void PostOrderTraversal(Action<Node<T>> action)
        {
            PostOrder(Root, action);
        }
        private void PostOrder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
            {
                return;
            }
            
            PostOrder(node.Left, action);
            PostOrder(node.Right, action);
            action.Invoke(node);

        }
        public void InOrderTraversal(Action<Node<T>> action)
        {
            InOrder(Root, action);
        }
        private void InOrder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
            {
                return;
            }
            InOrder(node.Left, action);
            action.Invoke(node);
            InOrder(node.Right, action);
            
        }
        public void LevelTraversal(Action<Node<T>> action)
        {
            Queue<Node<T>> q = new Queue <Node<T>>();
            q.Enqueue(Root);
            while(q.Count>0)
            {
                Node < T > node = q.Dequeue();
                action.Invoke(node);
            if(node.Left != null)
                {
                    q.Enqueue(node.Left);
                }
                if(node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }
        public List<T[]> GetPaths()
        {
            Stack<T> stack = new Stack<T>();
            List<T[]> list = new List<T[]>();
            GetPath(Root, stack, list);
            return list;
        }
        private void GetPath(Node<T> node, Stack<T> stack, List<T[]> list)
        {
            stack.Push(node.Value);
            if (node.Left == null && node.Right == null)
            {
                list.Add(stack.ToArray());

                stack.Pop();
                return;
            }
            if (node.Left != null) {
                GetPath(node.Left, stack, list);
            }
            if (node.Right != null) { 
            GetPath(node.Right, stack, list);
                 }
            stack.Pop();
        }
    }
    class Expression: Tree<string>
    {
        private double EvaluateNode(Node<string> node)
        {
            switch (node.Value)
            {
                case "+":
                    return EvaluateNode(node.Left) + EvaluateNode(node.Right);
                case "-":
                    return EvaluateNode(node.Left) - EvaluateNode(node.Right);
                case "*":
                    return EvaluateNode(node.Left) * EvaluateNode(node.Right);
                case "/":
                    return EvaluateNode(node.Left) / EvaluateNode(node.Right);
                default:
                    return double.Parse(node.Value);
            }
        }
    }

       }
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> node = new Node<string>() { Value = "A" };
            node.Left = new Node<string>(){  Value = "B"};
            node.Right = new Node<string>() { Value = "C" };
            node.Left.Left = new Node<string>() { Value = "D" };
            node.Right.Right = new Node<string>() { Value = "E" };
            Tree<string> tree = new Tree<string> { Root = node };
            tree.PreOrderTraversal(node => Console.WriteLine(node.Value));

        Console.WriteLine();

        tree.InOrderTraversal(node => Console.Write(node.Value));
        Console.WriteLine();
        tree.PostOrderTraversal(node => Console.Write(node.Value));
        //Poziomami
        Console.WriteLine();
        tree.LevelTraversal(n => Console.WriteLine(n.Value));

        List<string[]> paths = tree.GetPaths();
        foreach(var path in paths)
        {
            Console.WriteLine(string.Join ", " + paths);
        }

    }
    }


