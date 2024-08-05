using Microsoft.EntityFrameworkCore;
using QuanLiKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhoHang.BUS
{
    public class ObjectItemBus
    {
        private readonly QuanLiKhoHangContext db = new QuanLiKhoHangContext();
        public string GenerateIdOfObjectItem(string itemName)
        {
            string id = $"ITEM-{GetRandomNumber(2)}-{itemName.Substring(0,Math.Min(2, itemName.Length))}";
            while (true)
            {
                if (db.ObjectItems.Any(ojt => ojt.Id.Equals(id)))
                {
                    id = "";
                    id = $"ITEM-{GetRandomNumber(2)}-{itemName.Substring(0, Math.Min(2, itemName.Length))}-";
                    id += GetRandomNumber(2);
                }
                else
                {
                    break;
                }
            }
            return id;
        }
        public string GetRandomNumber(int len)
        {
            Random rnd = new Random();
            const string chars = "0123456789";
            StringBuilder sb = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                sb.Append(chars[rnd.Next(chars.Length)]);
            }
            return sb.ToString();
        }
    }
}
