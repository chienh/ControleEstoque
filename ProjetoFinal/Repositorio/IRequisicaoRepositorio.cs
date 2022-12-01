using ProjetoFinal.Models;

namespace ProjetoFinal.Repositorio
{
    public interface IRequisicaoRepositorio
    {
        Requisicao Adicionar(Requisicao requisicao);

        List<Requisicao> BuscarTodos();

        Requisicao ListarPorId(int Id);

        Requisicao Atualizar(Requisicao requisicao);

        bool Apagar(int id);
    }
}
