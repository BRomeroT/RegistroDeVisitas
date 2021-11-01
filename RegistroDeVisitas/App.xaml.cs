using Core.Lib.OS;
using RegistroDeVisitas.OS;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistroDeVisitas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Sysne.Core.OS.DependencyService.Register<SettingsStorage, ISettingsStorage>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
