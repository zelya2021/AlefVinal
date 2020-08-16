using BuissnesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer
{
    public class DataManager
    {
        private ICodesRepository _codesRepository;

        public DataManager(ICodesRepository codesRepository)
        {
            _codesRepository = codesRepository;
        }

        public ICodesRepository Codes { get { return _codesRepository; } }
    }
}
