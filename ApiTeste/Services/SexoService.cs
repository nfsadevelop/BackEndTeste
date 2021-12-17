using ApiTeste.Data;
using ApiTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTeste.Services
{
    public class SexoService
    {        
        private readonly Context _context;

        public SexoService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sexo>> GetSexosAsync() 
        {
            return await _context.Sexos.ToListAsync();
        }
    }
}
