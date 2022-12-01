using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoFinal.Models;
using ProjetoFinal.Repositorio;

namespace ProjetoFinal.Controllers
{
    public class RequisicaoController : Controller
    {
        private readonly IRequisicaoRepositorio _requisicaoRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public RequisicaoController(IRequisicaoRepositorio requisicaoRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _requisicaoRepositorio = requisicaoRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            List<Requisicao> requisicoes = _requisicaoRepositorio.BuscarTodos();
            return View(requisicoes);
        }

        [Authorize]
        public IActionResult Criar()
        {
            CarregarProdutos();

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Criar(Requisicao requisicao)
        {
            try
            {
                Produto produto = _produtoRepositorio.ListarPorId(requisicao.Produto.Id);

                //Verifica se o estoque do produto é maior ou igual à quantidade de requisição
                if (produto.Quantidade >= requisicao.Quantidade)
                {
                    requisicao.Produto= produto;
                    _requisicaoRepositorio.Adicionar(requisicao);
                    produto.Quantidade -= requisicao.Quantidade;

                    _produtoRepositorio.Atualizar(produto);

                    TempData["MensagemSucesso"] = "Requisição cadastrada com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    CarregarProdutos();

                    TempData["MensagemErro"] = "A quantidade da requisição excede a quantidade no estoque.";
                    return View(requisicao);
                }
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        /*[Authorize]
        public IActionResult Editar(int id)
        {
            Requisicao requisicao = _requisicaoRepositorio.ListarPorId(id);
            return View(requisicao);
        }*/

        /*[Authorize]
        [HttpPost]
        public IActionResult Alterar(Requisicao requisicao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _requisicaoRepositorio.Atualizar(requisicao);
                    TempData["MensagemSucesso"] = "Requisição alterada com sucesso!";
                    return RedirectToAction("Index");

                }
                return View("Editar", requisicao);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos alterar a requisição! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }*/

        [Authorize]
        public IActionResult ApagarConfirmacao(int id)
        {
            Requisicao requisicao = _requisicaoRepositorio.ListarPorId(id);
            return View(requisicao);
        }

        [Authorize]
        public IActionResult Apagar(int id)
        {
            try
            {
                //Retorna a quantidade de items para o estoque
                Requisicao requisicao = _requisicaoRepositorio.ListarPorId(id);
                Produto produto = requisicao.Produto;
                produto.Quantidade += requisicao.Quantidade;

                _produtoRepositorio.Atualizar(produto);

                bool apagado = _requisicaoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Requisição apagada com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível apagar a requisição! Tente novamante!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar a requisição! Detalhe do erro: {erro.Message}";

                return RedirectToAction("Index");
            }
        }

        private void CarregarProdutos()
        {
            ViewBag.Produtos = _produtoRepositorio.BuscarTodos().ToList();
        }
    }
}
