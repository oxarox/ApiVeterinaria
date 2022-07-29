using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace Siglo21APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuario()
        {
            return Ok(await _usuarioRepository.GetAllUsuario());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioDetalle(int id)
        {
            return Ok(await _usuarioRepository.GetUsuarioDetalles(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargo([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _usuarioRepository.InsertarUsuario(usuario);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargo([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usuarioRepository.UpdateUsuario(usuario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioRepository.DeleteUsuario(new Usuario() { id_usuario = id });
            return NoContent();
        }
    }
}
