using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Model;
using Aplication_Programming_InterfaceJAlmeida.Model.Response;
using AutoMapper;

namespace Aplication_Programming_InterfaceJAlmeida.Services.Impl
{
    public class CuentaService : ICuentasService
    {
        private ILogger<ICuentasService> _logger;
        private readonly BancaDbContext _bancaDbContext;
        private readonly IMapper mapper;
        public IConfiguration _configuration { get; }

        public CuentaService(ILogger<CuentaService> logger, IConfiguration configuration, BancaDbContext bancaDbContext, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _bancaDbContext = bancaDbContext;
            this.mapper = mapper;
        }

        public CuentasCliente GetCuentas(string identificacion)
        {
            CuentasCliente cuentas = new CuentasCliente();
            var persona = _bancaDbContext.persona.Where(x => x.identificacion == identificacion).FirstOrDefault();
            var cliente = _bancaDbContext.cliente.Where(y => y.idPersona == persona.idPersona).FirstOrDefault();
            cuentas = _bancaDbContext.cuentascliente.Where(z => z.idCliente == cliente.idCliente).FirstOrDefault();
            return cuentas;
        }

        public CuentasCliente CreateCuenta(CuentasCliente cuentas)
        {
            var cliente = _bancaDbContext.cliente.Where(y => y.idCliente == cuentas.idCliente).FirstOrDefault();
            if (cliente != null)
            {
                cuentas.idCuentas = null;
                _bancaDbContext.Add(cuentas);
                _bancaDbContext.SaveChanges();
            }
            return cuentas;
        }

        public status DeleteCuenta(int i)
        {
            status status = new status();
            var cuentacliente = _bancaDbContext.cuentascliente.FirstOrDefault(x => x.idCuentas == i);
            if (cuentacliente != null)
            {
                _bancaDbContext.Remove(cuentacliente);
                _bancaDbContext.SaveChanges();
                status.statuscode = "Ok";
                status.message = "Borrado Con Exito";
            }
            else
            {
                status.statuscode = "Error";
                status.message = "Cuenta No esta Registrada!";
            }
            return status;
        }

        public CuentasCliente UpdateCuenta(int id, CuentasCliente cuentas)
        {
            var cuentacliente = _bancaDbContext.cuentascliente.Where(x => x.idCuentas == id).FirstOrDefault();
            if (cuentacliente != null)
            {
                cuentacliente = cuentas;
                _bancaDbContext.Update(cuentacliente);
                _bancaDbContext.SaveChanges();
            }
            return cuentacliente;
        }
    }
}
