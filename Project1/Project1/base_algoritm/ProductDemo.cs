using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Project1.base_algoritm;

namespace Project1.graph_extension
{
    class Product
    {
        public ushort id;
        public string name;
        public float price;
        public sbyte VertexState;

        public Product(ushort id,string name,float price)
        {
            this.id = id;
            this.name = name;
            this.price = price;

            this.VertexState = 0;
        }
    }
    class CompositeProduct
    {
        public ushort id;
        public string name;
        public List<Product> products;
    }

    class ProductLinks
    {
        public Product product;
        public Product productUp;
        public sbyte count;
    }

    internal class ProductDemo
    {
        public uint level;

        Product bycycle;
        Product wheel;
        Product screw;
        Product trunk;

        Dictionary<Product, List<Product>> masP;

        public void run()
        {
            createGraph();
            bypassInBreadthListProduct(bycycle);
        }

        private void createGraph()
        {
            bycycle = new Product(0, "Велосипед", 29900);
            wheel = new Product(5, "Колесо", 1000);
            screw = new Product(10, "Гайка", 8);
            trunk = new Product(4, "Багажник", 1500);


            masP = new Dictionary<Product, List<Product>>();
            masP.Add(bycycle, new List<Product> {
                new Product(1, "Руль", 3000),
                trunk,
                new Product(2, "Сиденье", 1200),
                new Product(3, "Крыло", 500),
                new Product(4, "Рама", 8000),
                wheel,
                screw
            });
            masP.Add(wheel, new List<Product> {
                new Product(6, "Спицы", 50),
                new Product(7, "Шина", 300),
                new Product(8, "Резиновая камера", 200),
                new Product(9, "Болт", 12),
                screw
            });
            masP.Add(trunk, new List<Product> {
                new Product(6, "Проволока", 50),
                new Product(7, "Пружина", 300),
                new Product(9, "Болт", 12),
                screw
            });
        }

        private void bypassInBreadthListProduct(Product product)
        {

            int nodeCount = masP.Count;

            Queue<Product> Queue = new Queue<Product>();
            Queue.Enqueue(product);
            List<Product> listNode;
            while (Queue.Count != 0)
            {
                Product node = Queue.Dequeue();

                if(masP.ContainsKey(node))
                {
                    Console.WriteLine(new String(' ', (int)level * 2) + "<{0}>", node.name);
                    level++;
                    listNode = masP[node];

                    foreach (Product item in listNode)
                    {
                        if (masP.ContainsKey(item))
                            bypassInBreadthListProduct(item);
                        else
                        {
                            Queue.Enqueue(item);
                            Console.WriteLine(new String(' ', (int) level * 2) + "<{0}>", item.name);
                        }
                    }
                    level--;
                }
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
            int nodeCount = mas.Length;
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
                    if (nodes[item - 1] == 0)
                    {
                        Queue.Enqueue(item - 1);
                        nodes[item - 1] = VertexState.detected;
                    }
                }
                Console.WriteLine(node + 1);
            }
        }
        public ProductDemo()
        {
            level = 0;
        }
    }
}
