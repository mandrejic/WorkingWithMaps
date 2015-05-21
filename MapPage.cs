using System;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps
{
    public class MapPage : ContentPage
    {
        private readonly Map _map;

        public MapPage()
        {
            this._map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // You can use MapSpan.FromCenterAndRadius 
            // map.MoveToRegion (MapSpan.FromCenterAndRadius (
            // new Position (37, -122), Distance.FromMiles (0.3)));
            // or create a new MapSpan object directly
            this._map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));

            // add the slider
            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) =>
            {
                var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                Debug.WriteLine(zoomLevel + " -> " + latlongdegrees);
                if (this._map.VisibleRegion != null)
                {
                    this._map.MoveToRegion(new MapSpan(this._map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
                }
            };


            // create map style buttons
            var street = new Button { Text = "Street" };
            var hybrid = new Button { Text = "Hybrid" };
            var satellite = new Button { Text = "Satellite" };
            street.Clicked += HandleClicked;
            hybrid.Clicked += HandleClicked;
            satellite.Clicked += HandleClicked;

            var segments = new StackLayout
            {
                Spacing = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { street, hybrid, satellite }
            };


            // put the page together
            var stack = new StackLayout
            {
                Spacing = 0,
                Children =
                {
                    _map,
                    slider,
                    segments
                }
            };
            Content = stack;
        }

        private void HandleClicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            switch (b.Text)
            {
                case "Street":
                    this._map.MapType = MapType.Street;
                    break;
                case "Hybrid":
                    this._map.MapType = MapType.Hybrid;
                    break;
                case "Satellite":
                    this._map.MapType = MapType.Satellite;
                    break;
            }
        }

    }
}
