using Microsoft.EntityFrameworkCore;
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

namespace QuanLiKhoHang
{
    /// <summary>
    /// Interaction logic for OutputWindow.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {
        
        private readonly QuanLiKhoHangContext dbContext = new QuanLiKhoHangContext();
        private UserApp user = System.Windows.Application.Current.Properties["LoggedInUser"] as UserApp;
        public event EventHandler DataUpdated;
        public OutputWindow()
        {
            InitializeComponent();
            cbxCustomer.ItemsSource = GetAllCustomer();
            cbxCustomer.SelectedIndex = 0;
            cbxObjectItem.ItemsSource = GetAllItem();
            cbxObjectItem.SelectedIndex = 0;
            lsvOutput.ItemsSource = GetLsvView();
            cbxIdInputInfo.ItemsSource = GetInputInfo();
            cbxIdInputInfo.SelectedIndex = 0;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            DataUpdated?.Invoke(this, EventArgs.Empty);
        }

        private List<Customer> GetAllCustomer()
        {
            return new List<Customer>(dbContext.Customers);
        }
        private List<ObjectItem> GetAllItem()
        {
            return new List<ObjectItem>(dbContext.ObjectItems);
        }
        private List<OutputInfo> GetLsvView()
        {
            var list = dbContext.OutputInfos
                .Include(o => o.IdInputInfoNavigation)
                .Include(o => o.IdCustomerNavigation)
                .Include(o => o.IdObjectNavigation)
                .Include(o => o.IdOutputNavigation)
                .Include(o=>o.User)
                .Where(o=>o.Status!="hide"&& o.IdInputInfoNavigation.Status!="Ngung-Kinh-Doanh")
                .ToList();
                
            return list;    
        }
        private List<InputInfo> GetInputInfo()
        {
            var list = dbContext.InputInfos
                .Include(i => i.IdInputNavigation)
                .Include(i => i.IdObjectNavigation)
                .Include(i => i.OutputInfos)
                 .Where(o => o.Status != "Ngung-Kinh-Doanh")
                .ToList();
            return list;
        }
        private void lsvOutput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           OutputInfo selected = lsvOutput.SelectedItem as OutputInfo;
            if (selected != null)
            {
                cbxObjectItem.SelectedItem = cbxObjectItem.Items.Cast<ObjectItem>()
            .FirstOrDefault(item => item.Id == selected.IdObject);
                cbxCustomer.SelectedItem = cbxCustomer.Items.Cast<Customer>()
                    .FirstOrDefault(c => c.Id.Equals (selected.IdCustomer));
                cbxIdInputInfo.SelectedItem = cbxIdInputInfo.Items.Cast<InputInfo>()
                    .FirstOrDefault(c => c.Id.Equals(selected.IdInputInfo));
                dpOutputDate.SelectedDate = selected.IdOutputNavigation.DateOutput;
                txbQuantity.Text = selected.Count.ToString();
                txbOutPrice.Text = selected.IdInputInfoNavigation.OutputPrice.ToString();
                txbStatus.Clear();

            }
            else
            {
                return;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            OutputInfo selected = lsvOutput.SelectedItem as OutputInfo;
            if (selected != null && IsFullField())
            {
                InputInfo inputInfo = cbxIdInputInfo.SelectedValue as InputInfo;

                Customer customer = cbxCustomer.SelectedValue as Customer;

                selected.IdObject = inputInfo.IdObject;
                selected.IdOutputNavigation.DateOutput = dpOutputDate.SelectedDate;

                selected.IdInputInfo = inputInfo.Id;
                selected.IdCustomer = customer.Id;
                if (int.TryParse(txbQuantity.Text, out int result2))
                {
                    selected.Count = result2;

                }
                else
                {
                    MessageBox.Show("Số lượng không đúng định dạng!");
                }
                dbContext.Update(selected);
                dbContext.SaveChanges();
                lsvOutput.ItemsSource = GetLsvView();
            }
            else
            {
                return;
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            OutputInfo selected = lsvOutput.SelectedItem as OutputInfo;
            if (selected != null)
            {
                selected.Status = "hide";
                dbContext.Update(selected);
                dbContext.SaveChanges(true);
                lsvOutput.ItemsSource = GetLsvView();
            }
            else
            {
                return;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (IsFullField())
            {
                OutputAndOutputInfoBus outputBus = new OutputAndOutputInfoBus();
                InputInfo selected = cbxIdInputInfo.SelectedValue as InputInfo;
                Customer customer = cbxCustomer.SelectedValue as Customer;
                DateTime dateOutput = (DateTime)dpOutputDate?.SelectedDate;
                string itemName = selected.IdObjectNavigation.DisplayName;

                Output newOutput = outputBus.CreateOutput(dateOutput);

                //Output Info

                string idOutputInfo = outputBus.GenerateIdOfOutputInfo(itemName, newOutput);
                string IdObjectt = selected.IdObjectNavigation.Id;
                string IdOutput = newOutput.Id;
                string IdInputInfo = selected.Id;
                int cusId = customer.Id;
                int amount = 0;
                if (int.TryParse(txbQuantity.Text, out int result))
                {
                    amount = result;
                }
                else
                {
                    amount = 1;
                }
                double outPricee = 0;
                if (double.TryParse(txbOutPrice.Text, out double result2))
                {
                    outPricee = result2;
                }
                else
                {
                    outPricee = 0;
                }

                OutputInfo newOutputInfo = new OutputInfo()
                {

                    Id = idOutputInfo,
                    IdObject = IdObjectt,
                    IdOutput = IdOutput,
                    Count = amount,
                    IdInputInfo = IdInputInfo,
                    IdCustomer = cusId,
                    UserId = user.Id
                };

                dbContext.Add(newOutputInfo);
                dbContext.SaveChanges();
                lsvOutput.ItemsSource = GetLsvView();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }
            
        }

        private void cbxIdInputInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InputInfo selected = cbxIdInputInfo.SelectedValue as InputInfo;
            if (selected != null)
            {
                txbObjectName.Text = selected.IdObjectNavigation.DisplayName;
                txbOutPrice.Text = selected.OutputPrice.ToString();
            }
           
        }
        private bool IsFullField()
        {
            bool objName = !string.IsNullOrEmpty(txbObjectName.Text);
            bool iputInfoId = cbxIdInputInfo.SelectedValue as InputInfo != null;
            bool datee = dpOutputDate.SelectedDate != null;
            bool amount = !string.IsNullOrEmpty(txbQuantity.Text);
            bool price = !string.IsNullOrEmpty(txbOutPrice.Text);
            bool cus = cbxCustomer.SelectedValue as Customer != null;

            if (objName&&iputInfoId&&datee&&amount&&price&&cus)
            {
                return true;
            }
            else return false;
        }
    }
}
