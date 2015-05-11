using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Device.Location;

namespace CustomComponents.Control
{
    public partial class CustomPushPin : UserControl
    {

        // events
        public event NavigateActionHandler NavigateAction;
        public delegate void NavigateActionHandler(CustomPushPin sender, EventArgs e);

        private bool _detailsVisible = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomPushPin()
        {
            InitializeComponent();
            this.Loaded += CustomPushPin_Loaded;
        }

        void CustomPushPin_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDetailsVisibility();
        }

        public GeoCoordinate Coordinates { get; set; }

        private string _details;
        public string Details
        {
            get { return _details; }
            set
            {
                _details = value;
                this.detailsTextBlock.Text = _details;
            }
        }

        /// <summary>
        /// Updates details visibility state
        /// </summary>
        private void UpdateDetailsVisibility()
        {
            // setting opacity simply changes background to visible,
            // however, while opacity is 0, control is not visible, but it
            // still can receive and handle all events
            // NOTE: Decide which type of visibility should be applied
            if(_detailsVisible)
            {
                this.contentDetails.Opacity = 1;
                this.contentDetails.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.contentDetails.Opacity = 0;
                this.contentDetails.Visibility = System.Windows.Visibility.Collapsed;
                
            }
        }

        /// <summary>
        /// Handles button Navigate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navigateBtn_Click(object sender, RoutedEventArgs e)
        {
            EventArgs args = new EventArgs();
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

    }

}
