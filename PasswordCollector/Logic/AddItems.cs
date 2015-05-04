using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAL;
using DAL.Repository;

namespace PasswordCollector.Logic
{
    public static class AddItems
    {

        public static string TryToAddNewItem(string website, string username, string password)
        {
            var item = new Item { Adress = website, BelongsToUser = HandleRequests.GetCurrentUserId(), Username = username, Password = password };
            if (ItemsRepository.Add(item))
            {
                return "Your item has been added!";
            }
            return "The item was already in the list!";
        }


    }
}
