using apiRegistroColegio.Data.repositoris;
using apiRegistroColegio.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiRegistroColegio.Controllers
{
    [Route("api/asignacion")]
    [ApiController]
    public class AsignacionController : ControllerBase
    {
        private readonly IAsignaturasRepository _asignaturaRepository;

        public AsignacionController(IAsignaturasRepository asignaturaRepository)
        {
            _asignaturaRepository = asignaturaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsignaturas()
        {
            return Ok(await _asignaturaRepository.GetAllAsignatura());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getAsiganatura(int id)
        {
            return Ok(await _asignaturaRepository.GetAsignatura(id));
        }

        [HttpPost]
        public async Task<IActionResult> saveAsignacion([FromBody] Asignatura asignatura)
        {
            if (asignatura == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var save = await _asignaturaRepository.saveAsignatura(asignatura);
            return Created("create", save);
        }

        [HttpPut]
        public async Task<IActionResult> updateAsignacion([FromBody] Asignatura asignatura)
        {
            if (asignatura == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _asignaturaRepository.updateAsignatura(asignatura);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAsiganatura(int id)
        {
            await _asignaturaRepository.deleteAsignatura(new Asignatura { Id = id });
            return NoContent();
        }

        [HttpPut]
        [Route("asignar_profesor")]
        public async Task<IActionResult> AsignarProfesor([FromBody] Asignatura asignatura)
        {
            return Ok(await _asignaturaRepository.asignaturarDocente(asignatura.Id, (int)asignatura.ProfesorId));
        }

        [HttpPut]
        [Route("asignar_estudiante")]
        public async Task<IActionResult> AsignarEstudiante([FromBody] Inscrito inscrito)
        {
            return Ok(await _asignaturaRepository.asignaturarEstudiante(inscrito.AsignaturaId, inscrito.EstudianteId));
        }
    }
}
