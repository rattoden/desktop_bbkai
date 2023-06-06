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
    /// Логика взаимодействия для Userii.xaml
    /// </summary>
    public partial class Userii : Page
    {
        public Userii()
        {
            InitializeComponent();
            grid.ItemsSource = bbkaiEntities.GetContext().Users.OrderBy(x => x.role_u).ToList();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(grid.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(tb.Text))
                return true;
            else
                return ((item as Users).fio_u.IndexOf(tb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(grid.ItemsSource).Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddUser());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var editUser = ((FrameworkElement)sender).DataContext as Users;
            Class1.user = editUser;
            this.NavigationService.Navigate(new EditUser());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить пользователя?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var deleteUser= ((FrameworkElement)sender).DataContext as Users;
                int a = deleteUser.id_u;
                deleteU(a);
                MessageBox.Show("Успешно");
                grid.ItemsSource = bbkaiEntities.GetContext().Users.OrderBy(x => x.role_u).ToList();
            }
        }

        public string deleteU(int id)
        {
            try
            {
                if (bbkaiEntities.GetContext().Users.Where(x => x.id_u == id).FirstOrDefault() != null)
                {
                    var b = bbkaiEntities.GetContext().Users.Where(x => x.id_u == id).FirstOrDefault();
                    bbkaiEntities.GetContext().Users.Remove(b);
                    bbkaiEntities.GetContext().SaveChanges();
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
