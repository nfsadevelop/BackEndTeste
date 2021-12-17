using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTeste.Models
{
    [Table("Usuario")]
    public class Usuario : BaseModel<Usuario>
    {
        public Usuario(int codigo, string? nome, int sexoId, int tipoPessoaId) : base()
        {
            Codigo = codigo;
            Nome = nome;
            SexoId = sexoId;
            TipoPessoaId = tipoPessoaId;
        }
        [Key]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Inválido")]
        public int Codigo { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(120, ErrorMessage = "Este campo deve ter no maximo 120 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter no mínimo 3 caracteres")]
        public string? Nome { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Inválido")]
        public int SexoId { get; private set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Inválido")]
        public int TipoPessoaId { get; private set; }

        public void Update(int codigo, string? nome, int sexoId, int tipoPessoaId) 
        {
            Codigo = codigo;
            Nome = nome;
            SexoId = sexoId;
            TipoPessoaId = tipoPessoaId;
        }
    }
}
