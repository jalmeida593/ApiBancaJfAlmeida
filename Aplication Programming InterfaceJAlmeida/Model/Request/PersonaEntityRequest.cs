using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication_Programming_InterfaceJAlmeida.Model.Request
{
    public class PersonaEntityRequest
    {

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
               

    }
    
}