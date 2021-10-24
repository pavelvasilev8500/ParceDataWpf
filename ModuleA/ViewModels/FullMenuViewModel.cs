using Prism.Commands;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    class FullMenuViewModel
    {
        private IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public FullMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate("ContentRegion", uri);
        }
    }
}
