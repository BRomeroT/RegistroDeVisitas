using Core.Helpers;
using Core.Model;
using Sysne.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.BL
{
    internal class SeleccionesBL : ObservableObject
    {
        readonly IRepository repository;
        public SeleccionesBL(IRepository repository) =>
            this.repository = repository;

        public SeleccionesBL() => repository = new RepositorioDeVisitas();

        public List<Recepcionista> Recepcionistas { get => repository.GetRecepcionistas().OrderBy(r=>r.Nombre).ToList(); }

        public List<Calle> Calles { get => repository.GetCalles(); }

        public List<int> GetNumeros(string calleCodigo) => repository.GetNumeros(calleCodigo);

        public List<string> Letras { get => repository.GetLetras(); }

    }
}
