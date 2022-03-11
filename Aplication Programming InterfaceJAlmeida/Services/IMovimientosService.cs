using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Model;

namespace Aplication_Programming_InterfaceJAlmeida.Services
{
    public interface IMovimientosService
    {
        List<Movimientos> GetMovimientos(int identificacion);
        Movimientos CreateMovimientos(Movimientos movimientos);
    }
}
