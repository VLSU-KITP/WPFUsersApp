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

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passBoxPassword.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено неверно";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (password.Length < 5)
            {
                passBoxPassword.ToolTip = "Слишком короткий пароль";
                passBoxPassword.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBoxPassword.ToolTip = "";
                passBoxPassword.Background = Brushes.Transparent;

                User? authUser = null;
                using (ApplicationContext db = new())
                {
                    authUser = db.Users.Where(b => b.Login == login & b.Password == password).FirstOrDefault();
                }
                if (authUser != null)
                {                     
                    MessageBox.Show("Авторизация выполнена"); 
                    UserPageWindow userPageWindow = new();
                    userPageWindow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("неправильные логин или пароль");
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            Hide();
            mainWindow.Show();
        }
    }
}
