using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using QuanLiKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace QuanLiKhoHang
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        UserApp user = System.Windows.Application.Current.Properties["LoggedInUser"] as UserApp;
        private Window parent; 
        public ProfileWindow()
        {
            InitializeComponent();
            SetTxbDisplayName(user);
            LoadBackFlip(user);
        }
        private void SetTxbDisplayName(UserApp user)
        {
            if (user != null)
            {
                if (user.DisplayName != null)
                {
                    txbFrontDisplayName.Text = user.DisplayName;
                }
                else
                {
                    txbFrontDisplayName.Text = "None";
                }
            }
        }

        private void LoadBackFlip(UserApp user)
        {
            QuanLiKhoHangContext db = new QuanLiKhoHangContext();
            txbDiplayName.Text = user.DisplayName;
            txbUserName.Text = user.UserName;
            txbEmail.Text = user.Email;
            var query = from u in db.UserApps
                        .Include(u => u.IdRoleNavigation)
                        where u.Id == user.Id
                        select u;
            UserApp forRole = query.FirstOrDefault(u => u.Id == user.Id);
            txbRole.Text = forRole.IdRoleNavigation.DisplayName;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DisplayNameNullOrEmpty())
            {
                QuanLiKhoHangContext db = new QuanLiKhoHangContext();
                user.DisplayName = txbDiplayName.Text;
                db.UserApps.Update(user);
                db.SaveChanges();
                SetTxbDisplayName(user);
                LoadBackFlip(user);
            }
            else
            {
                MessageBox.Show("Không cho phép để trống!");
                txbDiplayName.Text = "Default";
            }
            
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties.Remove("LoggedInUser");
            LoginWindow wd = new LoginWindow(); 
            wd.Show();
            Window main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(w=>w.Name == "MainWindowApp");
            if(main!=null) main.Close();
            this.Close();
        }
        private bool DisplayNameNullOrEmpty()
        {
            bool valid = !string.IsNullOrEmpty(txbDiplayName.Text);
            return valid;
        }
    }
}
