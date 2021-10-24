using Prism.Mvvm;

namespace Dialog.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private string _title = "Dialog";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
