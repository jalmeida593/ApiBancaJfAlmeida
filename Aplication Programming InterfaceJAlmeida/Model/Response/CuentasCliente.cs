using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication_Programming_InterfaceJAlmeida.Model
{
    [Keyless]
    public class CuentasCliente
    {
        [Key]
        [Column("idCuentas")]
        public int ? idCuentas { get; set; }

        [Column("numeroCuenta")]
        public string ? numeroCuenta { get; set; }
        
        [Column("tipo")]
        public string ? tipo { get; set; }

        [Column("saldoInicial")]
        public decimal ? saldoInicial { get; set; }

        [Column("estado")]
        public int ? estado { get; set; }


        [Column("idCliente")]
        public int ? idCliente { get; set; }

    }
}