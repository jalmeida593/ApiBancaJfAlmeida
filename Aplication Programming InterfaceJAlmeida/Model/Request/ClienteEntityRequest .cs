using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication_Programming_InterfaceJAlmeida.Model.Request
{
    public class ClienteEntityRequest:PersonaEntityRequest
    {

        [Column("contrasena")]
        public string ? contrasena { get; set; }
        
        
        
        [Column("estado")]
        public int estado { get; set; }
               

    }
    
}