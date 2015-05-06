using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponents.ViewModel
{
    /// <summary>
    /// Viewmodel for the Main page
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        // handlers
        public RelayCommand SearchViewCommand { get; private set; }
        public RelayCommand CustomPushPinCommand { get; private set; }
        public RelayCommand LiveTileWithUpdatesCommand { get; private set; }

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            // handlers
            SearchViewCommand = new RelayCommand(HandleSearchView);
            CustomPushPinCommand = new RelayCommand(HandleCustomPushPin);
            LiveTileWithUpdatesCommand = new RelayCommand(HandleLiveTileWithUpdates);
        }

        /// <summary>
        /// Handles search view command
        /// </summary>
        private void HandleSearchView()
        {
            NavigationService.NavigateTo(App.SEARCH_PAGE);
        }

        /// <summary>
        /// Handles custom push pin command
        /// </summary>
        private void HandleCustomPushPin()
        {
            NavigationService.NavigateTo(App.CUSTOM_PUSH_PIN_PAGE);
        }

        /// <summary>
        /// Handles showing live tile with updates
        /// </summary>
        private void HandleLiveTileWithUpdates()
        {
            // TODO Handle 
        }
    }
}
