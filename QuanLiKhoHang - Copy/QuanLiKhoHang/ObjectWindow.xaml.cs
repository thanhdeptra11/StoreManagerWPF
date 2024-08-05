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
    /// Interaction logic for ObjectWindow.xaml
    /// </summary>
    public partial class ObjectWindow : Window
    {
        private readonly QuanLiKhoHangContext db = new QuanLiKhoHangContext();
        public ObjectWindow()
        {
            InitializeComponent();
            cbxSupplier.ItemsSource = GetAllSupplier();
            cbxSupplier.SelectedIndex = 0;  
            cbxUnit.ItemsSource = GetAllUnit();
            cbxUnit.SelectedIndex = 0;
            lsvObjectItem.ItemsSource = GetAllObjItem();
        }
        private List<Unit> GetAllUnit()
        {
            return new List<Unit>(db.Units.ToList());
        }
        private List<Supplier> GetAllSupplier()
        {
            return new List<Supplier>(db.Suppliers.ToList());
        }
        private List<ObjectItem> GetAllObjItem()
        {
            return new List<ObjectItem>(db.ObjectItems.ToList());
        }

        private void lsvObjectItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObjectItem selected = lsvObjectItem.SelectedValue   as ObjectItem;
            if (selected != null)
            {
                txbObjectItem.Text = selected.DisplayName;
                cbxSupplier.SelectedItem = cbxSupplier.Items.Cast<Supplier>()
            .FirstOrDefault(item => item.Id == selected.IdSupplier);
                cbxUnit.SelectedItem = cbxUnit.Items.Cast<Unit>()
            .FirstOrDefault(item => item.Id== selected.IdUnit);
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
                ObjectItemBus objectItemBus = new ObjectItemBus();
                string name = txbObjectItem.Text;
                string id = objectItemBus.GenerateIdOfObjectItem(name);

                Unit unit = cbxUnit.SelectedValue as Unit;
                int unitId = unit.Id;

                Supplier supplier = cbxSupplier.SelectedValue as Supplier;
                int supId = supplier.Id;

                ObjectItem objectItem = new ObjectItem()
                {
                    Id = id,
                    DisplayName = name,
                    IdUnit = unitId,
                    IdSupplier = supId
                };
                db.ObjectItems.Add(objectItem);
                db.SaveChanges();
                lsvObjectItem.ItemsSource = GetAllObjItem();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            ObjectItem selected = lsvObjectItem.SelectedItem as ObjectItem;
            if (selected != null)
            {
                if (IsFullField())
                {
                    selected.DisplayName = txbObjectItem.Text;

                    Unit unit = cbxUnit.SelectedValue as Unit;
                    selected.IdUnit = unit.Id;

                    Supplier supplier = cbxSupplier.SelectedValue as Supplier;
                    selected.IdSupplier = supplier.Id;
                    db.ObjectItems.Update(selected);
                    db.SaveChanges(true);
                    lsvObjectItem.ItemsSource = GetAllObjItem();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin!");
                    return;
                }
                
            }
            else
            {
                return;
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            ObjectItem selected = lsvObjectItem.SelectedItem as ObjectItem;
            if (selected != null)
            {
                
                db.ObjectItems.Remove(selected);
                db.SaveChanges(true);
                lsvObjectItem.ItemsSource = GetAllObjItem();
            }
            else
            {
                return;
            }
        }
        private bool IsFullField()
        {
            bool supplier = cbxSupplier.SelectedValue as Supplier != null;
            bool objectName = !string.IsNullOrEmpty(txbObjectItem.Text);
            bool unit = cbxUnit.SelectedValue as Unit != null;
      
            if (supplier&&objectName&&unit)
            {
                return true;
            }
            else return false;
        }
    }
}
