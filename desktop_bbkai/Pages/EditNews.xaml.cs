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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace desktop_bbkai.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditNews.xaml
    /// </summary>
    public partial class EditNews : Page
    {
        public EditNews()
        {
            InitializeComponent();
            zagg.Text = bbkaiEntities.GetContext().News.Where(x => x.id == Class1.newss.id).FirstOrDefault().zag;
            imgg.Text = bbkaiEntities.GetContext().News.Where(x => x.id == Class1.newss.id).FirstOrDefault().img;
            txtt.Text = bbkaiEntities.GetContext().News.Where(x => x.id == Class1.newss.id).FirstOrDefault().txt.ToString();
            txt11.Text = bbkaiEntities.GetContext().News.Where(x => x.id == Class1.newss.id).FirstOrDefault().txt1.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (imgg.Text != "" && imgg.Text != null && zagg.Text != "" && zagg.Text != null
                    && txtt.Text != "" && txtt.Text != null && txt11.Text != "" && txt11.Text != null)
                {
                    var n = bbkaiEntities.GetContext().News.Where(x => x.id == Class1.newss.id).FirstOrDefault();
                    n.img = imgg.Text;
                    n.zag = zagg.Text;
                    n.txt = txtt.Text;
                    n.txt1 = txt11.Text;
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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
