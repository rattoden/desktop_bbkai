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
    /// Логика взаимодействия для DokiPapki.xaml
    /// </summary>
    public partial class DokiPapki : Page
    {
        public DokiPapki()
        {
            InitializeComponent();
            lbl.Content = Class1.g_d.Discs.name_d.ToString() + ": " + Class1.vid.name_v.ToString();
            using (var db = new bbkaiEntities())
            {
                var list = bbkaiEntities.GetContext().Doki.Where(x => (x.id_di == Class1.g_d.id_d && x.id_v == Class1.vid.id_v)).OrderBy(x => x.name_d).ToList();
                foreach (Doki doki in list)
                {
                    Image img = new Image();
                    img.Source = BitmapFrame.Create(new Uri(@"D:\3 курс\сайт асп\desktop_bbkai\desktop_bbkai\images\dok.png"));
                    img.Width = 40;
                    img.Height = 40;
                    img.HorizontalAlignment = HorizontalAlignment.Left;
                    img.Margin = new Thickness(0, 0, 20, 0);

                    Button btn = new Button();
                    btn.Foreground = Brushes.Black;
                    btn.Background = Brushes.White;
                    btn.BorderBrush = null;
                    btn.FontSize = 18;
                    btn.Content = doki.name_d;
                    btn.Height = 30;
                    btn.HorizontalAlignment = HorizontalAlignment.Left;
                    btn.Click += Button_Click;

                    StackPanel stck = new StackPanel();
                    stck.Orientation = Orientation.Horizontal;
                    stck.HorizontalAlignment = HorizontalAlignment.Left;
                    stck.Children.Add(img);
                    stck.Children.Add(btn);

                    Border brd = new Border();
                    brd.Child = stck;
                    brd.Margin = new Thickness(50, 30, 50, 0);

                    stack1.Children.Add(brd);
                }
            }
            using (var db = new bbkaiEntities())
            {
                var list = bbkaiEntities.GetContext().Doki.Where(x => (x.id_di == Class1.g_d.id_d && x.id_v == Class1.vid.id_v && x.flag_d == 1)).OrderBy(x => x.name_d).ToList();
                foreach (Doki doki in list)
                {
                    Image img = new Image();
                    img.Source = BitmapFrame.Create(new Uri(@"D:\3 курс\сайт асп\desktop_bbkai\desktop_bbkai\images\skrepka.png"));
                    img.Width = 40;
                    img.Height = 40;
                    img.HorizontalAlignment = HorizontalAlignment.Left;
                    img.Margin = new Thickness(0, 0, 20, 0);

                    Button btn = new Button();
                    btn.Foreground = Brushes.Black;
                    btn.Background = Brushes.White;
                    btn.BorderBrush = null;
                    btn.FontSize = 18;
                    btn.Content = doki.name_d;
                    btn.Height = 30;
                    btn.HorizontalAlignment = HorizontalAlignment.Left;
                    btn.Click += Button1_Click;

                    StackPanel stck = new StackPanel();
                    stck.Orientation = Orientation.Horizontal;
                    stck.HorizontalAlignment = HorizontalAlignment.Left;
                    stck.Children.Add(img);
                    stck.Children.Add(btn);

                    Border brd = new Border();
                    brd.Child = stck;
                    brd.Margin = new Thickness(50, 30, 50, 0);

                    stack1.Children.Add(brd);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            using (bbkaiEntities db = new bbkaiEntities())
            {
                foreach (var n in db.Doki)
                {
                    if (clickedButton.Content.ToString() == n.name_d)
                    {
                        Process.Start(new ProcessStartInfo(n.ssilka_d) { UseShellExecute = true });
                    }
                }
            }
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            using (bbkaiEntities db = new bbkaiEntities())
            {
                foreach (var n in db.Doki)
                {
                    if (clickedButton.Content.ToString() == n.name_d)
                    {
                        Class1.dok = n;
                        this.NavigationService.Navigate(new AddOtchet());
                    }
                }
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
