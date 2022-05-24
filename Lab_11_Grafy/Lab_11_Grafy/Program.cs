﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_11_Grafy
{

    interface IGraph
    {
        bool AddDirectedEdge(int source, int target, int weight);

        bool AddUndirectedEdge(int source, int target, int weight);

        void Traversal(int start, Action<int> action);

    }
    class AddMatrixGraph : IGraph
    {
        private int[,] _matrix;

        public AddMatrixGraph(int size)
        {
            _matrix = new int[size, size];
        }

        public bool AddDirectedEdge(int source, int target, int weight)
        {
            if (source >= 0 && source < _matrix.GetLength(0) &&
                target >=0 && target < _matrix.GetLength(1))
            {
                _matrix[source, target] = weight;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddUndirectedEdge(int source, int target, int weight)
        {
            return AddDirectedEdge(source, target, weight) && AddDirectedEdge(target, source, weight);
        }

        public void Traversal(int start, Action<int> action)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int row =0; row < _matrix.GetLength(0); row++)

            {
                sb.Append($"wierzcholek {row} ma krawedzi z: ");
                for (int col = 0; col<_matrix.GetLength(1); col++)

                {
                    if(_matrix[row, col] != 0)
                    {
                       
                        if (_matrix[row, col] != 0)
                        {
                            sb.Append(col + " ");
                        }
                       
                    }
                    sb.AppendLine();
                }

            }
            return sb.ToString();
        }
    }

    record Edge
    {
        public int Target { get; set; }
        public int Weight { get; set; }
    }

    class AddListGraph : IGraph
    {
        private Dictionary<int, HashSet<Edge>> _edges = new Dictionary<int, HashSet<Edge>>();

        public bool AddDirectedEdge(int source, int target, int weight)
        {
            if (_edges.ContainsKey(source))
            {
                _edges.Add(source, new HashSet<Edge>());

            }
            if (!_edges.ContainsKey(target))
            {
                _edges.Add(target, new HashSet<Edge>());
            }
            _edges[source].Add(new Edge() { Target = target , Weight = weight });
            return true;
        }

        public bool AddUndirectedEdge(int source, int target, int weight)
        {
            return AddDirectedEdge(source, target, weight) && AddDirectedEdge(target, source, weight);
        }

        public void Traversal(int start, Action<int> action)
        {
            Queue<int> q = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            q.Enqueue(start);
            while(q.Count > 0)
            {
                int node = q.Dequeue();
                if (visited.Contains(node))
                {
                    continue;
                }
                action.Invoke(node);
                visited.Add(node);
                HashSet<Edge> children = _edges[node];
                foreach(var edge in children)
                {
                    q.Enqueue(edge.Target);
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _edges)
            {
                sb.Append($"Wierzcholek {item.Key} ma krawedzie z : ");
                foreach(var edge in item.Value)
                {
                    sb.Append($"{edge.Target} ({edge.Weight})");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IGraph graph = new AddListGraph(4);
            graph.AddDirectedEdge(0, 1, 3);
            graph.AddDirectedEdge(0, 2, 2);
            graph.AddDirectedEdge(2, 0, 8);
            graph.AddUndirectedEdge(2, 0, 8);
            graph.AddUndirectedEdge(0, 3, 9);
            graph.AddDirectedEdge(3, 3, 1);
            Console.WriteLine(graph);
            graph.Traversal(0, node => Console.WriteLine(node));



        }
    }
}
