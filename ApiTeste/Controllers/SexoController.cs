using ApiTeste.Models;
using ApiTeste.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SexoController : ControllerBase
    {
        private readonly SexoService sexoService;

        public SexoController(SexoService sexoService)
        {
            this.sexoService = sexoService;
        }
        [HttpGet]
        public async Task<IEnumerable<Sexo>> GetAll()
        {
            return await sexoService.GetSexosAsync();
        }
    }
}