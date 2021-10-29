using System;

namespace RegistroVisitas.WebAPI.Model
{
    public class Visita
    {
        public Guid Id { get; set; }
        public string Recepcionista { get; set; }
        public string CasaId { get; set; }
        public string NumeroDePase { get; set; }
        public DateTime FechaHoraDeEntrada { get; set; }
        public string Visitante { get; set; }
        public string Notas { get; set; }
        public string Foto { get; set; }
        public DateTime? FechaHoraDeSalida { get; set; }
    }
}
