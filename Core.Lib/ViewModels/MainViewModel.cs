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
    public class MainViewModel : ViewModelWithBL<SeleccionesBL>
    {
        public MainViewModel() : base()
        {
            
        }

        private Recepcionista recepcionista;
        public Recepcionista Recepcionista { get => recepcionista; set => Set(ref recepcionista, value); }

        public List<Recepcionista> Recepcionistas => bl.Recepcionistas;

        private DateTime fechaHora;
        public DateTime FechaHora { get => fechaHora; set => Set(ref fechaHora, value); }
         
        private Calle calle;
        public Calle Calle
        {
            get => calle; set
            {
                Set(ref calle, value);
                RaisePropertyChanged(nameof(Numeros));
            }
        }
        public List<Calle> Calles => bl.Calles;


        private int numero;
        public int Numero { get => numero; set => Set(ref numero, value); }
        public List<int> Numeros => bl.GetNumeros(Calle?.Codigo);


        private string letra;
        public string Letra { get => letra; set => Set(ref letra, value); }
        public List<string> Letras => bl.Letras;
    }
}
