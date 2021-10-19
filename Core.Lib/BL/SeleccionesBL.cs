using Core.Helpers;
using Core.Model;
using Sysne.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BL
{
    public class SeleccionesBL : ObservableObject
    {
        readonly IRepository repository;
        public SeleccionesBL(IRepository repository) =>
            this.repository = repository;

        public SeleccionesBL() => repository = new RepositorioDeVisitas();

        public List<Recepcionista> Recepcionistas { get => repository.GetRecepcionistas(); }

        public List<Calle> Calles { get => repository.GetCalles(); }

        public List<int> GetNumeros(string calleCodigo = null) => repository.GetNumeros(calleCodigo);

        public List<string> Letras { get => repository.GetLetras(); }

    }
}
