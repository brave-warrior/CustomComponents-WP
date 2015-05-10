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
    public partial class BackgroundTaskPage : PhoneApplicationPage
    {
        public BackgroundTaskPage()
        {
            InitializeComponent();

            DataContext = SimpleIoc.Default.GetInstance<BackgroundTaskViewModel>();
        }
    }
}