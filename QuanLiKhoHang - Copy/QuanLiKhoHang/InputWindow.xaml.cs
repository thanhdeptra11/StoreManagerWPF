using Microsoft.EntityFrameworkCore;
using QuanLiKhoHang.Models;
using QuanLiKhoHang.BUS;
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
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    
    
    public partial class InputWindow : Window
    {
        private readonly QuanLiKhoHangContext dbContext = new QuanLiKhoHangContext();
        private UserApp user = System.Windows.Application.Current.Properties["LoggedInUser"] as UserApp;
        public InputWindow()
        {
            InitializeComponent();
            cbxObjectItem.ItemsSource = GetAllItem();
            cbxObjectItem.SelectedIndex = 0;
            lsvInput.ItemsSource = LoadInputListView();
            
        }

        private List<ObjectItem> GetAllItem()
        {
            return new List<ObjectItem>(dbContext.ObjectItems);
        }
        private List<InputInfo> LoadInputListView()
        {
            var query = from info in dbContext.InputInfos
                        .Include(i=> i.IdObjectNavigation)
                        .Include(i => i.IdInputNavigation)
                        .Include(i=>i.User)
                        where info.Status != "hide"
                        select info;
            return query.ToList();
        }

        private void lsvInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InputInfo selected = (InputInfo)lsvInput.SelectedItem;
            if (selected != null)
            {
                cbxObjectItem.SelectedItem = cbxObjectItem.Items.Cast<ObjectItem>()
            .FirstOrDefault(item => item.Id == selected.IdObject);
                dpDateInput.SelectedDate = selected.IdInputNavigation.DateInput;
                txbQuantity.Text = selected.Count.ToString();
                txbInputPrice.Text = selected.InputPrice.ToString();
                txbOutputPrice.Text = selected.OutputPrice.ToString();
                if (selected.Status != null)
                {
                    txbStatus.Text = selected.Status;
                }
            }
            else return;
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            InputInfo selected = (InputInfo)lsvInput.SelectedItem;
            if (selected != null)
            {
                if (IsFullField())
                {
                    ObjectItem selectedCbx = cbxObjectItem.SelectedValue as ObjectItem;
                    selected.IdObjectNavigation = selectedCbx;
                    selected.IdInputNavigation.DateInput = dpDateInput.SelectedDate;
                    if (int.TryParse(txbQuantity.Text, out int result))
                    {
                        selected.Count = result;
                    }
                    else
                    {
                        MessageBox.Show("Số lượng không hợp lệ");
                    }
                    if (double.TryParse(txbInputPrice.Text, out double inputPrice) && double.TryParse(txbOutputPrice.Text, out double outputPrice))
                    {

                        selected.InputPrice = inputPrice;
                        selected.OutputPrice = outputPrice;
                    }
                    else
                    {
                        MessageBox.Show("Số tiền nhập vào không hợp lệ");
                    }
                    string status = txbStatus?.Text;
                    selected.Status = status;
                    dbContext.InputInfos.Update(selected);
                    dbContext.SaveChanges();
                    lsvInput.ItemsSource = LoadInputListView();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin!");
                }
                
            }
            else return;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            InputInfo selected = (InputInfo)lsvInput.SelectedItem;
            if (selected != null)
            {
                selected.Status = "hide";
                dbContext.InputInfos.Update(selected);
                dbContext.SaveChanges();
                cbxObjectItem.SelectedIndex = -1;
                dpDateInput.SelectedDate = null;
                txbInputPrice.Clear();
                txbOutputPrice.Clear();
                txbQuantity.Clear();
                txbStatus.Clear();
                lsvInput.ItemsSource = LoadInputListView();

            }
            else return;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            InputAndInputInfoBus inputBus = new InputAndInputInfoBus();

            if (IsFullField())
            {
                ObjectItem selected = cbxObjectItem.SelectedValue as ObjectItem;
                DateTime dateInput = (DateTime)dpDateInput?.SelectedDate;
                string itemName = selected.DisplayName;

                Input newInput = inputBus.CreateInput(dateInput);

                //Input Info

                string idInputInfo = inputBus.GenerateIdOfInputInfo(selected.DisplayName, newInput);
                string IdObjectt = selected.Id;
                string IdInputt = newInput.Id;
                int amount = 0;
                if (int.TryParse(txbQuantity.Text, out int result))
                {
                    amount = result;
                }
                else
                {
                    amount = 1;
                }
                double inPricee = 0;
                if (int.TryParse(txbInputPrice.Text, out int inPrice))
                {
                    inPricee = inPrice;
                }
                else
                {
                    inPricee = 0;
                }
                double outPricee = 0;
                if (int.TryParse(txbOutputPrice.Text, out int outPrice))
                {
                    outPricee = outPrice;
                }
                else
                {
                    outPricee = 0;
                }
                string status = txbStatus.Text;

                InputInfo newInputInfo = new InputInfo()
                {

                    Id = idInputInfo,
                    IdObject = IdObjectt,
                    IdInput = IdInputt,
                    Count = amount,
                    InputPrice = inPricee,
                    OutputPrice = outPricee,
                    Status = status,
                    UserId = user.Id
                };

                dbContext.Add(newInputInfo);
                dbContext.SaveChanges();
                lsvInput.ItemsSource = LoadInputListView();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
            }
            


        }

        private void txbQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(txbQuantity.Text, out int result))
            {
                if (result > 0 && result < 500)
                {
                    txbStatus.Text = "Dang-Kinh-Doanh";
                }
                else if (result > 500 || result > -500)
                {
                    txbStatus.Text = "Ngung-Kinh-Doanh";
                }
                else if (result < 0)
                {
                    txbStatus.Text = "Ngung-Kinh-Doanh";
                }
            }
            else {
                return;
                
            } 
        }
        private bool IsFullField()
        {
            bool objectName = cbxObjectItem.SelectedValue as ObjectItem != null;
            bool datee = dpDateInput.SelectedDate != null;
            bool amount = txbQuantity.Text != null;
            bool input = txbInputPrice.Text != null;    
            bool output = txbOutputPrice.Text != null;

            if (objectName&&datee&&amount&&input&&output)
            {
                return true;
            }else return false;
        }

        private void txbQuantity_LostFocus(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txbQuantity.Text, out int result))
            {
                return;
            }
            else
            {
                txbQuantity.Clear();
                MessageBox.Show("Số lượng không hợp lê!");

            }
        }

        private void txbInputPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txbInputPrice.Text, out int result))
            {
                return;
            }
            else
            {
                txbInputPrice.Clear();
                MessageBox.Show("Giá tiền không hợp lệ!");

            }
        }

        private void txbOutputPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txbOutputPrice.Text, out int result))
            {
                return;
            }
            else
            {
                txbOutputPrice.Clear();
                MessageBox.Show("Giá tiền không hợp lệ!");

            }
        }
    }
}
