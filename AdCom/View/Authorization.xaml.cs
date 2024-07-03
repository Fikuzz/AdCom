using AdCom.Objects;
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
using System.Windows.Shapes;

namespace AdCom.View
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void BT_SignIn(object sender, RoutedEventArgs e)
        {
            User user = null;
            user = DataBase.SignIn(tbLogin.Text, tbPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Invalid Data");
                return;
            }
            MessageBox.Show($"Login {user.FullName}\nRole {user.Role}");
        }
    }
}
