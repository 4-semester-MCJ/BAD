using System;
using System.Linq; 

class Program
{
    static void Main(string[] args)
    {
        Seed();
    }

    private static void Seed()
    {
        Product ThinkPad69 = new Product()
        {
            Maker = "ThinkPad",
            Model = "69",
            Type = "Laptop"
        };

        using (var context = new DBSet())
        {
            var product1 = new Product { maker = "Maker1", model = "Model1", type = "Type1" };
            var product2 = new Product { maker = "Maker2", model = "Model2", type = "Type2" };
            var product3 = new Product { maker = "Maker3", model = "Model3", type = "Type3" };

            context.Products.AddRange(product1, product2, product3);
            context.SaveChanges();

            // Create some PCs
            var pc1 = new PC { speed = 3000, ram = 16, hd = 500, price = 1000, Product = product1 };
            var pc2 = new PC { speed = 3200, ram = 32, hd = 1000, price = 1500, Product = product2 };

            context.PCs.AddRange(pc1, pc2);
            context.SaveChanges();

            // Create some Laptops
            var laptop1 = new Laptop { speed = 2500, ram = 8, hd = 256, screen = 15.6f, price = 800, Product = product1 };
            var laptop2 = new Laptop { speed = 2700, ram = 16, hd = 512, screen = 17.3f, price = 1200, Product = product2 };

            context.Laptops.AddRange(laptop1, laptop2);
            context.SaveChanges();

            // Create some Printers
            var printer1 = new Printer { color = "Color", type = "Laser", price = 200, Product = product1 };
            var printer2 = new Printer { color = "Black and White", type = "Inkjet", price = 150, Product = product2 };

            context.Printers.AddRange(printer1, printer2);
            context.SaveChanges();
        }
    }
}
