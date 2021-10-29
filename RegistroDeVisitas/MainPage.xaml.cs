using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

        private void CallesCollectionView_ChildAdded(object sender, ElementEventArgs e)
        {
            var tile = e.Element as CV.TileView;
            if (tile != null) tile.Color = activeColor;
            if (activeColor == CV.TileView.Colors.Violet) activeColor = CV.TileView.Colors.Blue;
            else activeColor++;
        }

        private void SetSelectedLabel(object sender, ref Label seleccionadaLabel)
        {
            if (seleccionadaLabel != null)
            {
                seleccionadaLabel.FontAttributes = FontAttributes.None;
                seleccionadaLabel.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            }
            seleccionadaLabel = (sender as Label);
            seleccionadaLabel.FontAttributes = FontAttributes.Bold;
            seleccionadaLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
        }

        Label numeroSeleccionadoLabel = null;
        private void NumeroTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SetSelectedLabel(sender, ref numeroSeleccionadoLabel);
            //HACK: La burbuja de enlace con el contenedor (CollectionView) se detiene con este Gesture Recognizer
            viewModel.Numero = int.Parse(numeroSeleccionadoLabel.Text);
        }

        Label letraSeleccionadoLabel = null;
        private void LetraTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SetSelectedLabel(sender, ref letraSeleccionadoLabel);
            //HACK: La burbuja de enlace con el contenedor (CollectionView) se detiene con este Gesture Recognizer
            viewModel.Letra = letraSeleccionadoLabel.Text;
        }

        private async void TakePictureButton_Pressed(object sender, EventArgs e)
        {
            try
            {
                var foto = await MediaPicker.CapturePhotoAsync();
                using var stream = await foto.OpenReadAsync();
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);

                var base64 = Convert.ToBase64String(ms.ToArray());
                viewModel.Visita.Foto = base64; //$"data:image/jpg;base64,{base64}";
                fotoImage.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(base64)));
                if (File.Exists(foto.FullPath)) File.Delete(foto.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error al tomar foto", ex.Message, "Ok"); //"No se pudo tomar la fotografía, por favor inténtelo nuevamente", "Aceptar");
            }
        }
    }
}
