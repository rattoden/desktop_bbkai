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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Page
    {
        public EditUser()
        {
            InitializeComponent();
            rol.ItemsSource = bbkaiEntities.GetContext().Roles.ToList();
            group.ItemsSource = bbkaiEntities.GetContext().Groups.ToList();
            log.Text = Class1.user.login_u.ToString();
            pass.Text = Class1.user.pass_u.ToString();
            rol.SelectedValue = Class1.user.Roles.name_r.ToString();
            fio.Text = Class1.user.fio_u.ToString();
            if (Class1.user.role_u == 3)
            {
                group.SelectedValue = Class1.user.Groups.num_g.ToString();
            }
            else
            {
                group.SelectedValue = null;
            }
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
                        var n = Class1.user;
                        n.login_u = log.Text;
                        n.pass_u = pass.Text;
                        n.role_u = bbkaiEntities.GetContext().Roles.Where(x => x.name_r == (string)rol.SelectedValue).FirstOrDefault().id_r;
                        n.fio_u = fio.Text;
                        n.group_s = bbkaiEntities.GetContext().Groups.Where(x => x.num_g == (string)group.SelectedValue).FirstOrDefault().id_g;
                        bbkaiEntities.GetContext().SaveChanges();
                        MessageBox.Show("Успешно");
                        this.NavigationService.GoBack();
                    }
                    else
                    {
                        var n = Class1.user;
                        n.login_u = log.Text;
                        n.pass_u = pass.Text;
                        n.role_u = bbkaiEntities.GetContext().Roles.Where(x => x.name_r == (string)rol.SelectedValue).FirstOrDefault().id_r;
                        n.fio_u = fio.Text;
                        n.group_s = null;
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
