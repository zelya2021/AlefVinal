using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implementations
{
    public class EFCodesRepository : ICodesRepository
    {
        private EFDBContext context;
        public EFCodesRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Code> GetAllCodes()
        {
            return context.Codes.ToList();
        }

        public Code GetCodeById(int codeId)
        {
            return context.Codes.FirstOrDefault(x => x.Id == codeId);
        }

        public void SaveCode(Code code)
        {
            if (code.Id == 0)
                context.Codes.Add(code);
            else
                context.Entry(code).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
