using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для GroupsA.xaml
    /// </summary>
    public partial class GroupsA : Page
    {
        public bbkaiEntities db = new bbkaiEntities();
        public GroupsA()
        {
            InitializeComponent();
            grid.ItemsSource = bbkaiEntities.GetContext().Groups.OrderBy(x => x.num_g).ToList();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(grid.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(tb.Text))
                return true;
            else
                return ((item as Groups).num_g.IndexOf(tb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(grid.ItemsSource).Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gridAdd.Visibility = Visibility.Visible;
            gridEdit.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var editGroup = ((FrameworkElement)sender).DataContext as Groups;
            Class1.groups = editGroup;
            gridAdd.Visibility = Visibility.Collapsed;
            gridEdit.Visibility = Visibility.Visible;
            dis1.Text = Class1.groups.num_g.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить группу?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var deleteGroup = ((FrameworkElement)sender).DataContext as Groups;
                bbkaiEntities.GetContext().Groups.Remove(deleteGroup);
                bbkaiEntities.GetContext().SaveChanges();
                grid.ItemsSource = bbkaiEntities.GetContext().Groups.OrderBy(x => x.num_g).ToList();
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dis.Text != "" && dis.Text != null)
                {
                    if (db.Groups.Where(x => x.num_g == dis.Text).FirstOrDefault() == null)
                    {
                        addGroup(dis.Text);
                        MessageBox.Show("Успешно");
                        grid.ItemsSource = bbkaiEntities.GetContext().Groups.OrderBy(x => x.num_g).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Запись уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dis1.Text != "" && dis1.Text != null)
                {
                    var n = Class1.groups;
                    n.num_g = dis1.Text;
                    bbkaiEntities.GetContext().SaveChanges();
                    MessageBox.Show("Успешно");
                    grid.ItemsSource = bbkaiEntities.GetContext().Groups.OrderBy(x => x.num_g).ToList();
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string addGroup(string group)
        {
            try
            {
                if (group != null && group != "")
                {
                    if (db.Groups.Where(x => x.num_g == group).FirstOrDefault() == null)
                    {
                        Groups n = new Groups()
                        {
                            num_g = dis.Text
                        };
                        bbkaiEntities.GetContext().Groups.Add(n);
                        bbkaiEntities.GetContext().SaveChanges();
                        return "Успешно!";
                    }
                    else
                    {
                        return "Неудачно!";
                    }
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
