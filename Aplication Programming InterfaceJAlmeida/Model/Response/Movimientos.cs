using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplication_Programming_InterfaceJAlmeida.Model
{
    [Keyless]

    public class Movimientos
    {
        [Key]
        [Column("idMovimientos")]
        public int ? idMovimientos { get; set; }

        [Column("fechaProceso")]
        public DateTime ? fechaProceso { get; set; }

        [Column("tipoMovimiento")]
        public string ? tipoMovimiento { get; set; }

        [Column("valor")]
        public decimal ? valor { get; set; }
        
        [Column("saldo")]
        public decimal ? saldo { get; set; }

        [Column("idCuentas")]
        public int ? idCuentas { get; set; }
    }
}