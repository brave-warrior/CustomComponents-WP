using CustomComponents.Control;
using CustomComponents.Data;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Phone.Maps.Controls;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomComponents.ViewModel
{
    /// <summary>
    /// Viewmodel for the custom push pin page
    /// </summary>
    public class CustomPushPinViewModel : BaseViewModel
    {
        // handlers
        public RelayCommand PageLoaded { get; private set; }

        public CustomPushPinViewModel(INavigationService navigationService) : base(navigationService)
        {

            // handlers
            PageLoaded = new RelayCommand(HandlePageLoaded);
        }

        /// <summary>
        /// Handles event PageLoaded
        /// </summary>
        private void HandlePageLoaded()
        {
            var layers = new List<MapLayer>();
            var coordinates = new List<GeoCoordinate>();

            foreach(Hotel hotel in DataProvider)
            {
                MapOverlay overlay = new MapOverlay();
                overlay.Content = GeneratePushPin(hotel);
                var coordinate = new GeoCoordinate(hotel.Lat, hotel.Lon);
                overlay.GeoCoordinate = coordinate;
                overlay.PositionOrigin = new Point(0.5, 1);

                MapLayer mapLayer = new MapLayer();
                mapLayer.Add(overlay);
                layers.Add(mapLayer);

                coordinates.Add(coordinate);
            }

            MapView = LocationRectangle.CreateBoundingRectangle(coordinates);
            Locations = layers;
        }

        /// <summary>
        /// Generates push pin
        /// </summary>
        /// <param name="relatedHotel">Related hotel</param>
        /// <returns>Pusp pin control</returns>
        private CustomPushPin GeneratePushPin(Hotel relatedHotel)
        {
            var pushPin = new CustomPushPin();
            pushPin.Coordinates = new GeoCoordinate(relatedHotel.Lat, relatedHotel.Lon);
            pushPin.Details = string.Format("{0}\n{1}, {2}", relatedHotel.Name, relatedHotel.Street, relatedHotel.City);
            pushPin.NavigateAction += pushPin_NavigateAction;
            return pushPin;
        }

        /// <summary>
        /// Called when pressed action navigate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pushPin_NavigateAction(CustomPushPin sender, EventArgs e)
        {
            GeoCoordinate coordinates = sender.Coordinates;
            
            if(coordinates != null && !string.IsNullOrEmpty(sender.Details))
            {
                StartDirections(coordinates.Latitude, coordinates.Longitude, sender.Details);
            }
            
        }

        /// <summary>
        /// Starts direction task
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="name"></param>
        private async void StartDirections(double latitude, double longitude, string name)
        {
            // Assemble the Uri to launch.
            Uri uri = new Uri("ms-drive-to:?destination.latitude=" + latitude +
                "&destination.longitude=" + longitude + "&destination.name=" + name);

            // Launch the Uri.
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
            if (success)
            {
                // Uri launched.
            }
            else
            {
                // Uri failed to launch.
            }
        }

        /// <summary>
        /// Map view
        /// </summary>
        private LocationRectangle _mapView;
        public LocationRectangle MapView
        {
            get { return _mapView; }
            set { this.Set<LocationRectangle>(ref _mapView, value); }
        }

        /// <summary>
        /// Location items on the map
        /// </summary>
        private List<MapLayer> _locations;
        public List<MapLayer> Locations
        {
            get { return _locations; }
            set { this.Set<List<MapLayer>>(ref _locations, value); }
        }
    }
}
