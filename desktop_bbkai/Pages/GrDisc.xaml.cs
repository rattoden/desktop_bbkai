using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для DiscUser.xaml
    /// </summary>
    public partial class GrDisc : Page
    {
        public bbkaiEntities db = new bbkaiEntities();
        public GrDisc()
        {
            InitializeComponent();
            grid.ItemsSource = bbkaiEntities.GetContext().G_D.OrderBy(x => x.Groups.num_g).ToList();
            prep.ItemsSource = bbkaiEntities.GetContext().Groups.ToList();
            prep1.ItemsSource = bbkaiEntities.GetContext().Groups.ToList();
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
                return ((item as G_D).Groups.num_g.IndexOf(tb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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
            var editUD = ((FrameworkElement)sender).DataContext as G_D;
            Class1.g_d1 = editUD;
            gridAdd.Visibility = Visibility.Collapsed;
            gridEdit.Visibility = Visibility.Visible;
            prep1.SelectedValue = editUD.Groups.num_g.ToString();
            dis1.SelectedValue = editUD.Discs.name_d.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var deleteUD = ((FrameworkElement)sender).DataContext as G_D;
                if (deleteUD != null)
                {
                    var existingDeleteUD = db.G_D.Find(deleteUD.id_g_d);
                    if (existingDeleteUD != null)
                    {
                        db.G_D.Remove(existingDeleteUD);
                        db.SaveChanges();
                    }
                }
                grid.ItemsSource = bbkaiEntities.GetContext().G_D.OrderBy(x => x.Groups.num_g).ToList();
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (db.G_D.Where(x => x.id_g == db.G_D.Where(u => u.Groups.num_g == (string)prep.SelectedValue).FirstOrDefault().id_g && x.id_d == db.G_D.Where(u => u.Discs.name_d == (string)dis.SelectedValue).FirstOrDefault().id_d).FirstOrDefault() == null)
                {
                    G_D news = new G_D
                    {
                        id_g = bbkaiEntities.GetContext().Groups.Where(x => x.num_g == prep.SelectedValue).FirstOrDefault().id_g,
                        id_d = bbkaiEntities.GetContext().Discs.Where(u => u.name_d == dis.SelectedValue).FirstOrDefault().id_d
                    };
                    db.G_D.Add(news);
                    db.SaveChanges();
                    MessageBox.Show("Успешно");
                    grid.ItemsSource = bbkaiEntities.GetContext().G_D.OrderBy(x => x.Groups.num_g).ToList();
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
                var n = Class1.g_d1;
                n.id_g = bbkaiEntities.GetContext().Groups.Where(x => x.num_g == prep1.SelectedValue).FirstOrDefault().id_g;
                n.id_d = bbkaiEntities.GetContext().Discs.Where(u => u.name_d == dis1.SelectedValue).FirstOrDefault().id_d;
                bbkaiEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно");
                grid.ItemsSource = bbkaiEntities.GetContext().G_D.OrderBy(x => x.Groups.num_g).ToList();
                Class1.u_d1 = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
