using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для Otchetii.xaml
    /// </summary>
    public partial class Otchetii : Page
    {
        public Otchetii()
        {
            InitializeComponent();
            lbl.Content = "Отчёты. " + Class1.u_d.Discs.name_d.ToString() + ": " + Class1.vid.name_v.ToString();
            listview.ItemsSource = bbkaiEntities.GetContext().Otcheti.Where(x => (x.Doki.id_di == Class1.u_d.id_d && x.Doki.id_v == Class1.vid.id_v)).OrderBy(x => x.Doki.name_d).ToList();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listview.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(tb.Text))
                return true;
            else
                return ((item as Otcheti).Doki.name_d.IndexOf(tb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var n = ((FrameworkElement)sender).DataContext as Otcheti;
            try
            {
                Process.Start(new ProcessStartInfo(n.ssilka) { UseShellExecute = true });
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

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listview.ItemsSource).Refresh();
        }
    }
}
