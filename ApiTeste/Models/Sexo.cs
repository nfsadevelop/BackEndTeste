using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTeste.Models
{
    [Table("Sexo")]
    public class Sexo
    {
        public Sexo(string valor)
        {
            Valor = valor;
        }
        [Key]
        public int Id { get; private set; }
        public string Valor { get; private set; }
    }
}
