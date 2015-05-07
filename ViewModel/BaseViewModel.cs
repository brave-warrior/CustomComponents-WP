using CustomComponents.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponents.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            DataProvider = DataGenerator.GenerateHotels();
        }

        protected INavigationService NavigationService { get; private set; }

        protected List<Hotel> DataProvider { get; private set; }
    }
}
