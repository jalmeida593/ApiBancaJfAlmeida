using Aplication_Programming_InterfaceJAlmeida.Entities;
using Aplication_Programming_InterfaceJAlmeida.Model;
using Aplication_Programming_InterfaceJAlmeida.Model.Response;
using AutoMapper;

namespace Aplication_Programming_InterfaceJAlmeida.Services.Impl
{
    public class MovimientosService : IMovimientosService
    {
        private ILogger<IMovimientosService> _logger;
        private readonly BancaDbContext _bancaDbContext;
        private readonly IMapper mapper;
        public IConfiguration _configuration { get; }

        public MovimientosService(ILogger<MovimientosService> logger, IConfiguration configuration, BancaDbContext bancaDbContext, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _bancaDbContext = bancaDbContext;
            this.mapper = mapper;
        }

        public List<Movimientos> GetMovimientos(int idCuenta)
        {
            var movimientos = _bancaDbContext.movimientos.Where(z => z.idCuentas == idCuenta).ToList();
            return movimientos;
        }

        public Movimientos CreateMovimientos(Movimientos movimientos)
        {
            //Movimientos movimiento = new Movimientos();
            var cuentas = _bancaDbContext.cuentascliente.Where(y => y.idCuentas == movimientos.idCuentas).FirstOrDefault();
            if (cuentas != null)
            {
                movimientos.idMovimientos = null;
                if (movimientos.tipoMovimiento.Equals("Retiro"))
                {
                    if (movimientos.valor < cuentas.saldoInicial)
                    {
                        if (movimientos.valor < movimientos.saldo)
                        {
                            //si tiene dinero
                            movimientos.saldo = cuentas.saldoInicial - movimientos.valor;
                            _bancaDbContext.Add(movimientos);
                            _bancaDbContext.SaveChanges();
                        }
                    }
                    else
                    {
                        movimientos.tipoMovimiento = "Saldo no disponible ";
                        // no tiene saldo
                    }
                }
                else
                {
                    movimientos.saldo = cuentas.saldoInicial + movimientos.saldo;
                    _bancaDbContext.Add(movimientos);
                    _bancaDbContext.SaveChanges();
                    //deposito
                }
            }
            return movimientos;
        }

       

    }
}
