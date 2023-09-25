using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ft_consult
{
    class Product
    {
        public ushort idField;
        public string nameField;
        public double priceField;

        public Product(ushort id, string name, double price)
        {
            this.idField = id;
            this.nameField = name;
            this.priceField = price;
        }

        public ushort Id
        {
            get
            {
                return idField;
            }
        }
        public string Name
        {
            get
            {
                return nameField;
            }
        }
        public virtual double Price
        {
            get
            {
                return 1;
            }
        }
    }

    class CompositeProduct : Product
    {
        private List<IncludedProduct> products;
        public CompositeProduct(ushort id, string name, double price, List<IncludedProduct> products) : base(id, name, price)
        {
            this.products = products;
        }
        public override double Price
        {
            get
            {
                double price = priceField;
                foreach (var ip in products)
                {
                    price += ip.Count * ip.Product.Price;
                }
                return price;
            }
        }
        public void AddProduct(IncludedProduct includedProduct)
        {
            products.Add(includedProduct);
        }

        public void AddProduct(List<IncludedProduct> includedProducts)
        {
            products.AddRange(includedProducts);
        }
        public List<IncludedProduct> Products
        {
            get
            {
                return products;
            }
        }
    }
    class IncludedProduct
    {
        private Product productField;
        private sbyte countField;

        public IncludedProduct(Product product, sbyte count)
        {
            productField = product;
            countField = count;
        }
        public Product Product
        {
            get
            {
                return productField;
            }
        }

        public sbyte Count
        {
            get
            {
                return countField;
            }
        }

    }

    class ProductDemo
    {
        ProductStorage productStorage;

        List<Product> newProducts;

        private byte level;

        List<Product> products;

        IEnumerable<Product> superProducts;
        Dictionary<Product, List<IncludedProduct>> trees;

        List<CompositeProduct> compositeProducts;


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
                        createTrees();
                        superProducts = selectSuperProduct().ToList();
                        foreach (var sp in superProducts)
                        {
                            directTreeTraversal(sp, 1);
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
                    case "view final product":
                        foreach (var fp in this.selectFinalProduct())
                        {
                            Console.WriteLine(fp.Name);
                        }
                        break;
                    case "create trees":
                        createTrees();
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

        private IEnumerable<Product> selectFinalProduct()
        {
            var links = productStorage.Links;

            var productIds = from p in products select p.Id;
            var linkIzdelUpIds = from l in links select (ushort)l.izdelUp;
            var productFinalIds = productIds.Except(linkIzdelUpIds);

            var finalProduct =
                from p in products
                join fp in productFinalIds on p.Id equals fp
                select p;

            return finalProduct;
        }

        private IEnumerable<Product> selectSuperProduct()
        {
            var links = productStorage.Links;

            var productIds = from p in products select p.Id;
            var linkIds = from l in links select (ushort)l.izdel;
            var productSuperIds = productIds.Except(linkIds);

            superProducts =
                from p in products
                join sp in productSuperIds on p.Id equals sp
                select p;
            return superProducts;
        }

        private void createTrees()
        {
            var links = productStorage.Links;

            //здесь инициализируем объекты состоящие из других.
            var cp = from p in products.Except(this.selectFinalProduct())
                     select new CompositeProduct(p.Id, p.Name, p.Price, new List<IncludedProduct>());

            compositeProducts = cp.ToList();
            var finalProducts = selectFinalProduct().ToList();
            //создаем список продуктов состоящий из двух списков - композитные продукты и финальные.
            products = finalProducts;
            products.AddRange(compositeProducts);

            trees = new Dictionary<Product, List<IncludedProduct>>();
            //Устанавливаем связи между ними, перебирая каждый композитный продукт
            foreach (var curp in compositeProducts)
            {
                var compositePart = from p in products
                                    join l in links on p.Id equals l.izdel
                                    where l.izdelUp == curp.Id
                                    select new IncludedProduct(p, (sbyte) l.kol);
                var compositePartList = compositePart.ToList();

                curp.AddProduct(compositePartList);
                trees.Add(curp, compositePartList);
            }
        }

        private void printProduct(Product included, sbyte count)
        {
            Console.WriteLine(new String(' ', level * 2) + "<{0}>" + " {1} ({2})", included.Name, included.Price, count);
        }
        private void directTreeTraversal(Product included, sbyte count)
        {
            printProduct(included, count);
            if (trees.ContainsKey(included))
            {
                level++;
                List<IncludedProduct> listNode;
                listNode = trees[included];
                foreach (IncludedProduct item in listNode)
                {
                    directTreeTraversal(item.Product, item.Count);
                }
                level--;
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
