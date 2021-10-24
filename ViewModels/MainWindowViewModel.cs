using Prism.Commands;
using Prism.Mvvm;
using System;

namespace ParceDataWpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string tittle = "Data Parser";
        public string Title
        {
            get { return tittle; }
            set { SetProperty(ref tittle, value); }
        }

        public string PageTitle { get; set; }

        public DelegateCommand CloseAppCommand { get; private set; }
        public MainWindowViewModel()
        {
            CloseAppCommand = new DelegateCommand(CloseApp);
        }

        private void CloseApp()
        {
            Environment.Exit(0);
        }
    }
}
