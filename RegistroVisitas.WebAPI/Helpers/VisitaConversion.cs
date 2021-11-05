namespace SharedAPIModel
{
    public partial class Visita
    {
        public static implicit operator RegistroVisitas.WebAPI.Model.Visita(Visita v) =>
            new()
            {
                Id = v.Id,
                Recepcionista = v.Recepcionista,
                CasaId = v.CasaId,
                NumeroDePase = v.NumeroDePase,
                FechaHoraDeEntrada = v.FechaHoraDeEntrada,
                Visitante = v.Visitante,
                Notas = v.Notas,
                Placas= v.Placas,
                Foto = v.Foto,
                FechaHoraDeSalida = v.FechaHoraDeSalida
            };
    }
}

namespace RegistroVisitas.WebAPI.Model
{
    public partial class Visita
    {
        public static implicit operator SharedAPIModel.Visita(Visita v) =>
            new()
            {
                Id = v.Id,
                Recepcionista = v.Recepcionista,
                CasaId = v.CasaId,
                NumeroDePase = v.NumeroDePase,
                FechaHoraDeEntrada = v.FechaHoraDeEntrada,
                Visitante = v.Visitante,
                Notas = v.Notas,
                Placas = v.Placas,
                Foto = v.Foto,
                FechaHoraDeSalida = v.FechaHoraDeSalida
            };
    }
}

namespace System.Collections.Generic
{
    public static class CollectionExtensions
    {
        public static IEnumerable<RegistroVisitas.WebAPI.Model.Visita> ToModel(this IEnumerable<SharedAPIModel.Visita> visitas)
        {
            foreach (var visita in visitas)
                yield return visita;
        }

        public static IEnumerable<SharedAPIModel.Visita> ToSharedModel(this IEnumerable<RegistroVisitas.WebAPI.Model.Visita> visitas)
        {
            foreach (var visita in visitas)
                yield return visita;
        }
    }
}