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
    /// Логика взаимодействия для Discss.xaml
    /// </summary>
    public partial class Discss : Page
    {
        public Discss()
        {
            InitializeComponent();
            if (Class1.auth_user.role_u == 3)
            {
                using (var db = new bbkaiEntities())
                {
                    var list = bbkaiEntities.GetContext().G_D.Where(x => x.id_g == Class1.auth_user.group_s).OrderBy(x => x.Discs.name_d).ToList();
                    foreach (G_D g_D in list)
                    {
                        Button btn = new Button();
                        btn.Foreground = Brushes.Black;
                        btn.Background = Brushes.White;
                        btn.BorderBrush = null;
                        btn.FontSize = 16;
                        btn.Content = g_D.Discs.name_d;
                        btn.Height = 30;
                        btn.HorizontalAlignment = HorizontalAlignment.Left;
                        btn.Click += Button_Click;

                        StackPanel stck = new StackPanel();
                        stck.Orientation = Orientation.Vertical;
                        stck.HorizontalAlignment = HorizontalAlignment.Left;
                        stck.Children.Add(btn);

                        Border brd = new Border();
                        brd.Child = stck;
                        brd.Margin = new Thickness(30, 0, 30, 0);

                        stack.Children.Add(brd);
                    }
                }
            }
            else if(Class1.auth_user.role_u == 2)
            {
                using (var db = new bbkaiEntities())
                {
                    var list = bbkaiEntities.GetContext().U_D.Where(x => (x.id_u == Class1.auth_user.id_u && x.Users.role_u == 2)).OrderBy(x => x.Discs.name_d).ToList();
                    foreach (U_D u_D in list)
                    {
                        Button btn = new Button();
                        btn.Foreground = Brushes.Black;
                        btn.Background = Brushes.White;
                        btn.BorderBrush = null;
                        btn.FontSize = 16;
                        btn.Content = u_D.Discs.name_d;
                        btn.Height = 30;
                        btn.HorizontalAlignment = HorizontalAlignment.Left;
                        btn.Click += Button_Click;

                        StackPanel stck = new StackPanel();
                        stck.Orientation = Orientation.Vertical;
                        stck.HorizontalAlignment = HorizontalAlignment.Left;
                        stck.Children.Add(btn);

                        Border brd = new Border();
                        brd.Child = stck;
                        brd.Margin = new Thickness(30, 0, 30, 0);

                        stack.Children.Add(brd);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Class1.auth_user.role_u == 3)
            {
                Button clickedButton = (Button)sender;
                using (bbkaiEntities db = new bbkaiEntities())
                {
                    foreach (var n in db.G_D)
                    {
                        if (clickedButton.Content.ToString() == n.Discs.name_d)
                        {
                            Class1.g_d = n;
                            this.NavigationService.Navigate(new DiscsPapki());
                        }
                    }
                }
            }
            else if(Class1.auth_user.role_u == 2)
            {
                Button clickedButton = (Button)sender;
                using (bbkaiEntities db = new bbkaiEntities())
                {
                    foreach (var n in db.U_D)
                    {
                        if (clickedButton.Content.ToString() == n.Discs.name_d)
                        {
                            Class1.u_d = n;
                            this.NavigationService.Navigate(new DiscsPapki());
                        }
                    }
                }
            }
        }
    }
}
