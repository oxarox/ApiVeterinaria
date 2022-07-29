using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories.Interfaz;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace Siglo21APIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitaController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCita()
        {
            return Ok(await _citaRepository.GetAllCita());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCitaDetalles(int id)
        {
            return Ok(await _citaRepository.GetCitaDetalles(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCita([FromBody] Cita cita)
        {
            if (cita == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _citaRepository.InsertarCita(cita);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCita([FromBody] Cita cita)
        {
            if (cita == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _citaRepository.UpdateCita(cita);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            Cita cita = await _citaRepository.GetCitaDetalles(id);
            if (cita == null)
                return NotFound();

            await _citaRepository.DeleteCita(cita);

            return NoContent();
        }
    }
}
