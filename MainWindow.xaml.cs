using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            //_ = db.Users.ToList();
            //string str = "";
            //foreach (User user in db.Users) {
            //    str += "Login: " + user.Login + " | "; 
            //    exampleText.Text = str;
            //}

            DoubleAnimation btnAnimation = new()
            {
                From = 0,
                To = 400,
                Duration = TimeSpan.FromSeconds(2)
            };
            regButton.BeginAnimation(Button.WidthProperty, btnAnimation);
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passBoxPassword.Password.Trim();
            string password2 = passBoxPasswordReturn.Password.Trim();
            string email = textBoxEmail.Text.ToLower();

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
            else if (password != password2)
            {
                passBoxPasswordReturn.ToolTip = "Введенные пароли не совпадают";
                passBoxPasswordReturn.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains('@') || !email.Contains('.'))
            {
                textBoxEmail.ToolTip = "Email введен неверно";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                passBoxPassword.ToolTip = "";
                passBoxPassword.Background = Brushes.Transparent;

                passBoxPasswordReturn.ToolTip = "";
                passBoxPasswordReturn.Background = Brushes.Transparent;

                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                //MessageBox.Show("Регистрация выполнена");

                db.Database.EnsureCreated();
                User user = new(login, password, email);
                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new();
                Hide();
                authWindow.Show();
            }
        }

        private void Button_Auth_Window_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new();
            Hide();
            authWindow.Show();
        }
    }
}