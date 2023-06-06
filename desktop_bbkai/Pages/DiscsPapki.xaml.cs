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
    /// Логика взаимодействия для DiscsPapki.xaml
    /// </summary>
    public partial class DiscsPapki : Page
    {
        public DiscsPapki()
        {
            InitializeComponent();
            if (Class1.auth_user.role_u == 3)
                lbl.Content = bbkaiEntities.GetContext().Discs.Where(x => x.id_d == Class1.g_d.id_d).FirstOrDefault().name_d.ToString();
            else if (Class1.auth_user.role_u == 2)
                lbl.Content = bbkaiEntities.GetContext().Discs.Where(x => x.id_d == Class1.u_d.id_d).FirstOrDefault().name_d.ToString();
            Image img1 = new Image();
            img1.Source = BitmapFrame.Create(new Uri(@"D:\3 курс\сайт асп\desktop_bbkai\desktop_bbkai\images\doki.png"));
            img1.Width = 50;
            img1.Height = 50;
            img1.HorizontalAlignment = HorizontalAlignment.Left;
            img1.Margin = new Thickness(0, 0, 20, 0);

            Button btn1 = new Button();
            btn1.Foreground = Brushes.Black;
            btn1.Background = Brushes.White;
            btn1.BorderBrush = null;
            btn1.FontSize = 18;
            btn1.Content = "Лекции";
            btn1.Height = 30;
            btn1.HorizontalAlignment = HorizontalAlignment.Left;
            btn1.Click += Button_Click;

            StackPanel stck1 = new StackPanel();
            stck1.Orientation = Orientation.Horizontal;
            stck1.HorizontalAlignment = HorizontalAlignment.Left;
            stck1.Children.Add(img1);
            stck1.Children.Add(btn1);

            Border brd1 = new Border();
            brd1.Child = stck1;
            brd1.Margin = new Thickness(50, 30, 50, 0);

            stack1.Children.Add(brd1);

            Image img2 = new Image();
            img2.Source = BitmapFrame.Create(new Uri(@"D:\3 курс\сайт асп\desktop_bbkai\desktop_bbkai\images\doki.png"));
            img2.Width = 50;
            img2.Height = 50;
            img2.HorizontalAlignment = HorizontalAlignment.Left;
            img2.Margin = new Thickness(0, 0, 20, 0);

            Button btn2 = new Button();
            btn2.Foreground = Brushes.Black;
            btn2.Background = Brushes.White;
            btn2.BorderBrush = null;
            btn2.FontSize = 18;
            btn2.Content = "Практические работы";
            btn2.Height = 30;
            btn2.HorizontalAlignment = HorizontalAlignment.Left;
            btn2.Click += Button1_Click;

            StackPanel stck2 = new StackPanel();
            stck2.Orientation = Orientation.Horizontal;
            stck2.HorizontalAlignment = HorizontalAlignment.Left;
            stck2.Children.Add(img2);
            stck2.Children.Add(btn2);

            Border brd2 = new Border();
            brd2.Child = stck2;
            brd2.Margin = new Thickness(50, 30, 50, 0);

            stack2.Children.Add(brd2);

            Image img3 = new Image();
            img3.Source = BitmapFrame.Create(new Uri(@"D:\3 курс\сайт асп\desktop_bbkai\desktop_bbkai\images\doki.png"));
            img3.Width = 50;
            img3.Height = 50;
            img3.HorizontalAlignment = HorizontalAlignment.Left;
            img3.Margin = new Thickness(0, 0, 20, 0);

            Button btn3 = new Button();
            btn3.Foreground = Brushes.Black;
            btn3.Background = Brushes.White;
            btn3.BorderBrush = null;
            btn3.FontSize = 18;
            btn3.Content = "Лабораторные работы";
            btn3.Height = 30;
            btn3.HorizontalAlignment = HorizontalAlignment.Left;
            btn3.Click += Button2_Click;

            StackPanel stck3 = new StackPanel();
            stck3.Orientation = Orientation.Horizontal;
            stck3.HorizontalAlignment = HorizontalAlignment.Left;
            stck3.Children.Add(img3);
            stck3.Children.Add(btn3);

            Border brd3 = new Border();
            brd3.Child = stck3;
            brd3.Margin = new Thickness(50, 30, 50, 0);

            stack3.Children.Add(brd3);
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            using (bbkaiEntities db = new bbkaiEntities())
            {
                foreach (var n in db.Vidi)
                {
                    if (clickedButton.Content.ToString() == n.name_v)
                    {
                        Class1.vid = n;
                        if(Class1.auth_user.role_u == 2)
                        {
                            this.NavigationService.Navigate(new DokiPapkiP());
                        }
                        else if (Class1.auth_user.role_u == 3)
                        {
                            this.NavigationService.Navigate(new DokiPapki());
                        }
                        
                    }
                }
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            using (bbkaiEntities db = new bbkaiEntities())
            {
                foreach (var n in db.Vidi)
                {
                    if (clickedButton.Content.ToString() == n.name_v)
                    {
                        Class1.vid = n;
                        if (Class1.auth_user.role_u == 2)
                        {
                            this.NavigationService.Navigate(new DokiPapkiP());
                        }
                        else if (Class1.auth_user.role_u == 3)
                        {
                            this.NavigationService.Navigate(new DokiPapki());
                        }

                    }
                }
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            using (bbkaiEntities db = new bbkaiEntities())
            {
                foreach (var n in db.Vidi)
                {
                    if (clickedButton.Content.ToString() == n.name_v)
                    {
                        Class1.vid = n;
                        if (Class1.auth_user.role_u == 2)
                        {
                            this.NavigationService.Navigate(new DokiPapkiP());
                        }
                        else if (Class1.auth_user.role_u == 3)
                        {
                            this.NavigationService.Navigate(new DokiPapki());
                        }

                    }
                }
            }
        }
    }
}
