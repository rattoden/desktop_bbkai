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
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace desktop_bbkai.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddNews.xaml
    /// </summary>
    public partial class AddNews : Page
    {
        public AddNews()
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
                if (imgg.Text != "" && imgg.Text != null && zagg.Text != "" && zagg.Text != null
                    && txtt.Text != "" && txtt.Text != null && txt11.Text != "" && txt11.Text != null)
                {
                    News n = new News()
                    {
                        img = imgg.Text,
                        zag = zagg.Text,
                        txt = txtt.Text,
                        date_n = DateTime.Now,
                        txt1 = txt11.Text
                    };
                    bbkaiEntities.GetContext().News.Add(n);
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
