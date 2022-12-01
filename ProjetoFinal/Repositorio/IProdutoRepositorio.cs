using ProjetoFinal.Models;

namespace ProjetoFinal.Repositorio
{
    public interface IProdutoRepositorio
    {
        Produto Adicionar(Produto produto);

        List<Produto> BuscarTodos();

        Produto ListarPorId(int Id);

        Produto Atualizar(Produto produto);

        bool Apagar(int id);
    }
}
