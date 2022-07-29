using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories.Interfaz;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace Siglo21APIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly IEspecialidadRepository _especialidadRepository;

        public EspecialidadController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEspecialidad()
        {
            return Ok(await _especialidadRepository.GetAllEspecialidad());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEspecialidadDetalle(int id)
        {
            return Ok(await _especialidadRepository.GetEspecialidadDetalles(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEspecialidad([FromBody] Especialidad especialidad)
        {
            if (especialidad == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _especialidadRepository.InsertarEspecialidad(especialidad);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEspecialidad([FromBody] Especialidad especialidad)
        {
            if (especialidad == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _especialidadRepository.UpdateEspecialidad(especialidad);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidad(int id)
        {
            Especialidad especialidad = await _especialidadRepository.GetEspecialidadDetalles(id);
            if (especialidad == null)
                return NotFound();

            await _especialidadRepository.DeleteEspecialidad(especialidad);

            return NoContent();
        }
    }
}
