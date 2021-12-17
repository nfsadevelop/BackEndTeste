using ApiTeste.Models;

namespace ApiTeste.Controllers.Dto
{
    public class UsuarioDto
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public int SexoId{ get; set; }
        public int TipoPessoaId{ get; set; }

        public Usuario ToModel()  
        {
            return new Usuario(Codigo, Nome, SexoId, TipoPessoaId);
        }
    }
}
