using System;
using System.Collections.Generic;
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

        private Recepcionista recepcionista;
        public Recepcionista Recepcionista { get => recepcionista; set => Set(ref recepcionista, value); }

        public List<Recepcionista> Recepcionistas => seleccionesBL.Recepcionistas;

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
                RegistroExitoso = await registroBL.RegistrarVisita(Visita);
                if (RegistroExitoso) Visita = new();
                Processing = false;
            }, () => true);
        }
    }
}
