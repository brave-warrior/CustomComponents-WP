using Microsoft.Phone.Maps.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomComponents.Control
{
    public class CustomPushPinDependencies : DependencyObject
    {

        // View property
        public static readonly DependencyProperty ViewProperty =
            DependencyProperty.RegisterAttached("View", typeof(LocationRectangle), typeof(CustomPushPinDependencies),
            new PropertyMetadata(OnViewPropertyChanged));

        private static void OnViewPropertyChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            Map map = d as Map;
            LocationRectangle locationRectangle = e.NewValue as LocationRectangle;
            map.SetView(locationRectangle);
        }

        public static LocationRectangle GetView(DependencyObject obj)
        {
            return (LocationRectangle)obj.GetValue(ViewProperty);
        }

        public static void SetView(DependencyObject obj, LocationRectangle value)
        {
            obj.SetValue(ViewProperty, value);
        }

        // items source property
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.RegisterAttached("ItemsSource", typeof(List<MapLayer>), typeof(CustomPushPinDependencies),
            new PropertyMetadata(OnItemsSourcePropertyChanged));

        private static void OnItemsSourcePropertyChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            Map map = d as Map;
            var layers = e.NewValue as List<MapLayer>;
            foreach(MapLayer layer in layers)
            {
                map.Layers.Add(layer);
            }
        }

        public static List<MapLayer> GetItemsSource(DependencyObject obj)
        {
            return (List<MapLayer>)obj.GetValue(ItemsSourceProperty);
        }

        public static void SetItemsSource(DependencyObject obj, List<MapLayer> value)
        {
            obj.SetValue(ItemsSourceProperty, value);
        }

    }
}
