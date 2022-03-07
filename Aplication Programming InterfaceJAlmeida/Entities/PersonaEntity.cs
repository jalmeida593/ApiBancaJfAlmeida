using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication_Programming_InterfaceJAlmeida.Entities
{
    [Keyless]

    public class PersonaEntity
    {
        [Column("idPersona")]
        public int ? idPersona { get; set; }

        [Column("identificacion")]
        public string ? identificacion { get; set; }
        
        [Column("nombre")]
        public string ? nombre { get; set; }
        
        [Column("apellido")]
        public string ? apellido { get; set; }

        [Column("genero")]
        public char ? genero { get; set; }

        [Column("fechaNacimiento")]
        public DateTime ? fechaNacimiento { get; set; }

        [Column("direccion")]
        public string ? direccion { get; set; }
        
        [Column("telefono")]
        public string ? telefono { get; set; }
        public status ? status {get; set;}
        public cliente? cliente { get; set; }

    }
    public class cliente
    {
        [Column("idCliente")]
        public int? idCliente { get; set; }

        [Column("contraseña")]
        public string? contraseña { get; set; }

        [Column("estado")]
        public int? estado { get; set; }
    }
    public class status
    {
        public string statuscode { get; set; }
        public string message { get; set; }
    }
}