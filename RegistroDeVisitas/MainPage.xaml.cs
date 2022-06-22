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

            viewModel.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(viewModel.RegistroExitoso):
                        if (viewModel.Processing && !viewModel.RegistroExitoso)
                            DisplayAlert("Erro de registro", "No se pudo registrar la entrada, favor de intentar nuevamente", "Aceptar");
                        break;
                    default:
                        break;
                }
            };

            viewModelLogin.PropertyChanged += (s, e) =>
              {
                  switch (e.PropertyName)
                  {
                      case nameof(viewModelLogin.EsValido):
                          if (!viewModelLogin.EsValido)
                              DisplayAlert("⛔ Acceso negado", "🔑 Código inválido", "Reintentar");
                          else
                              viewModel.Recepcionista = viewModelLogin.Recepcionista;
                          break;
                      default:
                          break;
                  }
              };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModelLogin.CargarRecepcionistasCommand.ExecuteAsync();
            await viewModel.ActualizarVisitasActivasCommand.ExecuteAsync();
        }

        ~MainPage() => timer.Stop();

        CV.TileView.Colors activeColor = CV.TileView.Colors.Blue;

        private void CallesCollectionView_ChildAdded(object sender, ElementEventArgs e)
        {
            if (e.Element is CV.TileView tile) tile.Color = activeColor;
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
                if (foto == null) return;
                using var stream = await foto.OpenReadAsync();
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);

                var base64 = Convert.ToBase64String(ms.ToArray());
                viewModel.Visita.Foto = base64;
                if (File.Exists(foto.FullPath)) File.Delete(foto.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error al tomar foto", ex.Message, "Ok"); //"No se pudo tomar la fotografía, por favor inténtelo nuevamente", "Aceptar");
            }
        }

        private void TabImageButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var parent = (button.Parent as StackLayout);
            foreach (var options in parent.Children)
                options.Style = null;
            button.Style = parent.Resources["Selected"] as Style;
            switch (button.CommandParameter.ToString())
            {
                case "registro":
                    registroGrid.IsVisible = true;
                    salidaGrid.IsVisible = false;
                    historialGrid.IsVisible = false;
                    sesionesGrid.IsVisible = false;
                    break;
                case "salida":
                    registroGrid.IsVisible = false;
                    salidaGrid.IsVisible = true;
                    historialGrid.IsVisible = false;
                    sesionesGrid.IsVisible = false;
                    break;
                case "historial":
                    registroGrid.IsVisible = false;
                    salidaGrid.IsVisible = false;
                    historialGrid.IsVisible = true;
                    sesionesGrid.IsVisible = false;
                    break;
                case "sesiones":
                    registroGrid.IsVisible = false;
                    salidaGrid.IsVisible = false;
                    historialGrid.IsVisible = false;
                    sesionesGrid.IsVisible = true;
                    break;
                default: break;
            }
        }
    }
}
