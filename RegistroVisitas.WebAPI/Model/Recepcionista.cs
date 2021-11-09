using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroVisitas.WebAPI.Model
{
    [Index(nameof(Nombre), nameof(Codigo))]
    public partial class Recepcionista
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}
