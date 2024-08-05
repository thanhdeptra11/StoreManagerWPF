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
using System.Xml.Linq;

namespace QuanLiKhoHang
{
    /// <summary>
    /// Interaction logic for UnitWindow.xaml
    /// </summary>
    public partial class UnitWindow : Window
    {
        private readonly QuanLiKhoHangContext db = new QuanLiKhoHangContext();
        public UnitWindow()
        {
            InitializeComponent();
            lsvUnit.ItemsSource = GetAllUnit();
        }

        private List<Unit> GetAllUnit()
        {
            return new List<Unit>(db.Units.ToList());
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (IsFullField())
            {
                Unit unit = new Unit()
                {
                    DisplayName = txbUnitName.Text
                };
                db.Units.Add(unit);
                db.SaveChanges();
                lsvUnit.ItemsSource = GetAllUnit();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            
        }

        private void lsvUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unit unit = lsvUnit.SelectedValue as Unit;
            if (unit != null)
            {
                txbUnitName.Text = unit.DisplayName;
                lsvUnit.ItemsSource = GetAllUnit();

            }
            else return;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Unit unit = lsvUnit.SelectedValue as Unit;
            if (unit != null && IsFullField())
            {
                unit.DisplayName =txbUnitName.Text;
                db.Update(unit);
                db.SaveChanges(true);
                lsvUnit.ItemsSource = GetAllUnit();
            }
            else return;
        }
        private bool IsFullField()
        {
            bool name = !string.IsNullOrEmpty(txbUnitName.Text);
            //bool add = string.IsNullOrEmpty(txbAddress.Text);

            if (name)
            {
                return true;
            }
            else return false;
        }
    }
}
