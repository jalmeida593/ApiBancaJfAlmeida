using Aplication_Programming_InterfaceJAlmeida.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aplication_Programming_InterfaceJAlmeida.Controllers
{/// <summary>
 /// Controlador para Personas.
 /// </summary>
    [Route("api/reporte")]
    [ApiController]
    public class ReporteController : Controller
    {
        private readonly IPersonasService _personaService;
        /// <summary>
        /// Constructor Controlador.
        /// </summary>
        public ReporteController(IPersonasService personaService)
        {
            _personaService = personaService;
        }

    }
}
