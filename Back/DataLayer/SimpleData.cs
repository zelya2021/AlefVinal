using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public static class SimpleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Codes.Any())
            {
                context.Codes.Add(new Entityes.Code() { Value = 145, Name="Код" });
                context.Codes.Add(new Entityes.Code() { Value = 783, Name = "Водафон" });
                context.SaveChanges();
            }
        }
    }
}
