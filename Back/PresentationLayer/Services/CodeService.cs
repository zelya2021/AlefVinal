using BuissnesLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
    public class CodeService
    {
        private DataManager _dataManager;
        public CodeService(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }
        public List<Code> GetDirectoryesList()
        {
            var _dirs = _dataManager.Codes.GetAllDirectorys();
            List<Code> _modelsList = new List<Code>();
            foreach (var item in _dirs)
            {
                _modelsList.Add(CodeDBToViewModelById(item.Id));
            }
            return _modelsList;
        }

        public Code CodeDBToViewModelById(int codeId)
        {
            return  _dataManager.Codes.GetCodeById(codeId);
        }
    }
}
