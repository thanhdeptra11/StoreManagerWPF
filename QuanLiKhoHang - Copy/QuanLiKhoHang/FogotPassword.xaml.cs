using QuanLiKhoHang.BUS;
using QuanLiKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using static System.Net.WebRequestMethods;
using System.Text.RegularExpressions;

namespace QuanLiKhoHang
{
    /// <summary>
    /// Interaction logic for FogotPassword.xaml
    /// </summary>
    public partial class FogotPassword : Window
    {
        private string otp;
        public FogotPassword()
        {
            InitializeComponent();
        }

        private void txbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            QuanLiKhoHangContext db = new QuanLiKhoHangContext();
            UserAppBus bus = new UserAppBus();
            if (txbEmail.Text != null)
            {
                if (bus.GetUser(txbEmail.Text) != null)
                {
                    txbAccount.Text = bus.GetUser(txbEmail.Text).UserName;
                }
                else
                {
                    txbAccount.Clear();
                }
            }
            else
            {
                return;
            }
        }
        private void SendOTP()
        {
            Random random = new Random();
            string email = txbEmail.Text;
            otp = (random.Next(1000000, 11000000)).ToString();
            MailMessage mail = new MailMessage();
            string pass = "";
            mail.To.Add(email);
            mail.From = new MailAddress("viettran1170@gmail.com");
            mail.Subject = "Mã OTP";
            mail.Body = $"Mã OTP của bạn là: {otp}";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("viettran1170@gmail.com", pass),

            };
            try
            {
                smtp.Send(mail);
                MessageBox.Show("Mật khẩu mới đã được gửi qua mail của bạn!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể gửi mật khẩu!");
                return;
            }
        }

        private bool CheckEmailFormat(string email)
        {
            Regex extractEmailsRegex = new Regex("\\S+@\\S+\\.\\S+");
            return extractEmailsRegex.IsMatch(email);
        }
        private bool CheckEmail(string email)
        {
            QuanLiKhoHangContext db = new QuanLiKhoHangContext();
            return db.UserApps.Any(u => u.Email.Equals(email));
        }

        private const int MaxRequests = 2; // Max number of requests allowed
        private const int RequestPeriodMinutes = 1; // Time period for requests in minutes

        private int limitNumberRequest = 0;
        private DateTime lastRequestTime = DateTime.MinValue;
        private void btnRePass_Click(object sender, RoutedEventArgs e)
        {
            string email = txbEmail.Text;
            UserAppBus  bus = new UserAppBus(); 
            if(string.IsNullOrWhiteSpace(txbEmail.Text)||
                string.IsNullOrWhiteSpace(txbAccount.Text))
            {
                MessageBox.Show("Thông tin bị thiếu!");
            }
            else
            {
                if (CheckEmailFormat(email))
                {
                    DateTime currDateTime = DateTime.Now;

                    // Check if the request period has expired
                    if (currDateTime - lastRequestTime > TimeSpan.FromMinutes(RequestPeriodMinutes))
                    {
                        // Reset request count and time period
                        limitNumberRequest = 0;
                    }

                    if (limitNumberRequest < MaxRequests)
                    {
                        // Send OTP
                        SendOTP();
                        bus.ChangePassword(email, otp);
                        limitNumberRequest++;
                        lastRequestTime = currDateTime;
                    }
                    else
                    {
                        MessageBox.Show("Bạn có thể gửi tối đa 2 yêu cầu trong 1 phút!");
                    }
                }
                else
                {
                    MessageBox.Show("Sai định dạng email!");
                }
            }
           
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow wd = new LoginWindow();
            wd.Show();
            this.Close();
        }
    }
}
