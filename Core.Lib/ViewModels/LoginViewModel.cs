using Core.BL;
using Core.Lib.OS;
using Core.Model;
using Sysne.Core.MVVM;
using Sysne.Core.MVVM.Patterns;
using Sysne.Core.OS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class LoginViewModel : ViewModelWithBL<SesionesBL>
    {
        public LoginViewModel() : base()
        {
            //CargarRecepcionistasCommand.Execute(null);
        }

        private bool esValido;
        public bool EsValido { get => esValido; set => Set(ref esValido, value); }
        private Recepcionista recepcionista;
        public Recepcionista Recepcionista { get => recepcionista; set => Set(ref recepcionista, value); }

        private List<Recepcionista> recepcionistas;
        public List<Recepcionista> Recepcionistas { get => recepcionistas; set => Set(ref recepcionistas, value); }

        private string codigo;
        [Required]
        public string Codigo { get => codigo; set => Set(ref codigo, value); }

        RelayCommand autentificarCommand = null;
        public RelayCommand AutentificarCommand
        {
            get => autentificarCommand ??= new(async () =>
           {
               EsValido = await bl.Iniciar(Recepcionista.Id, Codigo);
           }, () => Validate(this, false)
            , dependencies: (this, new[] { nameof(Codigo) }));
        }


        RelayCommand cargarRecepcionistasCommand = null;
        public RelayCommand CargarRecepcionistasCommand
        {
            get => cargarRecepcionistasCommand ??= new RelayCommand(async () =>
            {
                Recepcionistas = new(await bl.Recepcionistas());
                Recepcionista = Recepcionistas.FirstOrDefault();
            }, () => true);
        }
    }
}