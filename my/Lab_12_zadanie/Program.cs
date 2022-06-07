using System;
using System.Collections.Generic;

namespace Lab_12_zadanie
{
    public class Program
    {
        public class UnionFindBySize
        {
            private int[] size;
            private int[] parent;
            private int compontentCount;
            public int NumCompotents { get { return compontentCount; } }
            public UnionFindBySize(int n)
            {
                compontentCount = n;
                parent = new int[n];
                size = new int[n];

                for (int i = 0; i < n; i++)
                {
                    parent[i] = i; // każdy element jest swoim własnym rodzicem
                    size[i] = 1; // każde własne odniesienie ma rozmiar 1
                }
            }
            public bool IsConnected(int a, int b)
            {
                if (Find(a) == Find(b))
                    return true;
                else
                    return false;
            }
            public int Find(int input)
            {
                var root = input;
                while (root != parent[root])
                {
                    root = parent[root];
                }
                return root;
            }
            public void Union(int a, int b)
            {
                var rootA = Find(a);
                var rootB = Find(b);

                if (rootA == rootB) // ten sam korzeń
                    return;
                if (size[rootA] < size[rootB]) // dołączamy mniejsze drzewo do większego
                {
                    size[rootB] += size[rootA];
                    parent[rootA] = rootB;
                }
                else
                {
                    size[rootA] += size[rootB]; // tak jak u góry
                    parent[rootB] = rootA;
                }
                compontentCount--;
            }
        }
        public class Graph
        {
            public Dictionary<Vertex, List<Edge>> Edges = new Dictionary<Vertex, List<Edge>>();
            public  List<Edge> Edges2 = new List<Edge>();
            private HashSet<Vertex> HashVertices;



            public void AddDirectedEdge(Vertex source, Vertex destination, double weight)
            {
                if (!Edges.ContainsKey(source))
                {
                    Edges.Add(source, new List<Edge>());
                }
                if (!Edges.ContainsKey(destination))
                {
                    Edges.Add(destination, new List<Edge>());
                }
                Edges[source].Add(new Edge() { Node = destination, Weight = weight });
            }

            public void AddUndirectedEdge(Vertex source, Vertex destination, double weight)
            {
                AddDirectedEdge(source, destination, weight);
                AddDirectedEdge(destination, source, weight);
            }

            //public void BFTraversal(int start, Action<int> action)
            //{
            //    Queue<int> queue = new Queue<int>();
            //    ISet<int> visited = new HashSet<int>();
            //    queue.Enqueue(start);
            //    while (queue.Count > 0)
            //    {
            //        int node = queue.Dequeue();
            //        if (visited.Contains(node))
            //        {
            //            continue;
            //        }
            //        action.Invoke(node);
            //        visited.Add(node);
            //        List<Edge> children = Edges[node];
            //        foreach (Edge child in children)
            //        {
            //            queue.Enqueue(child.Node);
            //        }
            //    }
            //}
        }

        public class Edge : IComparable<Edge>
        {
            public Vertex Node { get; set; }
            public double Weight { get; set; }

            public int CompareTo(Edge other)
            {
                return Weight.CompareTo(other.Weight);
            }
            public Vertex Source { get; set; }
            public Vertex Destination { get; set; }
        }
        public class Vertex
        {
            public Vertex(int key)
            {
                Key = key;
            }
            public int Key { get; set; }
        }
        public static List<Edge> GetMinimumSpanningTree(Graph graph)
        {
            var edges = graph.Edges2;
            edges.Sort((x, y) => { return x.Weight.CompareTo(y.Weight); });

            var vertices = graph.Edges.Keys; // klucz => wierzchołek
            var bijection = new Dictionary<Vertex, int>();

            var i = 0;
            foreach (var item in vertices)
            {
                bijection.Add(item, i);
                i++;
            }

            var unionFind = new UnionFindBySize(vertices.Count); // liczba wierzchołków
            var min = new List<Edge>();
            foreach (var edge in edges)
            {
                var rootA = unionFind.Find(bijection[edge.Source]);
                var rootB = unionFind.Find(bijection[edge.Destination]);

                if (rootA == rootB) continue;
                min.Add(edge);
                unionFind.Union(bijection[edge.Source], bijection[edge.Destination]);
            }
            return min;
        }



        static void Main(string[] args)
        {
            var unionFind = new UnionFindBySize(7); // (V-1)
            Graph graph = new Graph();

            var zero = new Vertex(0);
            var one = new Vertex(1);
            var two = new Vertex(2);
            var three = new Vertex(3);
            var four = new Vertex(4);
            var five = new Vertex(5);
            var six = new Vertex(6);

            graph.AddDirectedEdge(one, two, 3);
            graph.AddDirectedEdge(one, three, 2);
            graph.AddDirectedEdge(one, four, 6);
            graph.AddDirectedEdge(two, five, 3);
            graph.AddDirectedEdge(three, six, 7);
            graph.AddDirectedEdge(four, six, 5);
            graph.AddDirectedEdge(five, six, 8);
            //graph.BFTraversal(4, n => Console.Write(n + " "));

            var min = GetMinimumSpanningTree(graph);
        }
    }
}
