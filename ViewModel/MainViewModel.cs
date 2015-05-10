using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Phone.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public RelayCommand BackgroundTaskCommand { get; private set; }

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            // handlers
            SearchViewCommand = new RelayCommand(HandleSearchView);
            CustomPushPinCommand = new RelayCommand(HandleCustomPushPin);
            BackgroundTaskCommand = new RelayCommand(HandleBackgroundTaskCommand);
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
        /// Handles Background task command
        /// </summary>
        private void HandleBackgroundTaskCommand()
        {
            NavigationService.NavigateTo(App.BACKGROUND_TASK_PAGE);
        }

    }
}
