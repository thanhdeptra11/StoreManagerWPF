using Microsoft.EntityFrameworkCore;
using QuanLiKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiKhoHang.BUS
{
    public class OutputAndOutputInfoBus
    {
        private readonly QuanLiKhoHangContext dbContext = new QuanLiKhoHangContext();

        public string GenerateIdOfOutput(DateTime outputDate)
        {
            string id = $"OUT-{GetRandomNumber(3)}-{outputDate.ToString("ddMMyyyy")}-";
            id += GetRandomNumber(2);
            while (true)
            {
                if (dbContext.Inputs.Any(input => input.Id.Equals(id)))
                {
                    id = "";
                    id = $"OUT-{GetRandomNumber(3)}-{outputDate.ToString("ddMMyyyy")}-";
                    id += GetRandomNumber(2);
                }
                else
                {
                    break;
                }
            }
            return id;
        }
        public string GenerateIdOfOutputInfo(string itemName, Output output)
        {
            string id = $"OUTINFO-{GetRandomNumber(3)}-{itemName}-";
            id += output.Id;
            while (true)
            {
                if (dbContext.OutputInfos.Any(output => output.Id.Equals(id)))
                {
                    id = "";
                    id = $"OUTINFO-{GetRandomNumber(3)}-{itemName}-";
                    id += output.Id;
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
        public Output CreateOutput(DateTime outputDate)
        {
            Output output = new Output()
            {
                Id = GenerateIdOfOutput(outputDate),
                DateOutput = outputDate
            };
            dbContext.Add(output);
            dbContext.SaveChanges();
            return output;
        }
    }
}
