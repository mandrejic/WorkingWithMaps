using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps
{
    public class PinPage : ContentPage
    {
        private readonly Map _map;

        public PinPage()
        {
            this._map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            this._map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(36.9628066, -122.0194722), Distance.FromMiles(3))); // Santa Cruz golf course

            var position = new Position(36.9628066, -122.0194722); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Santa Cruz",
                Address = "custom detail info"
            };
            this._map.Pins.Add(pin);


            // create buttons
            var morePins = new Button { Text = "Add more pins" };
            morePins.Clicked += (sender, e) =>
            {
                this._map.Pins.Add(new Pin
                {
                    Position = new Position(36.9641949, -122.0177232),
                    Label = "Boardwalk"
                });
                this._map.Pins.Add(new Pin
                {
                    Position = new Position(36.9571571, -122.0173544),
                    Label = "Wharf"
                });
                this._map.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(36.9628066, -122.0194722), Distance.FromMiles(1.5)));

            };

            var relocate = new Button { Text = "Re-center" };
            relocate.Clicked += (sender, e) => this._map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(36.9628066, -122.0194722), Distance.FromMiles(3)));

            var buttons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = 
                {
                    morePins, relocate
                }
            };

            // put the page together
            Content = new StackLayout
            {
                Spacing = 0,
                Children = 
                {
                    this._map,
                    buttons
                }
            };
        }
    }
}