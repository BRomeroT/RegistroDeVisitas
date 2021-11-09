namespace SharedAPIModel
{
    public partial class Recepcionista
    {
        public static implicit operator RegistroVisitas.WebAPI.Model.Recepcionista(Recepcionista r) =>
            new()
            {
                Id = r.Id,
                Nombre = r.Nombre
            };
    }
}

namespace RegistroVisitas.WebAPI.Model
{
    public partial class Recepcionista
    {
        public static implicit operator SharedAPIModel.Recepcionista(Recepcionista r) =>
            new()
            {
                Id = r.Id,
                Nombre = r.Nombre
            };
    }
}

namespace System.Collections.Generic
{
    public static partial class CollectionExtensions
    {
        public static IEnumerable<RegistroVisitas.WebAPI.Model.Recepcionista> ToModel(this IEnumerable<SharedAPIModel.Recepcionista> recepcionistas)
        {
            foreach (var Recepcionista in recepcionistas)
                yield return Recepcionista;
        }

        public static IEnumerable<SharedAPIModel.Recepcionista> ToSharedModel(this IEnumerable<RegistroVisitas.WebAPI.Model.Recepcionista> recepcionistas)
        {
            foreach (var Recepcionista in recepcionistas)
                yield return Recepcionista;
        }
    }
}