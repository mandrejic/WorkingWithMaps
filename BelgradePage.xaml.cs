using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace WorkingWithMaps
{
    using Xamarin.Forms.Maps;

    public partial class BelgradePage : ContentPage
    {
        public BelgradePage()
        {
            InitializeComponent();

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(44.78, 20.44), Distance.FromMiles(1)));
        }
    }
}
