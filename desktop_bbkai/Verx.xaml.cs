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

namespace desktop_bbkai
{
    /// <summary>
    /// Логика взаимодействия для Verx.xaml
    /// </summary>
    public partial class Verx : UserControl
    {
        public Verx()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public bool Visible
        {
            get { return btn.IsVisible; }
            set
            {
                if (!value)
                {
                    btn.Visibility = Visibility.Hidden;
                }
            }
        }
        public string Fio { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Hide();
            Pages.Auth auth = new Pages.Auth();
            auth.Show();
        }
    }
}
