using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Models;

namespace ProjetoFinal.Repositorio
{
    public class RequisicaoRepositorio : IRequisicaoRepositorio
    {
        private readonly ApplicationDbContext _context;
        public RequisicaoRepositorio(ApplicationDbContext bancoContext)
        {
            _context = bancoContext;
        }

        public Requisicao Adicionar(Requisicao requisicao)
        {
            //gravar no banco de dados
            _context.Requisicoes.Add(requisicao);
            _context.SaveChanges();

            return requisicao;
        }

        public List<Requisicao> BuscarTodos()
        {
            return _context.Requisicoes
                .OrderBy(r => r.Id)
                .Include(r => r.Produto)
                .ToList();
        }

        public Requisicao ListarPorId(int id)
        {
            return _context.Requisicoes
                .Include(r => r.Produto)
                .FirstOrDefault(x => x.Id == id);
        }

        public Requisicao Atualizar(Requisicao requisicao)
        {
            Requisicao requisicaooDb = ListarPorId(requisicao.Id);

            if (requisicaooDb == null) throw new System.Exception("Houve um erro de atualização");

            requisicaooDb.Produto = requisicao.Produto;
            requisicaooDb.Quantidade = requisicao.Quantidade;

            _context.Requisicoes.Update(requisicaooDb);
            _context.SaveChanges();
            return requisicaooDb;
        }

        public bool Apagar(int id)
        {
            Requisicao requisicaoDb = ListarPorId(id);

            if (requisicaoDb == null) throw new System.Exception("Houve um erro de Exclusão");

            _context.Requisicoes.Remove(requisicaoDb);
            _context.SaveChanges();

            return true;
        }
    }
}
