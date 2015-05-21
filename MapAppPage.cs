using System;
using Xamarin.Forms;

namespace WorkingWithMaps
{
    public class MapAppPage : ContentPage
    {
        // WARNING: when adding latitude/longitude values be careful of localization.
        // European (and other countries) use a comma as the separator, which will break the request

        public MapAppPage()
        {
            var l = new Label
            {
                Text = "These buttons leave the current app and open the built-in Maps app for the platform"
            };

            var openLocation = new Button
            {
                Text = "Open location using built-in Maps app"
            };

            var baseUri = string.Empty;

            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    baseUri = "http://maps.apple.com/";
                    break;
                case TargetPlatform.Android:
                    baseUri = "geo:0,0";
                    break;
                case TargetPlatform.WinPhone:
                    baseUri = "bingmaps:";
                    break;
            }

            openLocation.Clicked += (sender, e) => Device.OpenUri(new Uri(baseUri + "?q=394+Pacific+Ave+San+Francisco+CA"));

            var openDirections = new Button
            {
                Text = "Get directions using built-in Maps app"
            };

            openDirections.Clicked += (sender, e) => Device.OpenUri(new Uri(baseUri + "?daddr=San+Francisco,+CA&saddr=cupertino"));

            Content = new StackLayout
            {
                Padding = new Thickness(5, 20, 5, 0),
                HorizontalOptions = LayoutOptions.Fill,
                Children = 
                {
                    l,
                    openLocation,
                    openDirections
                }
            };
        }
    }
}