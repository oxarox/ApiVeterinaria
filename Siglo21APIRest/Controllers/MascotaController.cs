using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories.Interfaz;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace Siglo21APIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaRepository _mascotaRepository;

        public MascotaController(IMascotaRepository mascotaRepository)
        {
            _mascotaRepository = mascotaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMascota()
        {
            return Ok(await _mascotaRepository.GetAllMascota());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMascotaDetalle(int id)
        {
            return Ok(await _mascotaRepository.GetMascotaDetalles(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMascota([FromBody] Mascota mascota)
        {
            if (mascota == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _mascotaRepository.InsertarMascota(mascota);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMascota([FromBody] Mascota mascota)
        {
            if (mascota == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mascotaRepository.UpdateMascota(mascota);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascota(int id)
        {
            Mascota mascota = await _mascotaRepository.GetMascotaDetalles(id);
            if (mascota == null)
                return NotFound();

            await _mascotaRepository.DeleteMascota(mascota);

            return NoContent();
        }

    }
}
