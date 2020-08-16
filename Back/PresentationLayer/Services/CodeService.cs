using BuissnesLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
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
        public List<CodeViewModel> GetDirectoryesList()
        {
            var _dirs = _dataManager.Codes.GetAllCodes();
            List<CodeViewModel> _modelsList = new List<CodeViewModel>();
            foreach (var item in _dirs)
            {
                _modelsList.Add(CodeDBToViewModelById(item.Id));
            }
            return _modelsList;
        }

        public CodeViewModel CodeDBToViewModelById(int directoryId)
        {
            var _code = _dataManager.Codes.GetCodeById(directoryId);
            return new CodeViewModel() { Code = _code };
        }
        public CodeEditModel GetCodeEditModel(int codeId = 0)
        {
            if (codeId != 0)
            {
                var _codeDB = _dataManager.Codes.GetCodeById(codeId);
                var _codeEditModel = new CodeEditModel()
                {
                    Id = _codeDB.Id,
                    Title = _codeDB.Title,
                    Html = _codeDB.Html
                };
                return _codeEditModel;
            }
            else { return new CodeEditModel() { }; }
        }
        public CodeViewModel SaveCodeEditModelToDb(CodeEditModel codeEditModel)
        {
            Code _codeDbModel;
            if (codeEditModel.Id != 0)
            {
                _codeDbModel = _dataManager.Codes.GetCodeById(codeEditModel.Id);
            }
            else
            {
                _codeDbModel = new Code();
            }
            _codeDbModel.Title = codeEditModel.Title;
            _codeDbModel.Html = codeEditModel.Html;

            _dataManager.Codes.SaveCode(_codeDbModel);

            return CodeDBToViewModelById(_codeDbModel.Id);
        }
    }
}
