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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly QuanLiKhoHangContext db = new QuanLiKhoHangContext();
        public CustomerWindow()
        {
            InitializeComponent();
            lsvCustomer.ItemsSource = GetAllCustomer();
        }
        private List<Customer> GetAllCustomer()
        {
            return new List<Customer>(db.Customers.ToList());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (IsFullField())
            {
                DateTime date;
                if (dpContractDate.SelectedDate != null)
                {
                    date = (DateTime)dpContractDate.SelectedDate;
                }
                else
                {
                    date = DateTime.Now;
                }
                Customer customer = new Customer()
                {
                    DisplayName = txbName.Text,
                    Address = txbAddress.Text,
                    Phone = txbPhone.Text,
                    MoreInfo = txbMoreInfo.Text,
                    Email = txbEmail.Text,
                    ContractDate = date,
                };

                db.Customers.Add(customer);
                db.SaveChanges();
                lsvCustomer.ItemsSource = GetAllCustomer();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            };


        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Customer selected = lsvCustomer.SelectedItem as Customer;
            if (selected != null && IsFullField())
            {
                selected.DisplayName = txbName.Text;
                selected.Address = txbAddress.Text;
                selected.Phone = txbPhone.Text;
                selected.MoreInfo = txbMoreInfo.Text;
                selected.Email = txbEmail.Text;
                selected.ContractDate = dpContractDate.SelectedDate;
                db.Customers.Update(selected);
                db.SaveChanges();
                lsvCustomer.ItemsSource = GetAllCustomer();
            }
            else {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            };
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Customer selected = lsvCustomer.SelectedItem as Customer;
            if (selected != null)
            {
                db.Customers.Remove(selected);
                db.SaveChanges();
                lsvCustomer.ItemsSource = GetAllCustomer();

            }
            else return;
        }

        private void lsvCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer selected  = lsvCustomer.SelectedItem as Customer;
            if (selected != null)
            {
                txbName.Text = selected.DisplayName;
                txbAddress.Text = selected.Address;
                txbPhone.Text = selected.Phone;
                txbMoreInfo.Text = selected.MoreInfo;
                txbEmail.Text = selected.Email;
                dpContractDate.SelectedDate  = selected.ContractDate;

            }else return;
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
