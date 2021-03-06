using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using Core.BL;
using Core.Model;
using Sysne.Core.MVVM;
using Sysne.Core.MVVM.Patterns;

namespace Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly SeleccionesBL seleccionesBL = new();
        private readonly RegistroBL registroBL = new();
        private readonly SesionesBL sesionesBL = new();

        public MainViewModel()
        {
            PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(Recepcionista):
                    case nameof(Calle):
                    case nameof(Numero):
                    case nameof(Letra):
                        RaisePropertyChanged(nameof(EsDestinoValido));
                        break;
                    default:
                        break;
                }
            };
        }

        #region Selectores
        private Recepcionista recepcionista;
        public Recepcionista Recepcionista { get => recepcionista; set => Set(ref recepcionista, value); }

        private Calle calle;
        public Calle Calle
        {
            get => calle; set
            {
                Set(ref calle, value);
                Numero = 0;
                RaisePropertyChanged(nameof(Numeros));
            }
        }
        public List<Calle> Calles => seleccionesBL.Calles;

        private int numero;
        public int Numero
        {
            get => numero;
            set
            {
                Set(ref numero, value);
                Letra = String.Empty;
            }
        }
        public List<int> Numeros => seleccionesBL.GetNumeros(Calle?.Codigo);

        private string letra;
        public string Letra { get => letra; set => Set(ref letra, value); }
        public List<string> Letras => seleccionesBL.Letras;

        private string fotoPreview;
        public string FotoPreview { get => fotoPreview; set => Set(ref fotoPreview, value); }

        private bool fotoPreviewVisible;
        public bool FotoPreviewVisible { get => fotoPreviewVisible; set => Set(ref fotoPreviewVisible, value); }

        private DateTime fechaInicialFiltro = DateTime.Now;
        public DateTime FechaInicialFiltro { get => fechaInicialFiltro; set => Set(ref fechaInicialFiltro, value); }
        #endregion

        #region Registro
        public bool EsDestinoValido { get => Recepcionista != null && Calle != null && Numero > 0 && !string.IsNullOrEmpty(Letra); }

        private Visita visita = new();
        public Visita Visita { get => visita; set => Set(ref visita, value); }

        private bool registroExitoso;
        public bool RegistroExitoso { get => registroExitoso; set => Set(ref registroExitoso, value); }

        RelayCommand registrarCommand = null;
        public RelayCommand RegistrarCommand
        {
            get => registrarCommand ??= new RelayCommand(async () =>
            {
                Processing = true;
                Visita.CasaCodigo = $"{Calle.Codigo}{Numero:00}{Letra}";
                Visita.Entrada = DateTime.Now;
                Visita.Recepcionista = Recepcionista.Nombre;
                //Para que de la "sensación" de que se registró rápido
                visitasActivas.Add(Visita);
                var visitaRegistrada = Visita;
                Processing = false;
                await registroBL.RegistrarVisita(visitaRegistrada);
                Visita = new();
                //RegistroExitoso = await registroBL.RegistrarVisita(Visita);
                //if (RegistroExitoso)
                //{
                //    visitasActivas.Add(Visita);
                //    Visita = new();
                //}
            }, () => true);
        }
        #endregion

        #region Salidas

        private ObservableCollection<Visita> visitasActivas = new();
        public ObservableCollection<Visita> VisitasActivas { get => visitasActivas; set => Set(ref visitasActivas, value); }

        private IEnumerable<Visita> visitasBuscadas;
        public IEnumerable<Visita> VisitasBuscadas { get => visitasBuscadas; set => Set(ref visitasBuscadas, value); }

        private bool salidaExitosa;
        public bool SalidaExitosa { get => salidaExitosa; set => Set(ref salidaExitosa, value); }

        RelayCommand actualizarVisitasActivasCommand = null;
        public RelayCommand ActualizarVisitasActivasCommand
        {
            get => actualizarVisitasActivasCommand ??= new(async () =>
           {
               Processing = true;
               VisitasActivas = new(await registroBL.VisitaActivas());
               Processing = false;
           }, () => true);
        }

        RelayCommand<Visita> salidaCommand = null;
        public RelayCommand<Visita> SalidaCommand
        {
            get => salidaCommand ??= new(async (Visita visita) =>
           {
               Processing = true;
               visita.Salida = DateTime.Now;
               visita.RecepcionistaSalida = Recepcionista.Nombre;
               SalidaExitosa = await registroBL.RegistrarSalida(visita);
               if (SalidaExitosa) VisitasActivas.Remove(visita);
               Processing = false;
           }, (Visita visita) => true);
        }

        RelayCommand<string> verFotoPreviewCommand = null;
        public RelayCommand<string> VerFotoPreviewCommand
        {
            get => verFotoPreviewCommand ??= new((string base64) =>
           {
               FotoPreview = base64;
               FotoPreviewVisible = true;
           }, (string base64) => true);
        }

        RelayCommand ocultarFotoPreviewCommand = null;
        public RelayCommand OcultarFotoPreviewCommand
        {
            get => ocultarFotoPreviewCommand ??= new(() =>
           {
               FotoPreview = string.Empty;
               FotoPreviewVisible = false;
           }, () => true);
        }

        RelayCommand<DateTime?> buscarDelDiaCommand = null;
        public RelayCommand<DateTime?> BuscarDelDiaCommand
        {
            get => buscarDelDiaCommand ??= new(async (DateTime? fecha) =>
           {
               Processing = true;
               if (fecha == null) fecha = FechaInicialFiltro;
               VisitasBuscadas = await registroBL.VisitasDelDia(fecha);
               Processing = false;
           }, (DateTime? fecha) => true);
        }

        #endregion

        #region Sesiones

        private DateTime fechaSesiones = DateTime.Now;
        public DateTime FechaSesiones { get => fechaSesiones; set => Set(ref fechaSesiones, value); }


        private IEnumerable<Sesion> sesionesEncontradas;
        public IEnumerable<Sesion> SesionesEncontradas { get => sesionesEncontradas; set => Set(ref sesionesEncontradas, value); }

        RelayCommand buscarSesionesCommand = null;
        public RelayCommand BuscarSesionesCommand
        {
            get => buscarSesionesCommand ??= new (async () =>
            {
                Processing= true;
                SesionesEncontradas = await sesionesBL.GetSesionsDe(FechaSesiones.Year,FechaSesiones.Month);
                Processing = false;
            }, () => true);
        }

        #endregion
    }
}
