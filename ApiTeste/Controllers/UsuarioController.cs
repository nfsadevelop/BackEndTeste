using ApiTeste.Controllers.Dto;
using ApiTeste.Models;
using ApiTeste.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>?>> GetAll()
        {
            var results = await _usuarioService.GetUsuariosAsync();

            if (results == null) 
            {
                return StatusCode(501, new { Errors = _usuarioService.Errors });
            }
                
            
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Insert([FromBody] UsuarioDto dto)
        {
            var result = await _usuarioService.AddUsuarioAsync(dto.ToModel());

            if (!result)
                return StatusCode(400, new { Errors = _usuarioService.Errors });

            return StatusCode(201, result);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update([FromBody] UsuarioDto dto, [FromQuery] int codigo)
        {
            var result = await _usuarioService.UpdateUsuarioAsync(dto.ToModel(), codigo);

            if (!result)
                return StatusCode(400, new { Errors = _usuarioService.Errors });

            return StatusCode(201, result);
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromQuery] int codigo)
        {
            var result = await _usuarioService.DeleteUsuarioAsync(codigo);

            if (!result)
                return StatusCode(400, new { Errors = _usuarioService.Errors });

            return StatusCode(201, result);
        }
    }
}
