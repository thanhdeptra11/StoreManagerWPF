using QuanLiKhoHang.BUS;
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
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLiKhoHang
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly QuanLiKhoHangContext db = new QuanLiKhoHangContext();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserAppBus userAppBus = new UserAppBus();
            string username = txbUsername.Text;
            string pass = txbPassword.Password.ToString();
            UserApp user = userAppBus.GetUser(username, pass);
            if (user != null)
            {
                if (user.Request!=null)
                {
                    if (user.Request.Equals("Register"))
                    {
                        MessageBox.Show("Không thể đăng nhập!\nTài khoản đang được phê duyệt");
                    }
                    
                }
                 if(user.Request==null  || !user.Request.Equals("Register"))
                {
                    Application.Current.Properties["LoggedInUser"] = user;
                    MessageBox.Show($"Welcome {user.UserName}");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }

            }
           
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc tài khoản");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register wd = new Register();
            wd.Show();
            this.Close();
        }

        private void btnFogotPass_Click(object sender, RoutedEventArgs e)
        {
            FogotPassword fp = new FogotPassword();
            fp.Show();
            this.Close();
        }
    }
}
