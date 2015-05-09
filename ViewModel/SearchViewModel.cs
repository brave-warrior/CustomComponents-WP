using CustomComponents.Data;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace CustomComponents.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        // Inputted user text for search
        public string SearchText { get; private set; }

        /// <summary>
        /// Defines the collection of the views for sorting
        /// </summary>
        private CollectionViewSource _collectionViewSource;

        // handlers
        public RelayCommand<object> InputCommand { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchViewModel(INavigationService navigationService) : base(navigationService)
        {
            IsNoData = false;
            FilteredHotels = new ObservableCollection<Hotel>();

            // load source data
            IEnumerable<Hotel> newData = DataGenerator.GenerateHotels();
            ObservableCollection<Hotel> sourceItems = new ObservableCollection<Hotel>(newData);

            _collectionViewSource = new CollectionViewSource();
            _collectionViewSource.Filter += HandleFilterEvent;
            _collectionViewSource.Source = sourceItems;

            // handlers
            InputCommand = new RelayCommand<object>(HandleSearchInput);
        }

        /// <summary>
        /// Handles search input
        /// </summary>
        /// <param name="args"></param>
        private void HandleSearchInput(object args)
        {
            SearchText = ((TextBox)args).Text;

            _collectionViewSource.View.Refresh();
        }

        /// <summary>
        /// Handles filter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleFilterEvent(object sender, FilterEventArgs e)
        {
            // do not search if nothing inputted
            if (!string.IsNullOrEmpty(SearchText))
            {
                Hotel hotel = e.Item as Hotel;
                if (hotel != null)
                {
                    SearchText = SearchText.ToUpper();
                    bool textMatched = hotel.Name.ToUpper().Contains(SearchText);
                    textMatched |= hotel.City.ToUpper().Contains(SearchText);
                    textMatched |= hotel.Street.ToUpper().Contains(SearchText);
                    if (textMatched)
                    {
                        e.Accepted = true;

                        if (!FilteredHotels.Contains(hotel))
                        {
                            FilteredHotels.Add(hotel);
                        }
                    }
                    else
                    {
                        e.Accepted = false;
                        FilteredHotels.Remove(hotel);
                    }
                    IsNoData = FilteredHotels.Count == 0;
                }
            }
            else
            {
                IsNoData = false;
                FilteredHotels.Clear();
            }
        }

        /// <summary>
        /// Defines the collection of filtered items
        /// </summary>
        private ObservableCollection<Hotel> _filteredHotels;
        public ObservableCollection<Hotel> FilteredHotels
        {
            get { return _filteredHotels; }
            set { this.Set<ObservableCollection<Hotel>>(ref _filteredHotels, value); }
        }

        /// Defines whether data exists or not
        /// </summary>
        private bool _isNoData;
        public bool IsNoData
        {
            get { return _isNoData; }
            set { this.Set<bool>(ref _isNoData, value); }
        }
    }
}
