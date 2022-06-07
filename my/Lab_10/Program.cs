using System;
using System.Linq.Expressions;

namespace Lab_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> node = new Node<string>() { Value = "A" };
            node.Left = new Node<string>() { Value = "B" };
            node.Right = new Node<string>() { Value = "C" };
            node.Left.Left = new Node<string>() { Value = "D" };
            node.Left.Right = new Node<string>() { Value = "E" };
            node.Right.Left = new Node<string>() { Value = "F" };
            node.Right.Right = new Node<string>() { Value = "G" };

            Tree<string> tree = new Tree<string> { Root = node };
            tree.PreOrderTraversal(node => Console.Write(node.Value));
            Console.WriteLine();
            tree.PostOrderTraversal(node => Console.Write(node.Value));
            Console.WriteLine();
            tree.InOrderTraversal(node => Console.Write(node.Value));      
        }
    }
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }
    class Expression : Tree<string>
    {
        public double Evaluate()
        {
            return EvaluateNode(Root);
        }
        public double EvaluateNode(Node<string> node)
        {
            switch (node.Value)
            {
                case "+": return EvaluateNode(node.Left) + EvaluateNode(node.Right);
                case "-": return EvaluateNode(node.Left) - EvaluateNode(node.Right);
                case "*": return EvaluateNode(node.Left) * EvaluateNode(node.Right);
                case "/": return EvaluateNode(node.Left) / EvaluateNode(node.Right);
                default: return double.Parse(node.Value);
            }
        }
    }

    class Tree<T>
    {
        public Node<T> Root { get; init; }
        public void PreOrderTraversal(Action<Node<T>> action)
        {
            PreOrder(Root, action);
        }
        public void PostOrderTraversal(Action<Node<T>> action)
        {
            PostOrder(Root, action);
        }
        public void InOrderTraversal(Action<Node<T>> action)
        {
            InOrder(Root, action);
        }
        public void PreOrder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
                return;

            action.Invoke(node);
            PreOrder(node.Left, action);
            PreOrder(node.Right, action);
        }
        public void PostOrder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
                return;
            PostOrder(node.Left, action);
            PostOrder(node.Right, action);
            action.Invoke(node);
        }
        public void InOrder(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
                return;
            InOrder(node.Left, action);
            action.Invoke(node);
            InOrder(node.Right, action);

        }
    }

}
