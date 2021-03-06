﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CustomComponents.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace CustomComponents.View
{
    public partial class SearchPage : PhoneApplicationPage
    {
        public SearchPage()
        {
            InitializeComponent();
            DataContext = SimpleIoc.Default.GetInstance<SearchViewModel>();
        }
    }
}