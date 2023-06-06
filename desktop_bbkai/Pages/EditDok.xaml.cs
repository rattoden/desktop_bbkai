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
    /// Логика взаимодействия для EditDok.xaml
    /// </summary>
    public partial class EditDok : Page
    {
        public EditDok()
        {
            InitializeComponent();
            namee.Text = Class1.dok.name_d.ToString();
            ssilkaa.Text = Class1.dok.ssilka_d.ToString();
            if (Class1.dok.flag_d == 0)
                checkBox1.IsChecked = false;
            else if (Class1.dok.flag_d == 1)
                checkBox1.IsChecked = true;
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
                    var n = Class1.dok;
                    n.name_d = namee.Text;
                    n.ssilka_d = ssilkaa.Text;
                    n.flag_d = i;
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
