using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistroDeVisitas.CV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TileView : ContentView
    {
        public enum Colors
        {
            Blue, Green, Orange, Pink, Purple, Violet
        }
        public TileView()
        {
            InitializeComponent();
        }

        public Colors Color
        {
            get => (Colors)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Colors), typeof(TileView), Colors.Blue,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var me = (TileView)bindable;
            me.Color = (Colors)newValue;
            var imageName = me.Color switch
            {
                Colors.Green => "greenTile.png",
                Colors.Orange => "orangeTile.png",
                Colors.Pink => "pinkTile.png",
                Colors.Purple => "purpleTile.png",
                Colors.Violet => "violetTile.png",
                _ => "blueTile.png"
            };
            me.imageBackground.Source = new Helpers.ImageResourceExtension().GetImageSource(imageName);
        });

        public string Prefix
        {
            get => (string)GetValue(PrefixProperty);
            set => SetValue(PrefixProperty, value);
        }
        public static readonly BindableProperty PrefixProperty = BindableProperty.Create(nameof(Prefix), typeof(string), typeof(TileView), default(string),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var me = (TileView)bindable;
            me.Prefix = (string)newValue;
            me.prefixLabel.Text = me.Prefix;
        });

        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(TileView), default(string),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var me = (TileView)bindable;
            me.Name = (string)newValue;
            me.nameLabel.Text = me.Name;
        });

        public string Sufix
        {
            get => (string)GetValue(SufixProperty);
            set => SetValue(SufixProperty, value);
        }
        public static readonly BindableProperty SufixProperty = BindableProperty.Create(nameof(Sufix), typeof(string), typeof(TileView), default(string),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var me = (TileView)bindable;
            me.Sufix = (string)newValue;
            me.sufixLabel.Text = me.Sufix;
        });
    }
}