
using OfficeOpenXml;
using Microsoft.Win32;
using QuanLiKhoHang.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace QuanLiKhoHang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly QuanLiKhoHangContext dbContext1 = new QuanLiKhoHangContext();
        public ObservableCollection<Inventory> Inventories { get; set; }
        UserApp loggedInUser;
        public MainWindow()
        {
            InitializeComponent();
            lsvInventories.ItemsSource = LoadInventory();
            txbInput.Text = GetNumberOfInput().ToString();
            txbOutput.Text = GetNumberOfOutput().ToString();
            txbInven.Text = GetNumberOfInventory().ToString();
            loggedInUser = LoadLgedInUser();
        }


        private UserApp LoadLgedInUser()
        {
            UserApp user = new UserApp();
            if (System.Windows.Application.Current.Properties["LoggedInUser"]!=null) {
                 user = System.Windows.Application.Current.Properties["LoggedInUser"] as UserApp;
            }
            return user;
        }
  
        int GetNumberOfInput()
        {
            QuanLiKhoHangContext dbContext = new QuanLiKhoHangContext();
            return dbContext.Inputs.Count();

        }
        int GetNumberOfOutput()
        {
            QuanLiKhoHangContext dbContext = new QuanLiKhoHangContext();
            return dbContext.Outputs.Count();   
        }
        int GetNumberOfInventory()
        {
            int total = 0;
            foreach (var item in LoadInventory())
            {
                total += item.Count;
            }
            return total;
        }
        ObservableCollection<Inventory> LoadInventory()
        {
            QuanLiKhoHangContext dbContext = new QuanLiKhoHangContext();
            Inventories = new ObservableCollection<Inventory>();
            var objectList = dbContext.ObjectItems.ToList();
            int i = 1;
            foreach (var item in objectList)
            {
                var inputList = dbContext.InputInfos.Where(p => p.IdObject == item.Id).ToList();
                var outputList = dbContext.OutputInfos.Where(p => p.IdObject == item.Id).ToList();

                int sumIn = 0;
                int sumOut = 0;
                double tottalMoneyIn = GetToTalMoneyIn(inputList);
                double tottalMoneyOut = GetToTalMoneyOut(outputList);
                if (inputList != null)
                {
                    sumIn = (int)inputList.Sum(p => p.Count);
                    
                }
                if (outputList != null)
                {
                    sumOut = (int)outputList.Sum(p => p.Count);
                }

                Inventory inventory = new Inventory()
                {
                    NumberIdx = i,
                    Count = sumIn - sumOut,
                    TotalInput = sumIn,
                    TotalOutput = sumOut,
                    ObjectItemm = item,
                    TotalMoneyIn = tottalMoneyIn,
                    TotalMoneyOut = tottalMoneyOut
                };

                Inventories.Add(inventory);
                i++;

            }
            return Inventories;

        }
        private double GetToTalMoneyIn(List<InputInfo> inputs)
        {
            double amount = 0;
            foreach (var item in inputs)
            {
                if (item.InputPrice.HasValue && item.Count.HasValue)
                {
                    amount += item.InputPrice.Value * item.Count.Value;
                }
            }
            return amount;
        }
        private double GetToTalMoneyOut(List<OutputInfo> outputs)
        {
            double amount = 0;
            foreach (var item in outputs)
            {
                if (item.IdInputInfoNavigation.OutputPrice.HasValue && item.Count.HasValue)
                {
                    amount += item.IdInputInfoNavigation.OutputPrice.Value * item.Count.Value;
                }
            }
            return amount;
        }

        private void btnFilter1_Click(object sender, RoutedEventArgs e)
        {
          
            DateTime start = (DateTime)dpStart?.SelectedDate;
            DateTime end  = (DateTime)dpEnd?.SelectedDate;
            txbInput.Text = GetInputByDate(start, end).ToString();
            txbOutput.Text = GetOutputByDate(start, end).ToString();
        }
        private int GetInputByDate(DateTime start, DateTime end)
        {
            QuanLiKhoHangContext dbContext = new QuanLiKhoHangContext();
            var inputList = from i in dbContext.Inputs
                            where  i.DateInput >= start && i.DateInput <= end
                            select i;
            return inputList.Count();
        }
        private int GetOutputByDate(DateTime start, DateTime end)
        {
            QuanLiKhoHangContext dbContext = new QuanLiKhoHangContext();
            var inputList = from i in dbContext.Outputs
                            where i.DateOutput >= start && i.DateOutput <= end
                            select i;
            return inputList.Count();
        }

        private void btnFilter2_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = (DateTime)dpStart2?.SelectedDate;
            DateTime end = (DateTime)dpEnd2?.SelectedDate;
            List<InputInfo> inputInfoByDate = FindListInputInfoByDate(start, end);
            List<OutputInfo> outputInfoByDate = FindListOutputInfoByDate(start, end);
            if (inputInfoByDate.Count != 0 || outputInfoByDate.Count != 0)
            {
                lsvInventories.ItemsSource = LoadFilterInventory(inputInfoByDate, outputInfoByDate);
            }
            else
            {
                lsvInventories.ItemsSource = LoadInventory();
                System.Windows.MessageBox.Show("Mốc thời gian không hợp lệ\n" + "Không tìm thấy bất cứ hoạt động nào");
            }
        }

        private List<InputInfo> FindListInputInfoByDate(DateTime start, DateTime end)
        {
            QuanLiKhoHangContext dbContext = new QuanLiKhoHangContext();
            var inputInfo = from i in dbContext.Inputs
                            join info in dbContext.InputInfos on i.Id equals info.IdInput
                            where i.DateInput >= start && i.DateInput <= end
                            select info;
            return inputInfo.ToList();
        }
        private List<OutputInfo> FindListOutputInfoByDate(DateTime start, DateTime end)
        {
            QuanLiKhoHangContext dbContext = new QuanLiKhoHangContext();
            var outputInfo = from ot in dbContext.Outputs
                             join otInfo in dbContext.OutputInfos on ot.Id equals otInfo.IdOutput
                             where ot.DateOutput >= start && ot.DateOutput <= end
                             select otInfo;
            return outputInfo.ToList();
        }

        private ObservableCollection<Inventory> LoadFilterInventory(List<InputInfo> inInfo, List<OutputInfo> outInfo)
        {
            ObservableCollection<Inventory> inventoriesTemp = new ObservableCollection<Inventory>();
            QuanLiKhoHangContext dbContext = new QuanLiKhoHangContext();
            var objectList = dbContext.ObjectItems.ToList();
            int i = 1;
            foreach (var item in objectList)
            {
                var inputList = inInfo.Where(p => p.IdObject == item.Id).ToList();
                var outputList = outInfo.Where(p => p.IdObject == item.Id).ToList();

                int sumIn = 0;
                int sumOut = 0;
                double tottalMoneyIn = GetToTalMoneyIn(inputList);
                double tottalMoneyOut = GetToTalMoneyOut(outputList);
                if (inputList != null)
                {
                    sumIn = (int)inputList.Sum(p => p.Count);
                }
                if (outputList != null)
                {
                    sumOut = (int)outputList.Sum(p => p.Count);
                }
                Inventory inventory = new Inventory()
                {
                    NumberIdx = i,
                    Count = sumIn - sumOut,
                    TotalInput = sumIn,
                    TotalOutput = sumOut,
                    ObjectItemm = item,
                    TotalMoneyIn = tottalMoneyIn,
                    TotalMoneyOut = tottalMoneyOut

                };
                inventoriesTemp.Add(inventory);
                i++;

            }
            return inventoriesTemp;
        }



        public void ExportToExcel(ObservableCollection<Inventory> inventories)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // or LicenseContext.Commercial

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Inventory");

                // Add headers
                worksheet.Cells[1, 1].Value = "STT";
                worksheet.Cells[1, 2].Value = "Tên vật tư";
                worksheet.Cells[1, 3].Value = "Tổng lượng nhập";
                worksheet.Cells[1, 4].Value = "Tổng tiền nhập";
                worksheet.Cells[1, 5].Value = "Tổng lượng xuất";
                worksheet.Cells[1, 6].Value = "Tổng tiền xuất";
                worksheet.Cells[1, 7].Value = "Số lượng tồn";

                // Add data
                int row = 2;
                foreach (var item in inventories)
                {
                    worksheet.Cells[row, 1].Value = item.NumberIdx;
                    worksheet.Cells[row, 2].Value = item.ObjectItemm.DisplayName;
                    worksheet.Cells[row, 3].Value = item.TotalInput;
                    worksheet.Cells[row, 4].Value = item.TotalMoneyIn;
                    worksheet.Cells[row, 5].Value = item.TotalOutput;
                    worksheet.Cells[row, 6].Value = item.TotalMoneyOut;
                    worksheet.Cells[row, 7].Value = item.Count;
                    row++;
                }

                // Auto-fit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Save the Excel file
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    DefaultExt = ".xlsx",
                    FileName = "Inventory_Export.xlsx"
                };
                bool? result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                    System.Windows.MessageBox.Show("Export completed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            if (DateIsNul())
            {
                System.Windows.MessageBox.Show("Vui lòng nhập ngày tháng!");
                lsvInventories.ItemsSource = LoadInventory();
                ExportToExcel(LoadInventory());
            }
            else
            {
                DateTime start = (DateTime)dpStart2?.SelectedDate;
                DateTime end = (DateTime)dpEnd2?.SelectedDate;
                List<InputInfo> inputInfoByDate = FindListInputInfoByDate(start, end);
                List<OutputInfo> outputInfoByDate = FindListOutputInfoByDate(start, end);
                if (inputInfoByDate.Count != 0 || outputInfoByDate.Count != 0)
                {
                    ObservableCollection<Inventory> loadInvenFiler2 = LoadFilterInventory(inputInfoByDate, outputInfoByDate);
                    lsvInventories.ItemsSource = LoadFilterInventory(inputInfoByDate, outputInfoByDate);
                    ExportToExcel(loadInvenFiler2);
                }
                else
                {
                    lsvInventories.ItemsSource = LoadInventory();
                    ExportToExcel(LoadInventory());
                    System.Windows.MessageBox.Show("Mốc thời gian không hợp lệ\n" + "Không tìm thấy bất cứ hoạt động nào");
                }
            }
            
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            var list1 = LoadInventory();
            string txt1 = GetNumberOfInput().ToString();
            string txt2 = GetNumberOfInventory().ToString();

            lsvInventories.ItemsSource = LoadInventory();
            txbInput.Text = GetNumberOfInput().ToString();
            txbOutput.Text = GetNumberOfOutput().ToString();
            txbInven.Text = GetNumberOfInventory().ToString();
        }

        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            InputWindow wd = new InputWindow();
            wd.ShowDialog();
        }

        private void btnOutput_Click(object sender, RoutedEventArgs e)
        {
            OutputWindow wd = new OutputWindow();
            wd.ShowDialog();
        }

        private void btnUnit_Click(object sender, RoutedEventArgs e)
        {
            UnitWindow wd = new UnitWindow();
            wd.ShowDialog();
        }

        private void btnObjectItem_Click(object sender, RoutedEventArgs e)
        {
            ObjectWindow wd = new ObjectWindow();
            wd.ShowDialog();
        }

        private void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            SuplierWindow wd = new SuplierWindow();
            wd.ShowDialog();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow wd = new CustomerWindow();
            wd.ShowDialog();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            if(loggedInUser.IdRole == 2)
            {
                System.Windows.MessageBox.Show("Truy cập bị từ chối!");
            }
            if(loggedInUser.IdRole == 1)
            {
                UserWindow wd = new UserWindow();
                wd.ShowDialog();
            }
           
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow wd = new ProfileWindow();
            wd.ShowDialog();
        }
        private bool DateIsNul()
        {
            bool start = dpStart2.SelectedDate != null;
            bool end = dpEnd2.SelectedDate != null;
            if(start && end)
            {
                return false;
            }else return true;
        }
    }
}