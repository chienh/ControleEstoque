using ProjetoFinal.Models;

namespace ProjetoFinal.Repositorio
{
    public interface IProdutoRepositorio
    {
        Produto Adicionar(Produto contato);

        List<Produto> BuscarTodos();

        Produto ListarPorId(int Id);

        Produto Atualizar(Produto contato);

        bool Apagar(int id);
    }
}
