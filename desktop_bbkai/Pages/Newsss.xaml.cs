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
using System.Windows.Shapes;

namespace desktop_bbkai.Pages
{
    /// <summary>
    /// Логика взаимодействия для Newsss.xaml
    /// </summary>
    public partial class Newsss : Page
    {
        public Newsss()
        {
            InitializeComponent();
            da.Text = Class1.newss.date_n.ToString("dd.MM.yyyy");
            za.Text = Class1.newss.zag;
            im.Source = BitmapFrame.Create(new Uri(Class1.newss.img));
            tx.Text = Class1.newss.txt;
            tx1.Text = Class1.newss.txt1;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
