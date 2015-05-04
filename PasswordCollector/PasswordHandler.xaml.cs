using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PasswordCollector.Logic;

namespace PasswordCollector
{
    /// <summary>
    /// Interaction logic for PasswordHandler.xaml
    /// </summary>
    public partial class PasswordHandler : Window
    {
        public PasswordHandler()
        {
            InitializeComponent();
        }

        private void TbSearchAdress_GotFocus(object sender, RoutedEventArgs e)
        {
            TbSearchAdress.Clear();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var search = TbSearchAdress.Text;
            var results = HandleRequests.Search(search);

            if (results.Any())
            {

                LwPasswords.Items.Clear();

                foreach (var item in results)
                {
                    LwPasswords.Items.Add(item);
                }
            

            }


        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var website = TbWebsite.Text;
            var username = TbUsername.Text;
            var password = PbPassword.Password;
            var returnMessage = AddItems.TryToAddNewItem(website, username, password);
            TbWebsite.Clear();
            TbUsername.Clear();
            PbPassword.Clear();
            MessageBox.Show(returnMessage);
        }

        private void TbSearchAdress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbSearchAdress.Text.Equals("Enter Adress:"))
            {
                
            }
            else
            {

                LwPasswords.Items.Clear();
                var search = TbSearchAdress.Text;
                var result = HandleRequests.AutoSearch(search);
                if (result.Any())
                {



                    foreach (var item in result)
                    {
                        LwPasswords.Items.Add(item);
                    }

                }
            }

        }
    }
}
