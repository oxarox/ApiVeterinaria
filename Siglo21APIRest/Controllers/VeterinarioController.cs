using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories.Interfaz;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace Siglo21APIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private readonly IVeterinarioRepository _veterinarioRepository;

        public VeterinarioController(IVeterinarioRepository veterinarioRepository)
        {
            _veterinarioRepository = veterinarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVeterinario()
        {
            return Ok(await _veterinarioRepository.GetAllVeterinario());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVeterinarioDetalle(int id)
        {
            return Ok(await _veterinarioRepository.GetVeterinarioDetalles(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateVeterinario([FromBody] Veterinario veterinario)
        {
            if (veterinario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _veterinarioRepository.InsertarVeterinario(veterinario);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVeterinario([FromBody] Veterinario veterinario)
        {
            if (veterinario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _veterinarioRepository.UpdateVeterinario(veterinario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeterinario(int id)
        {
            Veterinario veterinario = await _veterinarioRepository.GetVeterinarioDetalles(id);
            if (veterinario == null)
                return NotFound();

            await _veterinarioRepository.DeleteVeterinario(veterinario);

            return NoContent();
        }
    }
}
