using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetShopApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Мин. длина логина должна быть 3, макс. 20, нажимте Enter чтобы ввести заново...")]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }                     
}
/*Создать консольное приложение магазин с возможностью хранения корзины товаров, привязанной к логину пользователя*/
