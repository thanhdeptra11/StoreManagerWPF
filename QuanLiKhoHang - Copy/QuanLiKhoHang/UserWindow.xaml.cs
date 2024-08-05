using Microsoft.EntityFrameworkCore;
using QuanLiKhoHang.Models;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLiKhoHang
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly QuanLiKhoHangContext _context = new QuanLiKhoHangContext();
        public UserWindow()
        {
            InitializeComponent();
            lsvUser.ItemsSource = GetAllUser();
            cbxRole.ItemsSource = GetAllRole();
            cbxRequest.ItemsSource = GetRequest();
            cbxRequest.SelectedIndex = 0;
        }

        private List<UserApp> GetAllUser()
        {
            var query = from u in _context.UserApps
                        .Include(u => u.IdRoleNavigation)
                        where u.IdRoleNavigation.DisplayName != "Admin"
                        select u;   
                        
            return query.ToList();
        }
        private List<UserRole> GetAllRole()
        {
            return new List<UserRole>(_context.UserRoles.ToList());
        }
        private List<string> GetRequest()
        {
            List<string> requests = new List<string>()
            {
                "None", "Register"
            };
            
            return requests;
        }

        private void lsvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserApp user = lsvUser.SelectedItem as UserApp;
            if (user != null)
            {

                txbDisplayname.Text = user.DisplayName;
                txbUsername.Text = user.UserName;
                cbxRole.SelectedItem = cbxRole.Items.Cast<UserRole>()
          .FirstOrDefault(item => item.Id == user.IdRole);
                if (user.Request != null)
                {
                    cbxRequest.SelectedItem = user.Request;
                }
                else
                {
                    cbxRequest.SelectedIndex = 0;
                }

            }
            else return;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (IsFullField())
            {
                UserRole role = cbxRole.SelectedValue as UserRole;
                UserApp user = new UserApp()
                {
                    DisplayName = txbDisplayname.Text,
                    UserName = txbUsername.Text,
                    IdRole = role.Id,
                    Request = cbxRequest.SelectedValue as string


                };
                _context.UserApps.Add(user);
                _context.SaveChanges();
                lsvUser.ItemsSource = GetAllUser();

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            


        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
            UserApp user = lsvUser.SelectedItem as UserApp;
            UserRole role = cbxRole.SelectedValue as UserRole;
            if (user != null && IsFullField())
            {
                user.DisplayName = txbDisplayname.Text;
                user.UserName = txbUsername.Text;
                user.IdRole = role.Id;
                if (user.Request != null)
                {
                    user.Request = cbxRequest.SelectedValue as string;
                }
                _context.UserApps.Update(user);
                _context.SaveChanges();
                lsvUser.ItemsSource = GetAllUser();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return ;
            }
               

           
           
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            UserApp user = lsvUser.SelectedItem as UserApp;
            UserRole role = cbxRole.SelectedValue as UserRole;
            if (user != null)
            {
                _context.UserApps.Remove(user);
                _context.SaveChanges();
                lsvUser.ItemsSource = GetAllUser();
            }
            else return;
            
        }
        private bool IsFullField()
        {
            bool role = cbxRole.SelectedValue as UserRole != null;
            bool username = !string.IsNullOrEmpty(txbUsername.Text);
            bool request = cbxRequest.SelectedValue as string != null;


            if (role && username && request)
            {
                return true;
            }
            else return false;
        }

    }
}
