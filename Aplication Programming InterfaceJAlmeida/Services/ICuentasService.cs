using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Model;

namespace Aplication_Programming_InterfaceJAlmeida.Services
{
    public interface ICuentasService
    {
        CuentasCliente GetCuentas(string identificacion);
        CuentasCliente CreateCuenta(CuentasCliente cuentas);
        CuentasCliente UpdateCuenta(int id,CuentasCliente cuentas);
        status DeleteCuenta(int id);
    }
}
