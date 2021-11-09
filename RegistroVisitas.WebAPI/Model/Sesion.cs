using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroVisitas.WebAPI.Model
{
    [Index(nameof(Fecha))]
    public partial class Sesion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numero { get; set; }
        public string Recepcionista { get; set; }
        public DateTime Fecha { get; set; }
    }
}
