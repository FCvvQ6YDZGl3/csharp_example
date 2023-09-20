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
        public double price;

        public Product(ushort id,string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }
    class CompositeProduct : Product
    {
        public List<Product> products;
        public CompositeProduct(ushort id, string name, double price, List<Product> products) : base(id, name, price)
        {
            
        }
    }

    class ProductDemo
    {
        private uint level;

        List<Product> products;

        Product bycycle;
        Product wheel;
        Product screw;
        Product trunk;
        Product scooter;

        IEnumerable<Product> superProducts;
        Dictionary<Product, List<Product>> tree;

        public void run()
        {
            createTree();
            //directTreeTraversal(bycycle);
            //directTreeTraversal(scooter);
            directTreeTraversal(superProducts.First());
        }

        private void createTree()
        {
            ProductStorage productStorage = new ProductStorage();
            productStorage.init();

            products = (from i in productStorage.Izdels
                        select new Product((ushort)i.Id, i.Name, i.Price)).ToList();

            var links = productStorage.Links;

            var productIds = from p in products select p.id;
            var linkIds = from l in links select (ushort)l.izdel;
            var productSuperIds = productIds.Except(linkIds);
            superProducts =
                from p in products
                join sp in productSuperIds on p.id equals sp
                select p;





            bycycle = new Product(0, "Велосипед", 29900);
            wheel = new Product(5, "Колесо", 1000);
            screw = new Product(10, "Гайка", 8);
            trunk = new Product(4, "Багажник", 1500);

            scooter = new Product(0, "Самокат", 16000);

            tree = new Dictionary<Product, List<Product>>();



            foreach (var curp in products)
            {
                if (links.Where(l => l.izdelUp == curp.id).Count() == 0)
                {
                    Console.WriteLine("Для {0} дерево не строим, т.к. это терминальный продукт.", curp.name);
                    continue;
                }
                
                var compositePart = from p in products
                join l in links on p.id equals l.izdel
                where l.izdelUp == curp.id
                select p;

                Console.WriteLine("Для {0} строим дерево, в него войдут {1} деталей", curp.name, compositePart.Count());
                tree.Add(curp, compositePart.ToList());
            }

            /*tree.Add(bycycle, new List<Product> {
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
            tree.Add(scooter, new List<Product> {
                new Product(1, "Руль", 3000),
                trunk,
                new Product(3, "Крыло", 500),
                new Product(4, "Рама", 8000),
                wheel,
                screw
            });*/
        }

        private void printProduct(Product product)
        {
            Console.WriteLine(new String(' ', (int)level * 2) + "<{0}>", product.name);
        }
        private void directTreeTraversal(Product product)
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
                            directTreeTraversal(item);
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
