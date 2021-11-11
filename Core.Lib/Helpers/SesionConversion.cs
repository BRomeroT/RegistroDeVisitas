namespace SharedAPIModel
{
    public partial class Sesion
    {
        public static implicit operator Core.Model.Sesion(Sesion s) =>
            new()
            {
                Numero = s.Numero,
                Recepcionista = s.Recepcionista,
                Fecha = s.Fecha
            };
    }
}

namespace Core.Model
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
        public static IEnumerable<Core.Model.Sesion> ToModel(this IEnumerable<SharedAPIModel.Sesion> sesiones)
        {
            foreach (var Sesion in sesiones)
                yield return Sesion;
        }

        public static IEnumerable<SharedAPIModel.Sesion> ToSharedModel(this IEnumerable<Core.Model.Sesion> sesiones)
        {
            foreach (var Sesion in sesiones)
                yield return Sesion;
        }
    }
}