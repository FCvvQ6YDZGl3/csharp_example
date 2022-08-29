using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project1.base_algoritm
{
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
            shortestWay();
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
            Queue<int> Queue = new Queue<int>();
            int[,] mas = new int[7, 7]
                {
                    {0, 1, 1, 0, 0, 0, 1},
                    {1, 0, 1, 1, 0, 0, 0},
                    {1, 1, 0, 0, 0, 0, 0},
                    {0, 1, 0, 0, 1, 0, 0},
                    {0, 0, 0, 1, 0, 1, 0},
                    {0, 0, 0, 0, 1, 0, 1},
                    {1, 0, 0, 0, 0, 1, 0},
                };
            int[] nodes = new int[7];
            for (int i = 0; i < 7; i++)
                nodes[i] = 0;
            Queue.Enqueue(3);
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
                    }
                }
                Console.WriteLine(node + 1);
            }
        }
    }
}
