using Microsoft.Extensions.Primitives;
using QuanLiKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhoHang.BUS
{
    public class InputAndInputInfoBus
    {
        private readonly QuanLiKhoHangContext _context = new QuanLiKhoHangContext();
        public string GenerateIdOfInput( DateTime inputDate)
        {
            string id = $"IN-{GetRandomNumber(3)}-{inputDate.ToString("ddMMyyyy")}-";
            id += GetRandomNumber(2);
            while (true)
            {
                if (_context.Inputs.Any(input => input.Id.Equals(id)))
                {
                    id = "";
                    id = $"IN-{GetRandomNumber(3)}-{inputDate.ToString("ddMMyyyy")}-";
                    id += GetRandomNumber(2);
                }
                else
                {
                    break;
                }
            }
            return id ;
        }
        public string GenerateIdOfInputInfo(string itemName, Input input)
        {
            string id = $"ININFO-{GetRandomNumber(3)}-{itemName}-";
            id += input.Id;
            while (true)
            {
                if (_context.InputInfos.Any(input => input.Id.Equals(id)))
                {
                    id = "";
                    id = $"ININFO-{GetRandomNumber(3)}-{itemName}-";
                    id += input.Id;
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
        public Input CreateInput(  DateTime inputDate)
        {
            Input input = new Input()
            {
                Id = GenerateIdOfInput(inputDate),
                DateInput = inputDate
            };
            _context.Add(input);
            _context.SaveChanges();
            return input;
        }
    }
}
