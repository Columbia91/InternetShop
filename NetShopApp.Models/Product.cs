using System;

namespace NetShopApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int QuantityInStorage { get; set; }

        public void ShowData()
        {
            Console.WriteLine("Name: {0}\n" +
                               "Manufacturer: {1}\n" +
                               "Price: {2}\n" +
                               "Remain: {3}\n",
                               Name, Manufacturer, Price, QuantityInStorage);
        }
    }
}