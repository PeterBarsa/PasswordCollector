using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.Repository
{
    public class ItemsRepository
    {


        public static List<Item> Search(string search, int id)
        {

            using (var context = new MainDBContext())
            {
                return context.Items.Select(x => x).Where(x => x.BelongsToUser.Equals(id) & x.Adress.Contains(search)).ToList();
            }
            
        }

        public static bool Add(Item item)
        {

            using (var context = new MainDBContext())
            {

                var checklist = context.Items.Select(x => x).Where(x => x.Adress.Equals(item.Adress) &&
                    x.BelongsToUser.Equals(1) && x.Password.Equals(item.Password) && x.Username.Equals(item.Username))
                    .ToList();

                if (checklist.Any())
                {
                    return false;
                }

                context.Items.Add(item);
                context.SaveChanges();
                return true;
            }

        }

        public static List<Item> AutoSearch(string search, int id)
        {


            using (var context = new MainDBContext())
            {

                return
                    context.Items.Select(x => x)
                        .Where(x => x.Adress.StartsWith(search) && x.BelongsToUser.Equals(id))
                        .ToList();

            }


        }

    }
}
