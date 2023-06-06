using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для DiscUser.xaml
    /// </summary>
    public partial class DiscUser : Page
    {
        public bbkaiEntities db = new bbkaiEntities();
        public DiscUser()
        {
            InitializeComponent();
            grid.ItemsSource = bbkaiEntities.GetContext().U_D.OrderBy(x => x.Users.fio_u).ToList();
            prep.ItemsSource = bbkaiEntities.GetContext().Users.Where(x => x.role_u == 2).ToList();
            prep1.ItemsSource = bbkaiEntities.GetContext().Users.Where(x => x.role_u == 2).ToList();
            dis.ItemsSource = bbkaiEntities.GetContext().Discs.ToList();
            dis1.ItemsSource = bbkaiEntities.GetContext().Discs.ToList();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(grid.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(tb.Text))
                return true;
            else
                return ((item as U_D).Users.fio_u.IndexOf(tb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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
            var editUD = ((FrameworkElement)sender).DataContext as U_D;
            Class1.u_d1 = editUD;
            gridAdd.Visibility = Visibility.Collapsed;
            gridEdit.Visibility = Visibility.Visible;
            prep1.SelectedValue = editUD.Users.fio_u.ToString();
            dis1.SelectedValue = editUD.Discs.name_d.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var deleteUD = ((FrameworkElement)sender).DataContext as U_D;
                if (deleteUD != null)
                {
                    var existingDeleteUD = db.U_D.Find(deleteUD.id_u_d);
                    if (existingDeleteUD != null)
                    {
                        db.U_D.Remove(existingDeleteUD);
                        db.SaveChanges();
                    }
                }
                grid.ItemsSource = bbkaiEntities.GetContext().U_D.OrderBy(x => x.Users.fio_u).ToList();
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (db.U_D.Where(x => x.id_u == db.U_D.Where(u => u.Users.fio_u == (string)prep.SelectedValue).FirstOrDefault().id_u && x.id_d == db.U_D.Where(u => u.Discs.name_d == (string)dis.SelectedValue).FirstOrDefault().id_d).FirstOrDefault() == null)
                {
                    U_D news = new U_D
                    {
                        id_u = bbkaiEntities.GetContext().Users.Where(x => x.fio_u == prep.SelectedValue).FirstOrDefault().id_u,
                        id_d = bbkaiEntities.GetContext().Discs.Where(u => u.name_d == dis.SelectedValue).FirstOrDefault().id_d
                    };
                    db.U_D.Add(news);
                    db.SaveChanges();
                    MessageBox.Show("Успешно");
                    grid.ItemsSource = bbkaiEntities.GetContext().U_D.OrderBy(x => x.Users.fio_u).ToList();
                }
                else
                {
                    MessageBox.Show("Запись уже существует");
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
                var n = Class1.u_d1;
                n.id_u = bbkaiEntities.GetContext().Users.Where(x => x.fio_u == prep1.SelectedValue).FirstOrDefault().id_u;
                n.id_d = bbkaiEntities.GetContext().Discs.Where(u => u.name_d == dis1.SelectedValue).FirstOrDefault().id_d;
                bbkaiEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно");
                grid.ItemsSource = bbkaiEntities.GetContext().U_D.OrderBy(x => x.Users.fio_u).ToList();
                Class1.u_d1 = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
