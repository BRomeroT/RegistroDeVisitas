using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms.Platform.UWP;

namespace RegistroDeVisitas.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var app = new RegistroDeVisitas.App();
            LoadApplication(app);

            //// https://startdebugging.net/2018/01/using-acrylic-brush-xamarin-forms-masterdetail/
            var mainPage = (app.MainPage as RegistroDeVisitas.MainPage);
            var render = Platform.GetRenderer(mainPage) as PageRenderer;
            //var acrylicBrush = new Windows.UI.Xaml.Media.AcrylicBrush();
            //acrylicBrush.BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;
            var acrylicBrush = Application.Current.Resources["AcrylicBackgroundFillColorDefaultBrush"] as AcrylicBrush;
            render.Background = acrylicBrush;
            
            //BackdropMaterial.SetApplyToRootOrPageBackground(this, true);
        }
    }
}
