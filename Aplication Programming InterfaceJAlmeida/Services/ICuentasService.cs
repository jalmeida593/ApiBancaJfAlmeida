﻿using Aplication_Programming_InterfaceJAlmeida.Model;

namespace Aplication_Programming_InterfaceJAlmeida.Services
{
    public interface ICuentasService
    {
        CuentasCliente GetCuentas(string identificacion);
    }
}
