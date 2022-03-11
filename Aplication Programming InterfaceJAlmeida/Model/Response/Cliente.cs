using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication_Programming_InterfaceJAlmeida.Model.Response
{
    [Keyless]
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }

        public string contraseña { get; set; }

        public int estado { get; set; }

        public int idPersona { get; set; }

    }
}
