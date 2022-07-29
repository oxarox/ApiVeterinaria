using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories.Interfaz;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace Siglo21APIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FichaMedicaController : ControllerBase
    {
        private readonly IFichaMedicaRepository _fichaMedicaRepository;

        public FichaMedicaController(IFichaMedicaRepository fichaMedicaRepository)
        {
            _fichaMedicaRepository = fichaMedicaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFichaMedica()
        {
            return Ok(await _fichaMedicaRepository.GetAllFichaMedica());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFichaMedicaDetalle(int id)
        {
            return Ok(await _fichaMedicaRepository.GetFichaMedicaDetalles(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFichaMedica([FromBody] FichaMedica fichaMedica)
        {
            if (fichaMedica == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _fichaMedicaRepository.InsertarFichaMedica(fichaMedica);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFichaMedica([FromBody] FichaMedica fichaMedica)
        {
            if (fichaMedica == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _fichaMedicaRepository.UpdateFichaMedica(fichaMedica);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFichaMedica(int id)
        {
            FichaMedica fichaMedica = await _fichaMedicaRepository.GetFichaMedicaDetalles(id);
            if (fichaMedica == null)
                return NotFound();

            await _fichaMedicaRepository.DeleteFichaMedica(fichaMedica);

            return NoContent();
        }
    }
}
