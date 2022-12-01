using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a quantidade do produto")]
        public int Quantidade { get; set; }
    }
}
