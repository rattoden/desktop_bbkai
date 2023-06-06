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
    /// Логика взаимодействия для Newss.xaml
    /// </summary>
    public partial class Newss : Page
    {
        public Newss()
        {
            InitializeComponent();
            using (var db = new bbkaiEntities())
            {
                foreach (News news in db.News)
                {
                    Image image = new Image();
                    image.Source = BitmapFrame.Create(new Uri(news.img));
                    image.Width = 350;
                    image.HorizontalAlignment = HorizontalAlignment.Left;
                    image.Margin = new Thickness(0, 0, 20, 0);

                    Button zagolovok = new Button();
                    zagolovok.Foreground = Brushes.Black;
                    zagolovok.Background = Brushes.White;
                    zagolovok.FontWeight = FontWeights.Bold;
                    zagolovok.BorderBrush = null;
                    zagolovok.FontSize = 16;
                    zagolovok.Content = news.zag;
                    zagolovok.HorizontalAlignment = HorizontalAlignment.Left;
                    zagolovok.Click += Button1_Click;

                    TextBlock text = new TextBlock();
                    text.Text = news.txt;
                    text.Foreground = Brushes.Black;
                    text.FontSize = 14;
                    text.TextWrapping = TextWrapping.Wrap;
                    text.HorizontalAlignment = HorizontalAlignment.Left;
                    text.Margin = new Thickness(0, 5, 0, 0);

                    TextBlock date = new TextBlock();
                    date.TextWrapping = TextWrapping.Wrap;
                    date.Foreground = Brushes.DarkGray;
                    date.FontSize = 16;
                    date.HorizontalAlignment = HorizontalAlignment.Left;
                    date.Width = 100;
                    date.Text = news.date_n.ToString("dd.MM.yyyy");

                    StackPanel stackPaneltext = new StackPanel();
                    stackPaneltext.Orientation = Orientation.Vertical;
                    stackPaneltext.HorizontalAlignment = HorizontalAlignment.Left;
                    stackPaneltext.Children.Add(date);
                    stackPaneltext.Children.Add(zagolovok);
                    stackPaneltext.Children.Add(text);

                    DockPanel dock = new DockPanel();
                    dock.Children.Add(image);
                    dock.Children.Add(stackPaneltext);

                    Border border = new Border();
                    border.Child = dock;
                    border.Margin = new Thickness(30, 20, 30, 20);

                    stack.Children.Add(border);
                }
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            using (bbkaiEntities db = new bbkaiEntities())
            {
                foreach (var n in db.News)
                {
                    if (clickedButton.Content.ToString() == n.zag)
                    {
                        Class1.newss = n;
                        this.NavigationService.Navigate(new Newsss());
                    }
                }
            }
        }
    }
}
