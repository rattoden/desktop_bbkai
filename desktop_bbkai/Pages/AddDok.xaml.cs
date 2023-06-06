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
    /// Логика взаимодействия для AddDok.xaml
    /// </summary>
    public partial class AddDok : Page
    {
        public AddDok()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (namee.Text != "" && namee.Text != null && ssilkaa.Text != "" && ssilkaa.Text != null)
                {
                    int i;
                    if (checkBox1.IsChecked == true)
                        i = 1;
                    else
                        i = 0;
                    Doki n = new Doki()
                    {
                        id_u = Class1.auth_user.id_u,
                        id_v = Class1.vid.id_v,
                        name_d = namee.Text,
                        ssilka_d = ssilkaa.Text,
                        flag_d = i,
                        id_di = Class1.u_d.id_d
                    };
                    bbkaiEntities.GetContext().Doki.Add(n);
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
