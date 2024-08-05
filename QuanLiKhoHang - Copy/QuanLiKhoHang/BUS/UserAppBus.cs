using QuanLiKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhoHang.BUS
{
    public class UserAppBus
    {
        private readonly QuanLiKhoHangContext quanLiKhoHangContext = new QuanLiKhoHangContext();

        public bool IsLoggedIn(string username, string password) {
            bool resutl = quanLiKhoHangContext.UserApps.Any(u => u.UserName.Equals(username) && u.Password.Equals(password));
            return resutl;
        
        
        }
        public UserApp GetUser(string username, string pass)
        {
            return quanLiKhoHangContext.UserApps.FirstOrDefault(u => u.UserName.Equals(username) && u.Password.Equals(pass));
        }
        public UserApp GetUser(string email)
        {
            return quanLiKhoHangContext.UserApps.FirstOrDefault(u => u.Email.Equals(email));
        }
        public void ChangePassword(string email, string password) {
            UserApp user = GetUser(email);
            user.Password = password;
            quanLiKhoHangContext.Update(user);
            quanLiKhoHangContext.SaveChanges();
        }
    }
}
