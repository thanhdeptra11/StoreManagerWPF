using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using QuanLiKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhoHang.Models;

    public class Inventory
    {
        public ObjectItem ObjectItemm { get; set; }
        public int NumberIdx { get; set; }
        public int TotalInput { get; set; }
        public int TotalOutput { get; set; }
        public int Count { get; set; }  
        public double TotalMoneyIn {  get; set; }
        public double TotalMoneyOut {  get; set; }
    
    
    }

