using NetShopApp.DataAccess;
using NetShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetShopApp.Service
{
    public class Authorization
    {
        #region Войти
        public static User SignIn()
        {
            User user = new User();
            
            bool check = false;
            while (true)
            {
                Console.Clear();
                if (!check && !EnterLogin(user))
                {
                    Console.Write("Пользователя с таким логином не существует\n" +
                        "Нажмите Enter чтобы ввести заново, Escape чтобы выйти....");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                        continue;
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        user = null;
                        break;
                    }
                }
                if (check)
                {
                    Console.WriteLine($"Login: {user.Login}");
                }
                if (!EnterPassword(user))
                {
                    Console.Write("\nВведенный пароль не корректный\n" +
                        "Нажмите Enter чтобы ввести заново, Escape чтобы выйти....");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        user = null;
                        break;
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                        check = true;
                }
                else
                {
                    Console.Write("\nВход выполнен! Нажмите Enter чтобы продолжить...");
                    Console.ReadLine();
                    break;
                }
            }
            return user;
        }
        #endregion

        #region Ввод пароля
        private static bool EnterPassword(User user)
        {
            Console.Write("Password: ");
            user.Password = HideCharacter();
            string password = AccountsTableDataService.CheckForAvailabilityPassword(user.Login);
            if (password == null || password != user.Password)
                return false;
            return true;
        }
        #endregion

        #region Ввод логина
        private static bool EnterLogin(User user)
        {
            Console.Write("Login: ");
            user.Login = Console.ReadLine();
            string login = AccountsTableDataService.CheckForAvailabilityLogin(user.Login);
            if (login == null || login.ToLower() != user.Login.ToLower())
                return false;
            return true;
        }
        #endregion

        #region Скрытие пароля
        public static string HideCharacter()
        {
            string text = "";
            ConsoleKeyInfo keyInfo;

            while (true)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (text.Length == 0)
                        continue;
                    text = text.Remove(text.Length - 1);
                    Console.Write("\b \b");
                }
                else
                {
                    text += keyInfo.KeyChar;
                    Console.Write("*");
                }
            }

            return text;
        }
        #endregion
    }
}
