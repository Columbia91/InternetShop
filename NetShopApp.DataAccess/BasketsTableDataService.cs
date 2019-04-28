using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetShopApp.Models;

namespace NetShopApp.DataAccess
{
    public static class BasketsTableDataService
    {
        public static List<Basket> GetProductsInBasket(int id)
        {
            List<Basket> data;
            using(var context = new ShopContext())
            {
                data = context.Baskets
                    .Where(b => b.UserId == id)
                    .ToList();
                    
            }
            return data;
        }
    }
}
