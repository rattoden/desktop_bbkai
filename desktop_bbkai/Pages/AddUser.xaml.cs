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
using System.Xml.Linq;

namespace desktop_bbkai.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        public AddUser()
        {
            InitializeComponent();
            rol.ItemsSource = bbkaiEntities.GetContext().Roles.ToList();
            group.ItemsSource = bbkaiEntities.GetContext().Groups.ToList();
        }

        private void rol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rol.SelectedIndex == 2)
            {
                stck.Visibility = Visibility.Visible;
            }
            else
            {
                stck.Visibility = Visibility.Collapsed;
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (log.Text != "" && log.Text != null && pass.Text != "" && pass.Text != null
                    && fio.Text != "" && fio.Text != null)
                {
                    int i = bbkaiEntities.GetContext().Roles.Where(x => x.name_r == (string)rol.SelectedValue).FirstOrDefault().id_r;
                    if (i == 3)
                    {
                        Users n = new Users()
                        {
                            login_u = log.Text,
                            pass_u = pass.Text,
                            role_u = bbkaiEntities.GetContext().Roles.Where(x => x.name_r == (string)rol.SelectedValue).FirstOrDefault().id_r,
                            fio_u = fio.Text,
                            group_s = bbkaiEntities.GetContext().Groups.Where(x => x.num_g == (string)group.SelectedValue).FirstOrDefault().id_g
                        };
                        bbkaiEntities.GetContext().Users.Add(n);
                        bbkaiEntities.GetContext().SaveChanges();
                        MessageBox.Show("Успешно");
                        this.NavigationService.GoBack();
                    }
                    else
                    {
                        Users n = new Users()
                        {
                            login_u = log.Text,
                            pass_u = pass.Text,
                            role_u = bbkaiEntities.GetContext().Roles.Where(x => x.name_r == (string)rol.SelectedValue).FirstOrDefault().id_r,
                            fio_u = fio.Text,
                            group_s = null
                        };
                        bbkaiEntities.GetContext().Users.Add(n);
                        bbkaiEntities.GetContext().SaveChanges();
                        MessageBox.Show("Успешно");
                        this.NavigationService.GoBack();
                    }
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
