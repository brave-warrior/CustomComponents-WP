﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace CustomComponents.Data
{
    public class Hotel
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
