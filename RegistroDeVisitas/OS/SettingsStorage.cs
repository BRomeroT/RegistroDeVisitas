using Core.Lib.OS;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace RegistroDeVisitas.OS
{
    internal class SettingsStorage : ISettingsStorage
    {
        public T GetValue<T>([CallerMemberName] string propertyName = null) =>
            propertyName switch
            {
//#if DEBUG
//                "WebAPIUrl" => (T)(object)Preferences.Get(propertyName, "https://localhost:44347/"),
//#else
                "WebAPIUrl" => (T)(object)Preferences.Get(propertyName, "https://registrovisitaswebapi.azurewebsites.net/"),
//#endif
                //"IntSetting" => (T)(object)Preferences.Get(propertyName, 10),
                _ => default
            };

        public void SetValue<T>(T newValue = default, [CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case "WebAPIUrl":
                    Preferences.Set(propertyName, newValue.ToString());
                    break;
                //case "IntSetting":
                //Preferences.Set(propertyName, int.Parse(newValue.ToString());
                //break;
                default:
                    break;
            }
        }
    }
}
