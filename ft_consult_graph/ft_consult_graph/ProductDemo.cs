using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ft_consult
{
    class Product
    {
        public ushort id;
        public string name;
        public float price;

        public Product(ushort id,string name,float price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }
    class CompositeProduct : Product
    {
        public List<Product> products;
        public CompositeProduct(ushort id, string name, float price, List<Product> products) : base(id, name, price)
        {
            
        }
    }

    class ProductDemo
    {
        private uint level;

        Product bycycle;
        Product wheel;
        Product screw;
        Product trunk;

        Dictionary<Product, List<Product>> tree;
        public void run()
        {
            createTree();
            //bypassInBreadthListProduct(bycycle);
        }

        private void createTree()
        {
            ProductStorage productStorage = new ProductStorage();
            productStorage.init();

            var products = productStorage.Izdels;
            var links = productStorage.Links;

            var superProducts =
                from product in products
                join link in links on product.Id equals link.izdelUp 
                into sps
                from sub in sps.DefaultIfEmpty()
                select new
                {
                    product.Name,
                    
                };

            foreach(var sp in superProducts)
            {
                Console.WriteLine(sp.izdelUp);
            }

            bycycle = new Product(0, "Велосипед", 29900);
            wheel = new Product(5, "Колесо", 1000);
            screw = new Product(10, "Гайка", 8);
            trunk = new Product(4, "Багажник", 1500);


            tree = new Dictionary<Product, List<Product>>();
            tree.Add(bycycle, new List<Product> {
                new Product(1, "Руль", 3000),
                trunk,
                new Product(2, "Сиденье", 1200),
                new Product(3, "Крыло", 500),
                new Product(4, "Рама", 8000), 
                wheel,
                screw
            });
            tree.Add(wheel, new List<Product> {
                new Product(6, "Спицы", 50),
                new Product(7, "Шина", 300),
                new Product(8, "Резиновая камера", 200),
                new Product(9, "Болт", 12),
                screw
            });
            tree.Add(trunk, new List<Product> {
                new Product(6, "Проволока", 50),
                new Product(7, "Пружина", 300),
                new Product(9, "Болт", 12),
                screw
            });
        }

        private void printProduct(Product product)
        {
            Console.WriteLine(new String(' ', (int)level * 2) + "<{0}>", product.name);
        }
        private void bypassInBreadthListProduct(Product product)
        {

            Queue<Product> Queue = new Queue<Product>();
            Queue.Enqueue(product);
            List<Product> listNode;
            while (Queue.Count != 0)
            {
                Product node = Queue.Dequeue();

                if(tree.ContainsKey(node))
                {
                    printProduct(node);
                    level++;
                    listNode = tree[node];

                    foreach (Product item in listNode)
                    {
                        if (tree.ContainsKey(item))
                            bypassInBreadthListProduct(item);
                        else
                        {
                            Queue.Enqueue(item);
                            printProduct(item);
                        }
                    }
                    level--;
                }
            }
        }
        public ProductDemo()
        {
            level = 0;
        }
    }
}
