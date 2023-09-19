using apiRegistroColegio.Data.repositoris;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiRegistroColegio.Controllers
{
    [Route("api/estudiante")]
    [ApiController]
    public class EstusianteController : ControllerBase
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstusianteController(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEstudiante()
        {
            return Ok(await _estudianteRepository.GetAllEstudiante());
        }
    }
}
