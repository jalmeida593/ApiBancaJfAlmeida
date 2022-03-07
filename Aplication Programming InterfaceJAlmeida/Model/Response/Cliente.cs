using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication_Programming_InterfaceJAlmeida.Model.Response
{
    [Keyless]
    public class Cliente
    {
        [Key]
        [Column("idCliente")]
        public int ? idCliente { get; set; }

        [Column("contraseña")]
        public string ? contraseña { get; set; }

        [Column("estado")]
        public int ? estado { get; set; }

        [Column("idPersona")]
        public int ? idPersona { get; set; }
    }
}
