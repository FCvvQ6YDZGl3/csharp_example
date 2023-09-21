using System;
using System.Collections.Generic;
using System.IO;
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
        ProductStorage productStorage;

        List<Product> newProducts;

        private byte level;

        List<Product> products;

        IEnumerable<Product> superProducts;
        Dictionary<Product, List<Product>> tree;

        public void run()
        {
            string userResponse;
            bool close = false;
            do
            {
                userResponse = Console.ReadLine();

                switch (userResponse)
                {
                    case "view product tree":
                        createTree();
                        foreach (var sp in superProducts)
                        {
                            directTreeTraversal(sp);
                        }
                        break;
                    case "add product":
                        Console.WriteLine("Введите значения для продукта в формате <название>");
                        userResponse = Console.ReadLine();
                        addNewProducts(userResponse);
                        Console.WriteLine("Продукт добавлен успешно!");
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "q":
                    case "quit":
                    case "exit":
                        close = true;
                        break;
                    case "":
                        break;
                    default:
                        Console.WriteLine("Пока думаем над разработкой этого функционала, но его ещё нет.");
                        break;
                }
            } while (!close);
        }

        public void addNewProducts(string name)
        {
            Izdel izdel = new Izdel
            {
                Name = name,
                Price = 100.00
            };
            productStorage.addInIzdel(izdel);

            Product newPrd = new Product((ushort)izdel.Id, izdel.Name, 0.00);
            newProducts.Add(newPrd);
            products.Add(newPrd);
        }

        private void createTree()
        {
            var links = productStorage.Links;

            var productIds = from p in products select p.id;
            var linkIds = from l in links select (ushort)l.izdel;
            var productSuperIds = productIds.Except(linkIds);
            superProducts =
                from p in products
                join sp in productSuperIds on p.id equals sp
                select p;

            tree = new Dictionary<Product, List<Product>>();

            foreach (var curp in products)
            {
                if (links.Where(l => l.izdelUp == curp.id).Count() == 0)
                {
                    continue;
                }
                
                var compositePart = from p in products
                join l in links on p.id equals l.izdel
                where l.izdelUp == curp.id
                select p;

                tree.Add(curp, compositePart.ToList());
            }
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

                printProduct(node);
                if (tree.ContainsKey(node))
                {
                    level++;
                    listNode = tree[node];

                    foreach (Product item in listNode)
                    {
                            directTreeTraversal(item);
                    }
                    level--;
                }
            }
        }
        public ProductDemo()
        {
            level = 0;
            productStorage = new ProductStorage();
            productStorage.init();

            products = (from i in productStorage.Izdels
                        select new Product((ushort)i.Id, i.Name, i.Price)).ToList();

            newProducts = new List<Product>();
        }
    }
}
