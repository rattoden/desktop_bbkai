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
using System.Xml.Linq;

namespace desktop_bbkai.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOtchet.xaml
    /// </summary>
    public partial class AddOtchet : Page
    {
        public AddOtchet()
        {
            InitializeComponent();
            disc.Content = "Дисциплина: " + Class1.dok.Discs.name_d.ToString();
            nazv.Content = "Выполнение задания: " + Class1.dok.name_d.ToString();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ssilkaa.Text != "" && ssilkaa.Text != null)
                {
                    Otcheti n = new Otcheti()
                    {
                        id_d = Class1.dok.id_d,
                        id_u = Class1.auth_user.id_u,
                        ssilka = ssilkaa.Text,
                        date_o = DateTime.Now
                    };
                    bbkaiEntities.GetContext().Otcheti.Add(n);
                    bbkaiEntities.GetContext().SaveChanges();
                    MessageBox.Show("Успешно");
                    this.NavigationService.GoBack();
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
    }
}
