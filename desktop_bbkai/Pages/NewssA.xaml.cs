using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для NewssA.xaml
    /// </summary>
    public partial class NewssA : Page
    {
        public NewssA()
        {
            InitializeComponent();
            vivodNews();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listview.ItemsSource);
            view.Filter = UserFilter;
        }

        public string vivodNews()
        {
            try
            {
                listview.ItemsSource = bbkaiEntities.GetContext().News.OrderByDescending(x => x.date_n).ToList();
                return "Успешно!";
            }
            catch
            {
                return "Неудачно!";
            }
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(tb.Text))
                return true;
            else
                return ((item as News).zag.IndexOf(tb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listview.ItemsSource).Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddNews());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var editNews = ((FrameworkElement)sender).DataContext as News;
            Class1.newss = editNews;
            this.NavigationService.Navigate(new EditNews());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить новость?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var deleteNews = ((FrameworkElement)sender).DataContext as News;
                bbkaiEntities.GetContext().News.Remove(deleteNews);
                bbkaiEntities.GetContext().SaveChanges();
                listview.ItemsSource = bbkaiEntities.GetContext().News.ToList();
            }
        }
    }
}
