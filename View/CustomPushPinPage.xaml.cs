using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GalaSoft.MvvmLight.Ioc;
using CustomComponents.ViewModel;

namespace CustomComponents.View
{
    public partial class CustomPushPinPage : PhoneApplicationPage
    {
        public CustomPushPinPage()
        {
            InitializeComponent();

            DataContext = SimpleIoc.Default.GetInstance<CustomPushPinPage>();
        }
    }
}