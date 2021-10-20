using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RegistroDeVisitas
{
    public partial class MainPage : ContentPage
    {
        private readonly System.Timers.Timer timer;

        public MainPage()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(30000);
            void ShowDateTime() => time.Text = $"{DateTime.Now:D} {Environment.NewLine} {DateTime.Now:t}";
            ShowDateTime();
            timer.AutoReset = true;
            timer.Elapsed += (s, e) =>
                Dispatcher.BeginInvokeOnMainThread(() => ShowDateTime());
            timer.Start();
        }

        ~MainPage() => timer.Stop();

        CV.TileView.Colors activeColor = CV.TileView.Colors.Blue;

        private void CollectionView_ChildAdded(object sender, ElementEventArgs e)
        {
            var tile = e.Element as CV.TileView;
            if (tile != null) tile.Color = activeColor;
            if (activeColor == CV.TileView.Colors.Violet) activeColor = CV.TileView.Colors.Blue;
            else activeColor++;
            (sender as CollectionView).HeightRequest = tile.Height;
        }
    }
}
