using NetShopApp.Models;
using NetShopApp.Service;
using NetShopApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace NetShopApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                bool check = false;
                int choice = 0;
                while (!check)
                {
                    System.Console.Clear();
                    System.Console.Write("1) Registration \n" +
                        "2) Authorization \n" +
                        "3) Exit \n" +
                        "Choice: ");
                    check = int.TryParse(System.Console.ReadLine(), out choice);
                    if (choice < 1 || choice > 3)
                        check = false;
                }

                if (choice == 1)
                {
                    User user = Registration.SignUp();
                    AccountsTableDataService.AddUser(user);
                }
                else if (choice == 2)
                {
                    User user = Authorization.SignIn();
                    
                    check = false;
                    if (user == null)
                    {
                        check = true;
                        choice = 3;
                    }
                    while (!check)
                    {
                        System.Console.Clear();
                        System.Console.Write("1) Show basket\n" +
                                             "2) Choose a product\n" +
                                             "Choice: ");
                        check = int.TryParse(System.Console.ReadLine(), out choice);
                        if (choice < 1 || choice > 2)
                            check = false;
                    }

                    if(choice == 1)
                    {
                        int userId = AccountsTableDataService.GetUserId(user.Login);
                        List<Basket> products = BasketsTableDataService.GetProductsInBasket(userId);

                        System.Console.Clear();
                        if(products.Count != 0)
                            for (int i = 0; i < products.Count; i++)
                            {
                                products[i].ShowData(ProductsTableDataService.GetProductName(products[i].ProductId));
                            }
                        else
                        {
                            System.Console.Write("Ваша корзина пуста. ");
                        }
                        System.Console.Write("Нажмите Enter чтобы продолжить...");
                        System.Console.ReadLine();
                    }
                    else if(choice == 2)
                    {
                        List<string> categories = ProductsTableDataService.GetShopCategories();

                        check = false;
                        while (!check)
                        {
                            System.Console.Clear();
                            System.Console.WriteLine("\tCategory of products");
                            for (int i = 0; i < categories.Count; i++)
                            {
                                System.Console.WriteLine($"{i + 1}) {categories[i]}");
                            }
                            System.Console.Write("Choice: ");
                            check = int.TryParse(System.Console.ReadLine(), out choice);
                            if (choice < 1 || choice > categories.Count)
                                check = false;
                        }

                        List<Product> products = ProductsTableDataService.GetProductsList(categories[choice - 1]);

                        check = false;
                        int quantity = 0;
                        while (!check)
                        {
                            System.Console.Clear();
                            System.Console.WriteLine("\tList of products");
                            for (int i = 0; i < products.Count; i++)
                            {
                                System.Console.Write($"{i + 1}) ");
                                products[i].ShowData();
                            }
                            System.Console.Write("Choice: ");
                            check = int.TryParse(System.Console.ReadLine(), out choice);
                            if (choice < 1 || choice > products.Count)
                                check = false;

                            if (check)
                            {
                                System.Console.Write("Quantity: ");
                                check = int.TryParse(System.Console.ReadLine(), out quantity);
                                if (quantity < 1 || 
                                    quantity > ProductsTableDataService.GetProductCountInStorage(products[choice - 1].Id))
                                {
                                    check = false;
                                    System.Console.Write("Выбранное количество товара превышает наличие в складе.\n" +
                                        "Нажмите Enter чтобы продолжить...");
                                    System.Console.ReadLine(); 
                                }
                            }
                        }
                        double payment = quantity * ProductsTableDataService.GetProductPrice(products[choice - 1].Id);
                        int userId = AccountsTableDataService.GetUserId(user.Login);

                        try
                        {
                            using (var context = new ShopContext())
                            {
                                context.Baskets.Add(new Basket
                                {
                                    ProductId = products[choice - 1].Id,
                                    Quantity = quantity,
                                    Payment = payment,
                                    UserId = userId
                                });
                                context.SaveChanges();
                            }
                            System.Console.WriteLine("Запись добавлена");
                        }
                        catch (Exception exception)
                        {
                            System.Console.WriteLine(exception.Message);
                        }
                        finally
                        {
                            System.Console.Write("Нажмите Enter чтобы продолжить...");
                            System.Console.ReadLine();
                        }
                    }
                }
                else
                    Environment.Exit(0);
            }
        }
    }
}
