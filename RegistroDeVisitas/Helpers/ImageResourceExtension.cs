using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistroDeVisitas.Helpers
{
    /// <summary>
    /// Load Image embedded
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/images?tabs=windows#embedded-images"/>
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Source switch
            {
                null => null,
                _ => GetImageSource(Source)
            };
        }
        public ImageSource GetImageSource(string name) =>
            ImageSource.FromResource($"RegistroDeVisitas.Images.{name}", typeof(ImageResourceExtension).GetTypeInfo().Assembly);
    }
}
