using Model = RegistroVisitas.WebAPI.Model;

namespace SharedAPIModel
{
    public partial class Visita
    {
        public static implicit operator Model.Visita(Visita v)
        {
            return new()
            {
                Id = v.Id,
                Recepcionista = v.Recepcionista,
                CasaId = v.CasaId,
                NumeroDePase = v.NumeroDePase,
                FechaHoraDeEntrada = v.FechaHoraDeEntrada,
                Visitante = v.Visitante,
                Notas = v.Notas,
                Foto = v.Foto,
                FechaHoraDeSalida = v.FechaHoraDeSalida
            };
        }
    }
}
