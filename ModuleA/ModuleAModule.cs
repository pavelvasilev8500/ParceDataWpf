using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {

        private readonly IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegion contentregion = _regionManager.Regions["ContentRegion"];
            IRegion menuregion = _regionManager.Regions["MenuRegion"];

            var inputDataView = containerProvider.Resolve<MenuView>();
            contentregion.Add(inputDataView);

            var menu = containerProvider.Resolve<FullMenuView>();
            menuregion.Add(menu);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<InputDataView>();
            containerRegistry.RegisterForNavigation<FileDataView>();
            containerRegistry.RegisterForNavigation<MenuView>();
        }
    }
}