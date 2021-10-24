using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.Generic;
using Prism.Mvvm;
using System.ComponentModel;
using ParseLibrary;

namespace ModuleA.ViewModels
{
    class FileDataViewModel : BindableBase
    {

        #region Data
        private string _path;
        private bool _canExecute = false;
        private BindingList<DataModel> _data = new BindingList<DataModel>();
        private List<string[]> _outData;
        private int _id = 0;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public BindingList<DataModel> Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        public string PATH
        {
            get { return _path; }
            set { SetProperty(ref _path, value); }
        }

        public bool CanExecute
        {
            get { return _canExecute; }
            set { SetProperty(ref _canExecute, value); }
        }
        #endregion

        #region Commands
        public DelegateCommand openFine { get; private set; }
        public DelegateCommand parseData { get; private set; }
        #endregion

        public FileDataViewModel()
        {
            #region Commands
            openFine = new DelegateCommand(OpenFile);
            parseData = new DelegateCommand(ParseData, CanExecuteMethod).ObservesProperty(() => CanExecute);
            #endregion
        }

        #region CommandMethods
        private bool CanExecuteMethod()
        {
            return CanExecute;
        }

        private void ParseData()
        {
            Data.Clear();
            Id = 0;
            ParseFileData parseFileData = new ParseFileData();
            _outData = parseFileData.SetData(PATH);
            DateTime now = DateTime.Now;
            foreach(var d in _outData)
            {
                string date = String.Format("{0:G}", now);
                Id++;
                Data.Add(new DataModel() { Date = date, ID = Id, Data = $"X: {d[0]} Y: {d[1]}" });
            }
        }

        private void OpenFile()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                PATH = dialog.FileName;
                CanExecute = true;
            }
        }
        #endregion

    }
}
