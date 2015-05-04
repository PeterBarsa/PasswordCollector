using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository
    {


        public static bool Login(string username, string password)
        {

            using (var context = new MainDBContext())
            {

                var user = context.Users.FirstOrDefault(x => x.Username.Equals(username) & x.Password.Equals(password));

                if (user != null)
                {
                    return true;
                }
                

            }
            return false;
        }

        public static int GetUserId(string username, string password)
        {

            using (var context = new MainDBContext())
            {

                return context.Users.Where(x => x.Username.Equals(username) && x.Password.Equals(password))
                      .Select(x => x.UserID).First();

            }

        }

    }
}
