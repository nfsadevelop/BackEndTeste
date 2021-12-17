using ApiTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTeste.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<TipoPessoa> TipoPessoas { get; set; }
    }
}
