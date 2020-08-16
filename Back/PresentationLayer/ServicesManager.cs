using BuissnesLayer;
using PresentationLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class ServicesManager
    {
        DataManager _dataManager;
        private CodeService _codeService;

        public ServicesManager(
            DataManager dataManager
            )
        {
            _dataManager = dataManager;
            _codeService = new CodeService(_dataManager);
        }
        public CodeService Codes { get { return _codeService; } }

    }
}
