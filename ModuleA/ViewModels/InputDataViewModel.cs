using Prism.Commands;
using Prism.Mvvm;
using ParseLibrary;
using System.ComponentModel;
using System;
using Prism.Events;

namespace ModuleA.ViewModels
{
    class InputDataViewModel : BindableBase
    {

        #region Data
        private BindingList<DataModel> _data = new BindingList<DataModel>();
        private int _id = 0;
        private string _inputText = "Input your data";
        private bool _canExecute = false;
        private string[] _outData;
        private string _outText = "";

        public string OutText
        {
            get { return _outText; }
            set { SetProperty(ref _outText, value); }
        }

        public BindingList<DataModel> Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string InputText
        {
            get { return _inputText; }
            set { SetProperty(ref _inputText, value); }
        }

        public bool CanExecute
        {
            get { return _canExecute; }
            set { SetProperty(ref _canExecute, value); }
        }
        #endregion

        #region Commands
        public DelegateCommand parseData { get; private set; }
        public DelegateCommand gotFocus { get; private set; }
        public DelegateCommand lostFocus { get; private set; }

        private IEventAggregator _eventAggregator;
        #endregion

        public InputDataViewModel()
        {
            #region Commands
            parseData = new DelegateCommand(ParseData);
            gotFocus = new DelegateCommand(GotFocus);
            lostFocus = new DelegateCommand(LostFocus);
            #endregion
        }

        #region CommandsMethods

        #region PlaceHolderCommands
        private void LostFocus()
        {
            OutText = InputText;
            InputText = "Input your data";
        }

        private void GotFocus()
        {
            InputText = "";
        }
        #endregion

        private bool CanExecuteMethod()
        {
            return CanExecute;
        }

        private void ParseData()
        {
            ParseInputData parseInputData = new ParseInputData(OutText);
            _outData = parseInputData.GetData();
            if (_outData.Length == 1)
            {
                InputText = $"{_outData[0].ToString()}";
            }
            else if (_outData != null & _outData.Length != 1)
            {
                DateTime now = DateTime.Now;
                string date = String.Format("{0:G}", now);
                Id++;
                Data.Add(new DataModel() { Date = date, ID = Id, Data = $"X: {_outData[0]} Y: {_outData[1]}" });
                OutText = "";
            }
        }
        #endregion

    }
}
