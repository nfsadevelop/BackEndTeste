using ApiTeste.Models;
using ApiTeste.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoPessoaController : ControllerBase
    {
        private readonly TipoPessoaService tipoPessoaService;

        public TipoPessoaController(TipoPessoaService tipoPessoaService)
        {
            this.tipoPessoaService = tipoPessoaService;
        }
        [HttpGet]
        public async Task<IEnumerable<TipoPessoa>> GetAll()
        {
            return await tipoPessoaService.GetTipoPessoasAsync();
        }
    }
}