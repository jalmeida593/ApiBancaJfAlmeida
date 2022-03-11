using Aplication_Programming_InterfaceJAlmeida.Model;
using Aplication_Programming_InterfaceJAlmeida.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aplication_Programming_InterfaceJAlmeida.Controllers
{
    /// <summary>
    /// Controlador para Cuentas de Clientes.
    /// </summary>
    [Route("api/movimientos")]
    [ApiController]
    public class MovimientosController : Controller
    {
        private readonly IMovimientosService _movimientoService;
        /// <summary>
        /// Constructor Controlador.
        /// </summary>
        public MovimientosController(IMovimientosService movimientosService)
        {
            _movimientoService = movimientosService;
        }

        /// <summary>
        /// Obtener información sobre las cuentas de un cliente ingresando el número de cédula.
        /// </summary>
        /// <param name="identificacion">Número de identificación de la persona</param>
        /// <returns>Entidad resultante de la consulta</returns>
        /// <response code="200">Entidad con el resultado de la consulta</response>
        /// <response code="400">Mensaje de error al tratar de realizar la consulta</response>  

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movimientos))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public ActionResult<List<Movimientos>> GetMovimientos(int idCuenta)
        {
            return _movimientoService.GetMovimientos(idCuenta);
        }

        /// <summary>
        /// Inserción de los datos de cuenta de la persona.
        /// </summary>
        /// <param name="movimientos">Entidad para el manejo de movimientos</param>
        /// <returns>Entidad resultante de la consulta</returns>
        /// <response code="200">Entidad con el resultado de la consulta</response>
        /// <response code="400">Mensaje de error al tratar de realizar la consulta</response>  

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movimientos))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public ActionResult<Movimientos> CreateMovimientos(Movimientos movimientos)
        {
            return _movimientoService.CreateMovimientos(movimientos);
        }
    }
}
