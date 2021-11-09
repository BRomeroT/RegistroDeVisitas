namespace SharedAPIModel
{
    public partial class Sesion
    {
        public static implicit operator RegistroVisitas.WebAPI.Model.Sesion(Sesion s) =>
            new()
            {
                Numero = s.Numero,
                Recepcionista = s.Recepcionista,
                Fecha = s.Fecha
            };
    }
}

namespace RegistroVisitas.WebAPI.Model
{
    public partial class Sesion
    {
        public static implicit operator SharedAPIModel.Sesion(Sesion s) =>
            new()
            {
                Numero = s.Numero,
                Recepcionista = s.Recepcionista,
                Fecha = s.Fecha
            };
    }
}

namespace System.Collections.Generic
{
    public static partial class CollectionExtensions
    {
        public static IEnumerable<RegistroVisitas.WebAPI.Model.Sesion> ToModel(this IEnumerable<SharedAPIModel.Sesion> sesiones)
        {
            foreach (var Sesion in sesiones)
                yield return Sesion;
        }

        public static IEnumerable<SharedAPIModel.Sesion> ToSharedModel(this IEnumerable<RegistroVisitas.WebAPI.Model.Sesion> sesiones)
        {
            foreach (var Sesion in sesiones)
                yield return Sesion;
        }
    }
}