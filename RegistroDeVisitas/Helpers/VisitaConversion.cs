namespace SharedAPIModel
{
    public partial class Visita
    {
        public static implicit operator Core.Model.Visita(Visita v)=>
            new()
            {
                Id = v.Id,
                Recepcionista = v.Recepcionista,
                CasaCodigo = v.CasaId,
                NumeroDePase = v.NumeroDePase,
                Entrada = v.FechaHoraDeEntrada,
                NombreVisita = v.Visitante,
                Notas = v.Notas,
                Foto = v.Foto,
                Salida = v.FechaHoraDeSalida
            };
    }
}

namespace Core.Model
{
    public partial class Visita
    {
        public static implicit operator SharedAPIModel.Visita(Visita v) =>
            new()
            {
                Id = v.Id,
                Recepcionista = v.Recepcionista,
                CasaId = v.CasaCodigo,
                NumeroDePase = v.NumeroDePase,
                FechaHoraDeEntrada = v.Entrada,
                Visitante = v.NombreVisita,
                Notas = v.Notas,
                Foto = v.Foto,
                FechaHoraDeSalida = v.Salida
            };
    }
}