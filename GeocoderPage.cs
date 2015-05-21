using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps
{
    public class GeocoderPage : ContentPage
    {
        private readonly Geocoder _geoCoder;
        private readonly Label _l = new Label();

        public GeocoderPage()
        {
            this._geoCoder = new Geocoder();

            var b1 = new Button { Text = "Reverse geocode '37.808, -122.432'" };
            b1.Clicked += async (sender, e) =>
            {
                var fortMasonPosition = new Position(37.8044866, -122.4324132);
                var possibleAddresses = await this._geoCoder.GetAddressesForPositionAsync(fortMasonPosition);
                foreach (var a in possibleAddresses)
                {
                    this._l.Text += a + "\n";
                }
            };

            var b2 = new Button { Text = "Geocode '394 Pacific Ave'" };
            b2.Clicked += async (sender, e) =>
            {
                const string XamarinAddress = "394 Pacific Ave, San Francisco, California";
                var approximateLocation = await this._geoCoder.GetPositionsForAddressAsync(XamarinAddress);
                foreach (var p in approximateLocation)
                {
                    this._l.Text += p.Latitude + ", " + p.Longitude + "\n";
                }
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Children = 
                {
                    b2,
                    b1,
                    this._l
                }
            };
        }
    }
}