using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories.Interfaz;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace Siglo21APIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TipoMascotaController : ControllerBase
    {
        private readonly ITipoMascotaRepository _tipoMascotaRepository;

        public TipoMascotaController(ITipoMascotaRepository tipoMascotaRepository)
        {
            _tipoMascotaRepository = tipoMascotaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTipoMascota()
        {
            return Ok(await _tipoMascotaRepository.GetAllTipoMascota());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoMascotaDetalle(int id)
        {
            return Ok(await _tipoMascotaRepository.GetTipoMascotaDetalles(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipoMascota([FromBody] TipoMascota tipoMascota)
        {
            if (tipoMascota == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _tipoMascotaRepository.InsertarTipoMascota(tipoMascota);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTipoMascota([FromBody] TipoMascota tipoMascota)
        {
            if (tipoMascota == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tipoMascotaRepository.UpdateTipoMascota(tipoMascota);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoMascota(int id)
        {
            TipoMascota tipoMascota = await _tipoMascotaRepository.GetTipoMascotaDetalles(id);
            if (tipoMascota == null)
                return NotFound();

            await _tipoMascotaRepository.DeleteTipoMascota(tipoMascota);

            return NoContent();
        }
    }
}
