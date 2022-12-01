using ProjetoFinal.Data;
using ProjetoFinal.Models;

namespace ProjetoFinal.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ApplicationDbContext _context;
        public ProdutoRepositorio(ApplicationDbContext bancoContext)
        {
            _context = bancoContext;
        }

        public Produto Adicionar(Produto produto)
        {
            //gravar no banco de dados
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return produto;
        }

        public List<Produto> BuscarTodos()
        {
            return _context.Produtos.OrderBy(p => p.Nome).ToList();
        }

        public Produto ListarPorId(int id)
        {
            return _context.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public Produto Atualizar(Produto produto)
        {
            Produto produtoDb = ListarPorId(produto.Id);

            if (produtoDb == null) throw new System.Exception("Houve um erro de atualização");

            produtoDb.Nome = produto.Nome;
            produtoDb.Quantidade = produto.Quantidade;            

            _context.Produtos.Update(produtoDb);
            _context.SaveChanges();
            return produtoDb;
        }

        public bool Apagar(int id)
        {
            Produto produtoDb = ListarPorId(id);

            if (produtoDb == null) throw new System.Exception("Houve um erro de Exclusão");

            _context.Produtos.Remove(produtoDb);
            _context.SaveChanges();

            return true;
        }
    }
}
