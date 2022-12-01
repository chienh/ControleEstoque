using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Requisicao
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Selecione o produto")]
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de produtos")]
        public int Quantidade { get; set; }
    }
}
