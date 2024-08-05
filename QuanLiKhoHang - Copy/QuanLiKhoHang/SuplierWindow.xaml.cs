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

namespace QuanLiKhoHang
{
    /// <summary>
    /// Interaction logic for SuplierWindow.xaml
    /// </summary>
    public partial class SuplierWindow : Window
    {
        private readonly QuanLiKhoHangContext db = new QuanLiKhoHangContext();  
        public SuplierWindow()
        {
            InitializeComponent();
            lsvSupplier.ItemsSource = GetAllSupplier();
        }
        private List<Supplier> GetAllSupplier()
        {
            return new List<Supplier>(db.Suppliers.ToList());
        }
        private void lsvSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Supplier selected = lsvSupplier.SelectedItem as Supplier;
            if(selected != null)
            {
                txbName.Text = selected.DisplayName;
                txbAddress.Text = selected.Address;
                txbEmail.Text = selected.Email; 
                txbPhone.Text = selected.Phone;
                txbMoreInfo.Text = selected.MoreInfo;
                dpContractDate.SelectedDate = selected.ContractDate;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (IsFullField())
            {
                string name = txbName.Text;
                string phonenumber = txbPhone.Text;
                string email = txbEmail.Text;
                string moreInfo = txbMoreInfo.Text;
                string address = txbAddress.Text;
                DateTime date;
                if (dpContractDate.SelectedDate != null)
                {
                     date = (DateTime)dpContractDate.SelectedDate;
                }
                else
                {
                    date = DateTime.Now;
                }
                Supplier supplier = new Supplier()
                {
                    DisplayName = name,
                    Address = address,
                    Email = email,
                    MoreInfo = moreInfo,
                    ContractDate = date,
                    Phone = phonenumber

                };
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                lsvSupplier.ItemsSource = GetAllSupplier();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }
            

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Supplier selected = lsvSupplier.SelectedItem as Supplier;
            if (selected != null && IsFullField())
            {
                selected.DisplayName = txbName.Text;
                selected.Address = txbAddress.Text;
                selected.Email = txbEmail.Text;
                selected.Phone = txbPhone.Text;
                selected.MoreInfo = txbMoreInfo.Text;
                DateTime date;
                if (dpContractDate.SelectedDate != null)
                {
                    date = (DateTime)dpContractDate.SelectedDate;
                }
                else
                {
                    date = DateTime.Now;
                }
                db.Suppliers.Update(selected);
                db.SaveChanges();
                lsvSupplier.ItemsSource = GetAllSupplier();
            }
            else return;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Supplier selected = lsvSupplier.SelectedItem as Supplier;
            if (selected != null)
            {
                db.Suppliers.Remove(selected);
                db.SaveChanges();
                lsvSupplier.ItemsSource = GetAllSupplier();
            }
            else return;
        }
        private bool IsFullField()
        {
            bool name = !string.IsNullOrEmpty(txbName.Text);
            //bool add = string.IsNullOrEmpty(txbAddress.Text);
            bool phone = !string.IsNullOrEmpty(txbPhone.Text);

            if (name && phone)
            {
                return true;
            }
            else return false;
        }
    }
}
