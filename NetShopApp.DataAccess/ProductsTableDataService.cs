using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetShopApp.Models;

namespace NetShopApp.DataAccess
{
    public static class ProductsTableDataService
    {
        public static List<string> GetShopCategories()
        {
            List<string> data;
            using (var context = new ShopContext())
            {
                data = context.Products
                    .Distinct()
                    .Select(p => p.Category).ToList();
            }
            return data;
        }

        public static List<Product> GetProductsList(string category)
        {
            List<Product> data;
            using(var context = new ShopContext())
            {
                data = context.Products
                    .Where(p => p.Category == category)
                    .OrderBy(p => p.Name).ToList();
            }
            return data;
        }

        public static int GetProductCountInStorage(int id)
        {
            int data;
            using(var context = new ShopContext())
            {
                data = context.Products
                    .Where(p => p.Id == id)
                    .Select(p => p.QuantityInStorage).FirstOrDefault();
            }
            return data;
        }

        public static double GetProductPrice(int id)
        {
            double data;
            using (var context = new ShopContext())
            {
                data = context.Products
                    .Where(p => p.Id == id)
                    .Select(p => p.Price).FirstOrDefault();
            }
            return data;
        }

        public static Product GetProductName(int id)
        {
            Product data;
            using(var context = new ShopContext())
            {
                data = context.Products
                    .Where(p => p.Id == id)
                    .Select(p => new
                    {
                        name = p.Name,
                        manufacturer = p.Manufacturer,
                        category = p.Category
                    }).AsEnumerable()
                    .Select(an => new Product
                    {
                        Name = an.name,
                        Manufacturer = an.manufacturer,
                        Category = an.category
                    }).SingleOrDefault();
            }
            return data;
        }
    }
}
