using NetShopApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetShopApp.DataAccess
{
    public static class AccountsTableDataService
    {
        public static string CheckForAvailabilityLogin(string data)
        {
            string login = "";
            try
            {
                using (var context = new ShopContext())
                {
                    login = context.Users
                            .Where(u => u.Login == data)
                            .Select(u => u.Login).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return login;
        }
        public static string CheckForAvailabilityPassword(string data)
        {
            string password = "";
            try
            {
                using (var context = new ShopContext())
                {
                    password = context.Users
                            .Where(u => u.Login == data)
                            .Select(u => u.Password).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return password;
        }
        public static string CheckForAvailabilityEmail(string data)
        {
            string email = "";
            try
            {
                using (var context = new ShopContext())
                {
                    email = context.Users
                            .Where(u => u.Email == data)
                            .Select(u => u.Email).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return email;
        }
        public static string CheckForAvailabilityPhoneNumber(string data)
        {
            string number = "";
            try
            {
                using (var context = new ShopContext())
                {
                    number = context.Users
                            .Where(u => u.PhoneNumber == data)
                            .Select(u => u.PhoneNumber).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return number;
        }
        public static void AddUser(User user)
        {
            try
            {
                using (var context = new ShopContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                Console.WriteLine("Регистрация прошла успешно!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadLine();
            }
            finally
            {
                Console.Write("Нажмите Enter чтобы продолжить...");
                Console.ReadLine();
            }
        }

        public static int GetUserId(string login)
        {
            int id;
            using(var context = new ShopContext())
            {
                id = context.Users
                    .Where(u => u.Login == login)
                    .Select(u => u.Id).FirstOrDefault();
            }
            return id;
        }
    }
}
