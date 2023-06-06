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

namespace desktop_bbkai.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text != null && login.Text != "" && pass.Text != null && pass.Text != "")
            {
                authU(login.Text, pass.Text);
                var user = bbkaiEntities.GetContext().Users.Where(u => u.login_u == login.Text && u.pass_u == pass.Text).FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
                else
                {
                    Class1.auth_user = user;
                    switch (user.role_u)
                    {
                        case 1:
                            Admin admin = new Admin();
                            admin.Show();
                            this.Close();
                            break;
                        case 2:
                            Prepod prepod = new Prepod();
                            prepod.Show();
                            this.Close();
                            break;
                        case 3:
                            Student student = new Student();
                            student.Show();
                            this.Close();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        public string authU(string login, string pass)
        {
            try
            {
                if (bbkaiEntities.GetContext().Users.Where(x => x.login_u == login && x.pass_u == pass).FirstOrDefault() != null && login != null
                    && login != "" && pass != null && pass != "")
                {
                    return "Успешно!";
                }
                else
                {
                    return "Неудачно!";
                }
            }
            catch
            {
                return "Неудачно!";
            }
        }
    }
}
