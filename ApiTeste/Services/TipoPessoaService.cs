using ApiTeste.Data;
using ApiTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTeste.Services
{
    public class TipoPessoaService
    {
        private readonly Context _context;

        public TipoPessoaService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoPessoa>> GetTipoPessoasAsync()
        {
            return await _context.TipoPessoas.ToListAsync();
        }
    }
}
