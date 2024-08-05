using QuanLiKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

     



        private void txbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            QuanLiKhoHangContext db = new QuanLiKhoHangContext();
            string check = txbPassword.Password.ToString();
            string pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,10}";
            if (Regex.IsMatch(check, pattern))
            {
                return;
            }
            else
            {
                MessageBox.Show("Mật khẩu gồm 6 đến 10 kí tự và phải có ít nhất 1 kí tự số 1 kí tự số, 1 kí tự viết thường");
                txbPassword.Clear();
            }

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            QuanLiKhoHangContext db = new QuanLiKhoHangContext();
            if (string.IsNullOrWhiteSpace(txbUsername.Text.Trim())||
                string.IsNullOrWhiteSpace(txbPassword.Password)||
                string.IsNullOrWhiteSpace(txbPasswordReEnter.Password)||
                string.IsNullOrWhiteSpace(txbEmail.Text)||
                string.IsNullOrWhiteSpace(txbOTP.Text))
            {
                MessageBox.Show("Vui lòng điền đẩy đủ thông tin!");
                return;
            }else if (!txbOTP.Text.Equals(otp))
            {
                MessageBox.Show("Mã otp không hợp lệ!\nVui lòng chọn lại otp");
                otp = "";
                txbOTP.Clear();
            }
            else
            {
                UserApp user = new UserApp() {
                    UserName = txbUsername.Text,
                    Password = txbPassword.Password,
                    IdRole = 2,
                    Request = "Register",
                    Email = txbEmail.Text
                };
                db.UserApps.Add(user);
                db.SaveChanges();
                MessageBox.Show("Tài khoản của bạn đã được đăng kí thành công!\nVui lòng đợi quản trị viên phê duyệt");
            }
        }

        private void txbUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            QuanLiKhoHangContext db = new QuanLiKhoHangContext();
            string username = txbUsername.Text.Trim();
            bool userNameExist = db.UserApps.Any(u => u.UserName.Equals(username));
            if (userNameExist)
            {
                MessageBox.Show("Tên người dùng đã tồn tại!");
                txbUsername.Clear();
            }
        }

        private void txbPasswordReEnter_LostFocus(object sender, RoutedEventArgs e)
        {
            string password = txbPassword.Password.ToString();
            string rePass = txbPasswordReEnter.Password.ToString();
            if (!password.Equals(rePass))
            {
                MessageBox.Show("Mật khẩu không khớp!");
                txbPasswordReEnter.Clear();
            }
        }

        private void txbEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            string email = txbEmail.Text;
            if (CheckEmail(email))
            {
                MessageBox.Show("Email đã được đăng kí!");
                txbEmail.Clear();
            }
            else
            {
                
            }
        }

        private const int MaxRequests = 2; // Max number of requests allowed
        private const int RequestPeriodMinutes = 1; // Time period for requests in minutes

        private int limitNumberRequest = 0;
        private DateTime lastRequestTime = DateTime.MinValue;
        private string otp;


        private void btnSendOTP_Click_1(object sender, RoutedEventArgs e)
        {
            string email = txbEmail.Text;
            if (CheckEmailFormat(email))
            {
                DateTime currDateTime = DateTime.Now;

                if (CheckEmail(email))
                {
                    MessageBox.Show("Email đã được đăng kí!");
                    txbEmail.Clear();
                    return;
                }

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
        private void SendOTP() {
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
                MessageBox.Show("Mã OTP đã được gửi qua mail của bạn!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể gửi mã OTP!");
                return;
            }
        }

        private void btnReturnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow wd = new LoginWindow();
            wd.Show();
            this.Close();

        }
    }
}
