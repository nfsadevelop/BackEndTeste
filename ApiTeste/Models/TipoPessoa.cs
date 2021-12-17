using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTeste.Models
{
    [Table("TipoPessoa")]
    public class TipoPessoa
    {
        public TipoPessoa(string valor)
        {
            Valor = valor;            
        }
        [Key]
        public int Id { get; private set; }        
        public string Valor { get; private set; }
    }
}
