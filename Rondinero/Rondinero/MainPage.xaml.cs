using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Rondinero
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Task.Run(async () => await CentrarMapa());
        }
        async Task CentrarMapa()
        {

            var myLocation = await Xamarin.Essentials.Geolocation.GetLocationAsync();
            var mapCenter = MapSpan.FromCenterAndRadius(
                new Position(myLocation.Latitude, myLocation.Longitude),
                Distance.FromKilometers(0.5));
            map.MoveToRegion(mapCenter);
        }
    }
}
