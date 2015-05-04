using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAL;
using DAL.Repository;

namespace PasswordCollector.Logic
{
    public static class HandleRequests
    {
        private static string HashPassword(string password)
        {

            var hash = SHA1.Create();

            //Converts the password to bytes and add them into an array
            var passwordData = hash.ComputeHash(Encoding.Default.GetBytes(password));

            //creates a stringbuilder to build a string of bytes
            var hashedPassword = new StringBuilder();

            foreach (var b in passwordData)
            {
                hashedPassword.Append(b.ToString());
            }

            return hashedPassword.ToString();
        }


        public static bool Login(string username, string password)
        {


            if (UserRepository.Login(username, HashPassword(password)))
            {
                return true;
            }
            return false;
        }

        public static List<Item> Search(string search)
        {

            return ItemsRepository.Search(search, GetCurrentUserId());

        }

        public static int SetCurrentUserId(string username, string password)
        {

            return UserRepository.GetUserId(username, HashPassword(password));

        }

        public static int GetCurrentUserId()
        {

            return (int) Application.Current.Resources["currentUser"];

        }

    }
}
