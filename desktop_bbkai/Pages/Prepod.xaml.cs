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

namespace desktop_bbkai.Pages
{
    /// <summary>
    /// Логика взаимодействия для Prepod.xaml
    /// </summary>
    public partial class Prepod : Window
    {
        public Prepod()
        {
            InitializeComponent();
            MainFrame.Navigate(new Newss());
            fio.Text = bbkaiEntities.GetContext().Users.Where(x => x.login_u == Class1.auth_user.login_u).FirstOrDefault().fio_u.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
            GridCursor.Margin = new Thickness(10 + (140 * index), 0, 0, 0);
            switch (index)
            {
                case 0:
                    MainFrame.Navigate(new Newss());
                    break;
                case 1:
                    MainFrame.Navigate(new Raspiss());
                    break;
                case 2:
                    MainFrame.Navigate(new Discss());
                    break;
            }
        }
    }
}
