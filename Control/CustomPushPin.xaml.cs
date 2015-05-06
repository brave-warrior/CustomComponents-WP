using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CustomComponents.Control
{
    public partial class CustomPushPin : UserControl
    {
        public Data.Hotel Place { get; private set; }

        public event NavigateActionHandler NavigateAction;
        public delegate void NavigateActionHandler(CustomPushPin customPushPin, NavigateEventArgs e);

        private bool _detailsVisible = false;

        public CustomPushPin(Data.Hotel place)
        {
            InitializeComponent();

            Place = place;
            UpdateDetails();
            UpdateDetailsVisibility();
        }

        /// <summary>
        /// Updates details visibility state
        /// </summary>
        private void UpdateDetailsVisibility()
        {
            if(_detailsVisible)
            {
                this.contentDetails.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.contentDetails.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Formats details
        /// </summary>
        /// <returns></returns>
        private string FormatDetails()
        {
            string address = string.Format("{0}\n{1}, {2}", Place.Name, Place.Street, Place.City);
            return address;
        }

        /// <summary>
        /// Updates details for showing
        /// </summary>
        private void UpdateDetails()
        {
            this.detailsTextBlock.Text = FormatDetails();
        }

        /// <summary>
        /// Handles button Navigate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navigateBtn_Click(object sender, RoutedEventArgs e)
        {
            // format details data
            string address = FormatDetails();

            // raising new event
            NavigateEventArgs args = new NavigateEventArgs(Place.Lat, Place.Lon, address);
            NavigateAction(this, args);
        }

        /// <summary>
        /// Handles click on PuspPin picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pushpin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            _detailsVisible = !_detailsVisible;
            UpdateDetailsVisibility();
        }

        /// <summary>
        /// Defines arguments for the event Navigate
        /// </summary>
        public class NavigateEventArgs : EventArgs
        {
            public NavigateEventArgs(double latitude, double longitude, string address)
            {
                Latitude = latitude;
                Longitude = longitude;
                Address = address;
            }

            public double Latitude { get; private set; }
            public double Longitude { get; private set; }
            public string Address { get; private set; }
        }
    }

}
