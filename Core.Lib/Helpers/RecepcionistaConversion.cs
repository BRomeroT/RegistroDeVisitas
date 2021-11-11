namespace SharedAPIModel
{
    public partial class Recepcionista
    {
        public static implicit operator Core.Model.Recepcionista(Recepcionista r) =>
            new()
            {
                Id = r.Id,
                Nombre = r.Nombre
            };
    }
}

namespace Core.Model
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
        public static IEnumerable<Core.Model.Recepcionista> ToModel(this IEnumerable<SharedAPIModel.Recepcionista> recepcionistas)
        {
            foreach (var Recepcionista in recepcionistas)
                yield return Recepcionista;
        }

        public static IEnumerable<SharedAPIModel.Recepcionista> ToSharedModel(this IEnumerable<Core.Model.Recepcionista> recepcionistas)
        {
            foreach (var Recepcionista in recepcionistas)
                yield return Recepcionista;
        }
    }
}