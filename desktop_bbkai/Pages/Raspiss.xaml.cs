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
    /// Логика взаимодействия для Raspis.xaml
    /// </summary>
    public partial class Raspiss : Page
    {
        public Raspiss()
        {
            InitializeComponent();
            cb_group.ItemsSource = bbkaiEntities.GetContext().Groups.OrderBy(u => u.num_g).ToList();
            cb_teacher.ItemsSource = bbkaiEntities.GetContext().Users.Where(u => u.role_u == 2).OrderBy(u => u.fio_u).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = bbkaiEntities.GetContext().Groups.Where(u => u.num_g == (string)cb_group.SelectedValue).FirstOrDefault().id_g;
                var r = bbkaiEntities.GetContext().Raspis.Where(u => u.id_g == (int)a).FirstOrDefault();
                Class1.rasp = r;
                if (cb_ch.SelectedIndex == 0)
                {
                    int x = 0;
                    this.NavigationService.Navigate(new RaspisGroup(x));
                }
                else
                {
                    int x = 1;
                    this.NavigationService.Navigate(new RaspisGroup(x));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = bbkaiEntities.GetContext().Users.Where(u => u.fio_u == (string)cb_teacher.SelectedValue).FirstOrDefault().id_u;
                var r = bbkaiEntities.GetContext().Raspis.Where(u => u.id_u == (int)a).FirstOrDefault();
                Class1.rasp = r;
                if (cb_ch1.SelectedIndex == 0)
                {
                    int x = 0;
                    this.NavigationService.Navigate(new RaspisTeacher(x));
                }
                else
                {
                    int x = 1;
                    this.NavigationService.Navigate(new RaspisTeacher(x));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
