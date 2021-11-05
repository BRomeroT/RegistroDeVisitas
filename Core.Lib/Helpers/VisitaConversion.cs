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
                Placas = v.Placas,
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
                Placas = v.Placas,
                Foto = v.Foto,
                FechaHoraDeSalida = v.Salida
            };
    }
}

namespace System.Collections.Generic
{
    public static class CollectionExtensions
    {
        public static IEnumerable<Core.Model.Visita> ToModel(this IEnumerable<SharedAPIModel.Visita> visitas)
        {
            foreach (var visita in visitas)
                yield return visita;
        }

        public static IEnumerable<SharedAPIModel.Visita> ToSharedModel(this IEnumerable<Core.Model.Visita> visitas)
        {
            foreach (var visita in visitas)
                yield return visita;
        }
    }
}