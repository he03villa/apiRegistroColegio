using apiRegistroColegio.Data.repositoris;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiRegistroColegio.Controllers
{
    [Route("api/profesor")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly IProdesorRepository _profesorRepository;

        public ProfesorController(IProdesorRepository profesorRepository)
        {
            _profesorRepository = profesorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfesor()
        {
            return Ok(await _profesorRepository.GetAllProfesor());
        }
    }
}
