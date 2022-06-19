using DeliveryApp.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DeliveryApp.Services
{
    public class CartItemService
    {
        public int  GetUserCartCount()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            List<CartItem> count = cn.Table<CartItem>().ToList();
            cn.Close();
            return count.Count();
        }

        public void RemoveItemsFromCart()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            cn.DeleteAll<CartItem>();
            cn.Commit();
            cn.Close();
        }
    }
}
