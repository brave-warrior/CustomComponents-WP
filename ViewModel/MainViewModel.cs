﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    public class MainViewModel : ViewModelBase
    {
        // handlers
        public RelayCommand SearchViewCommand { get; private set; }
        public RelayCommand CustomPushPinCommand { get; private set; }
        public RelayCommand LiveTileWithUpdatesCommand { get; private set; }

        public MainViewModel()
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
            // TODO Handle showing search view
        }

        /// <summary>
        /// Handles custom push pin command
        /// </summary>
        private void HandleCustomPushPin()
        {
            // TODO Handle showing custom push pin on the map
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