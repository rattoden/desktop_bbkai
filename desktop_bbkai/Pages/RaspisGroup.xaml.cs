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
    /// Логика взаимодействия для RaspisGroup.xaml
    /// </summary>
    public partial class RaspisGroup : Page
    {
        public RaspisGroup(int a)
        {
            InitializeComponent();
            try
            {
                lbl.Content = "Расписание группы " + bbkaiEntities.GetContext().Groups.Where(x => x.id_g == Class1.rasp.id_g).FirstOrDefault().num_g.ToString() + "";
                if (a == 0)
                {
                    lbl.Content += " (чет)";
                    gridRaspis1.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 1 && (x.id_c == 1 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                    gridRaspis2.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 2 && (x.id_c == 1 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                    gridRaspis3.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 3 && (x.id_c == 1 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                    gridRaspis4.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 4 && (x.id_c == 1 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                    gridRaspis5.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 5 && (x.id_c == 1 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                    gridRaspis6.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 6 && (x.id_c == 1 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                }
                else
                {
                    lbl.Content += " (неч)";
                    gridRaspis1.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 1 && (x.id_c == 2 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                    gridRaspis2.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 2 && (x.id_c == 2 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                    gridRaspis3.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 3 && (x.id_c == 2 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                    gridRaspis4.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 4 && (x.id_c == 2 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                    gridRaspis5.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 5 && (x.id_c == 2 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                    gridRaspis6.ItemsSource = bbkaiEntities.GetContext().Raspis.Where(x => (x.id_g == Class1.rasp.id_g && x.id_n == 6 && (x.id_c == 2 || x.id_c == 3))).OrderBy(x => x.id_t).ToList();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
