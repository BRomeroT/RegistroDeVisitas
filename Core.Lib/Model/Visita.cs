using Sysne.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public partial class Visita : ObservableObject
    {

        private Guid id = Guid.NewGuid();
        public Guid Id { get => id; set => Set(ref id, value); }

        private string recepcionista;
        public string Recepcionista { get => recepcionista; set => Set(ref recepcionista, value); }

        private string casaCodigo;
        public string CasaCodigo { get => casaCodigo; set => Set(ref casaCodigo, value); }

        private string numeroDePase;
        public string NumeroDePase { get => numeroDePase; set => Set(ref numeroDePase, value); }

        private DateTime entrada = DateTime.Now;
        public DateTime Entrada { get => entrada; set => Set(ref entrada, value); }

        private string placas;
        public string Placas { get => placas; set => Set(ref placas, value); }

        private string nombreVisita;
        public string NombreVisita { get => nombreVisita; set => Set(ref nombreVisita, value); }

        private string notas;
        public string Notas { get => notas; set => Set(ref notas, value); }


        private string foto;
        public string Foto { get => foto; set => Set(ref foto, value); }

        private DateTime? salida;
        public DateTime? Salida { get => salida; set => Set(ref salida, value); }

        private string recepcionistaSalida;
        public string RecepcionistaSalida { get => recepcionistaSalida; set => Set(ref recepcionistaSalida, value); }
    }
}
