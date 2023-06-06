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
    /// Логика взаимодействия для DokiPapkiP.xaml
    /// </summary>
    public partial class DokiPapkiP : Page
    {
        public DokiPapkiP()
        {
            InitializeComponent();
            lbl.Content = Class1.u_d.Discs.name_d.ToString() + ": " + Class1.vid.name_v.ToString();
            listview.ItemsSource = bbkaiEntities.GetContext().Doki.Where(x => (x.id_di == Class1.u_d.id_d && x.id_v == Class1.vid.id_v)).OrderBy(x => x.name_d).ToList();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddDok());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var editDok = ((FrameworkElement)sender).DataContext as Doki;
            Class1.dok = editDok;
            this.NavigationService.Navigate(new EditDok());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить материал?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var deleteDok = ((FrameworkElement)sender).DataContext as Doki;
                bbkaiEntities.GetContext().Doki.Remove(deleteDok);
                bbkaiEntities.GetContext().SaveChanges();
                listview.ItemsSource = bbkaiEntities.GetContext().Doki.Where(x => (x.id_di == Class1.u_d.id_d && x.id_v == Class1.vid.id_v)).OrderBy(x => x.name_d).ToList();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Otchetii());
        }
    }
}
