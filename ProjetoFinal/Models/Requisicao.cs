using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Requisicao
    {

        public int Id { get; set; }

        public Produto produto { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de produtos")]
        public int Quantidade { get; set; }
    }
}
