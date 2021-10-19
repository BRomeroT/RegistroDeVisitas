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
        public MainPage()
        {
            InitializeComponent();
        }

        CV.TileView.Colors activeColor = CV.TileView.Colors.Blue;

        private void CollectionView_ChildAdded(object sender, ElementEventArgs e)
        {
            var tile = e.Element as CV.TileView;
            if (tile != null) tile.Color = activeColor;
            if (activeColor == CV.TileView.Colors.Violet) activeColor = CV.TileView.Colors.Blue;
            else activeColor++;
        }
    }
}
