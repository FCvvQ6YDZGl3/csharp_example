using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project1.base_algoritm
{
    static class VertexState
    {
        public const int undetected = 0;
        public const int detected = 1;
        public const int passsed = 2;
    }
    class Edge
    {
        public int begin;
        public int end;
    }
    class Graph_classic
    {
        private static Regex regex = new Regex("^[0-9]+$", RegexOptions.Compiled);
        public void run()
        {
            bypassInBreadthList();
        }
        private void shortestWay()
        {
            Queue<int> Queue = new Queue<int>();
            Stack<Edge> Edges = new Stack<Edge>();
            int req = 0;
            Edge e;
            int[,] mas = new int[7, 7]
                {
                    {0,1,1,0,0,0,1},
                    {1,0,1,1,0,0,0},
                    {1,1,0,0,0,0,0},
                    {0,1,0,0,1,0,0},
                    {0,0,0,1,0,1,0},
                    {0,0,0,0,1,0,1},
                    {1,0,0,0,0,1,0}
                };
            int[] nodes = new int[7];
            for (int i = 0; i < 7; i++)
                nodes[i] = 0;

            string response = Console.ReadLine();
            if (regex.IsMatch(response))
                req = Convert.ToInt32(response);
            else
            {
                Console.WriteLine("Введите число!");
            }

            req--;
            Queue.Enqueue(0);

            while (Queue.Count != 0)
            {
                int node = Queue.Dequeue();
                nodes[node] = 2;
                for (int j = 0; j < 7; j++)
                {
                    if (mas[node, j] == 1 && nodes[j] == 0)
                    {
                        Queue.Enqueue(j);
                        nodes[j] = 1;

                        e = new Edge();
                        e.begin = node;
                        e.end = j;

                        Edges.Push(e);
                        if (node == req) break;
                    }
                }
                Console.WriteLine(node + 1);
            }

            Console.WriteLine("Путь до вершины {0}", req + 1);
            Console.Write(req + 1);
            while (Edges.Count != 0)
            {
                e = Edges.Pop();
                if (e.end == req)
                {
                    req = e.begin;
                    Console.Write(" <- {0}", req + 1);
                }
            }
        }
        private void bypassInBreadth()
        {
            const ushort nodeCount = 7;
            Queue<int> Queue = new Queue<int>();
            int[,] mas = new int[nodeCount, nodeCount]
                {
                    {0, 1, 1, 0, 0, 0, 1},
                    {1, 0, 1, 1, 0, 0, 0},
                    {1, 1, 0, 0, 0, 0, 0},
                    {0, 1, 0, 0, 1, 0, 0},
                    {0, 0, 0, 1, 0, 1, 0},
                    {0, 0, 0, 0, 1, 0, 1},
                    {1, 0, 0, 0, 0, 1, 0},
                };
            int[] nodes = new int[nodeCount];

            for (int i = 0; i < nodeCount; i++)
                nodes[i] = 0;

            Queue.Enqueue(0);

            while (Queue.Count != 0)
            {
                int node = Queue.Dequeue();
                nodes[node] = VertexState.passsed;
                for (int j = 0; j < nodeCount; j++)
                {
                    if (mas[node, j] == 1 && nodes[j] == 0)
                    {
                        Queue.Enqueue(j);
                        nodes[j] = VertexState.detected;
                    }
                }
                Console.WriteLine(node + 1);
            }
        }
        
        private void bypassInBreadthList()
        {
            Queue<int> Queue = new Queue<int>();
            List<int>[] mas = new List<int>[]
                {
                    new List<int> {2, 3, 7},
                    new List<int> {1, 3, 4},
                    new List<int> {1, 2},
                    new List<int> {2, 5},
                    new List<int> {4, 6},
                    new List<int> {5, 7},
                    new List<int> {1, 6}
                };
            int nodeCount = mas.Count();
            int[] nodes = new int[nodeCount];
            for (int i = 0; i < nodeCount; i++)
                nodes[i] = 0;

            Queue.Enqueue(0);
            List<int> listNode;
            while (Queue.Count != 0)
            {
                int node = Queue.Dequeue();
                nodes[node] = VertexState.passsed;
                listNode = mas[node];
                foreach (int item in listNode)
                {
                    Console.Write("<{0}>", item);
                    if (nodes[item-1] == 0)
                    {
                        Queue.Enqueue(item-1);
                        nodes[item-1] = VertexState.detected;
                    }
                }
                Console.WriteLine(node + 1);
            }
        }
    }
}