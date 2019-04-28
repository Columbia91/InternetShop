using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetShopApp.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Payment { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public void ShowData(Product product)
        {
            Console.WriteLine("Name: {0}\n" +
                              "Manufacturer: {1}\n" +
                              "Category: {2}\n" +
                              "Quantity: {3}\n" +
                              "Payment: {4}\n",
                              product.Name, product.Manufacturer, product.Category, Quantity, Payment);
        }
    }
}
/*Создать консольное приложение магазин с возможностью хранения корзины товаров, привязанной к логину пользователя*/
