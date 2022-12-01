using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;
using ProjetoFinal.Repositorio;

namespace ProjetoFinal.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
       
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            List<Produto> produtos = _produtoRepositorio.BuscarTodos();
            return View(produtos);
        }

        [Authorize]
        public IActionResult Criar()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.Adicionar(produto);
                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(produto);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public IActionResult Editar(int id)
        {
            Produto produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Alterar(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.Atualizar(produto);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                    return RedirectToAction("Index");

                }
                return View("Editar", produto);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos alterar o produto! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public IActionResult ApagarConfirmacao(int id)
        {
            Produto produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        [Authorize]
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _produtoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Produto apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível apagar o produto! Tente novamante!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar o produto! Detalhe do erro: {erro.Message}";

                return RedirectToAction("Index");
            }
        }
    }
}
