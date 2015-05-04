using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PasswordCollector.Logic;

namespace PasswordCollector
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var username = TbUsername.Text;
            var password = PbPassword.Password;

            if (HandleRequests.Login(username, password))
            {

                var newWindow = new PasswordHandler();
                //sets a new sessionvariable with the users ID
                Application.Current.Resources["currentUser"] = HandleRequests.SetCurrentUserId(username, password);
                newWindow.Show();
                Close();

            }
            else
            {
                //Error message
                MessageBox.Show("Fel användarnamn eller lösenord!");
            }

        }
    }
}
