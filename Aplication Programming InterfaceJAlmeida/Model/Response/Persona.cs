using Aplication_Programming_InterfaceJAlmeida.Model.Response;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication_Programming_InterfaceJAlmeida.Model
{
    [Keyless]
    public class Persona
    {
        [Key]
        [Column("idPersona")]
        public int idPersona { get; set; }

        [Column("identificacion")]
        public string? identificacion { get; set; }
        [StringLength(maximumLength: 10)]
        [Column("nombre")]
        public string? nombre { get; set; }

        [Column("apellido")]
        public string? apellido { get; set; }

        [Column("genero")]
        public char? genero { get; set; }

        [Column("fechaNacimiento")]
        public DateTime? fechaNacimiento { get; set; }

        [Column("direccion")]
        public string? direccion { get; set; }

        [Column("telefono")]
        public string? telefono { get; set; }
    }
    
   
}