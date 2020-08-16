using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
   public interface ICodesRepository
    {
        IEnumerable<Code> GetAllCodes();
        Code GetCodeById(int codeId);
        void SaveCode(Code achieve);
    }
}
