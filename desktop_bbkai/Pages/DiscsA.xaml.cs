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
    /// Логика взаимодействия для DiscsA.xaml
    /// </summary>
    public partial class DiscsA : Page
    {
        public bbkaiEntities db = new bbkaiEntities();
        public DiscsA()
        {
            InitializeComponent();
            grid.ItemsSource = bbkaiEntities.GetContext().Discs.OrderBy(x => x.name_d).ToList();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(grid.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(tb.Text))
                return true;
            else
                return ((item as Discs).name_d.IndexOf(tb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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
            var editDisk = ((FrameworkElement)sender).DataContext as Discs;
            Class1.disc = editDisk;
            gridAdd.Visibility = Visibility.Collapsed;
            gridEdit.Visibility = Visibility.Visible;
            dis1.Text = Class1.disc.name_d.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить дисциплину?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var deleteDisc = ((FrameworkElement)sender).DataContext as Discs;
                bbkaiEntities.GetContext().Discs.Remove(deleteDisc);
                bbkaiEntities.GetContext().SaveChanges();
                grid.ItemsSource = bbkaiEntities.GetContext().Discs.OrderBy(x => x.name_d).ToList();
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dis.Text != "" && dis.Text != null)
                {
                    if (db.Discs.Where(x => x.name_d == dis.Text).FirstOrDefault() == null)
                    {
                        Discs n = new Discs()
                        {
                            name_d = dis.Text
                        };
                        bbkaiEntities.GetContext().Discs.Add(n);
                        bbkaiEntities.GetContext().SaveChanges();
                        MessageBox.Show("Успешно");
                        grid.ItemsSource = bbkaiEntities.GetContext().Discs.OrderBy(x => x.name_d).ToList();
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
                this.NavigationService.GoBack();
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dis1.Text != "" && dis1.Text != null)
                {
                    int n = Class1.disc.id_d;
                    editDisc(n, dis1.Text);
                    MessageBox.Show("Успешно");
                    grid.ItemsSource = bbkaiEntities.GetContext().Discs.OrderBy(x => x.name_d).ToList();
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.NavigationService.GoBack();
            }
        }

        public string editDisc(int id, string dis)
        {
            try
            {
                if (dis != null && dis != "")
                {
                    var disc = bbkaiEntities.GetContext().Discs.FirstOrDefault(x => x.id_d == id);
                    disc.name_d = dis;
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
