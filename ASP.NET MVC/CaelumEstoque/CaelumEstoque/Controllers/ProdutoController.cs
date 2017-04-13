using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using CaelumEstoque.Filters;

namespace CaelumEstoque.Controllers
{
    [AutorizationFilter]
    public class ProdutoController : Controller
    {
        [Route("produtos", Name = "Produtos")]
        public ActionResult Index()
        {
            ProdutosDAO produtosDAO = new ProdutosDAO();
            IList<Produto> produtos = produtosDAO.Lista();
            return View(produtos);
        }

        public ActionResult Form()
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = categoriasDAO.Lista();
            ViewBag.Categorias = categorias;
            ViewBag.Produto = new Produto();
            return View();
        }


        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            if (produto.CategoriaId == 1 && produto.Preco < 100)
            {
                ModelState.AddModelError("Produto.Preco", "Preço inválido! Para a categoria Informática, insira um preço a partir de R$ 100,00.");
            }

            if (ModelState.IsValid)
            {
                ProdutosDAO produtosDAO = new ProdutosDAO();
                produtosDAO.Adiciona(produto);
                return RedirectToAction("Index");
            } else
            {
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                IList<CategoriaDoProduto> categorias = categoriasDAO.Lista();
                ViewBag.Categorias = categorias;
                ViewBag.Produto = produto;
                return View("Form");
            }
        }

        [Route("produtos/{id}", Name = "DetalheProduto")]
        public ActionResult Visualiza(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            return View(produto);
        }

        public ActionResult DecrementaQuantidade(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);
            return Json(produto);
        }

        public ActionResult AdicionaQuantidade(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade++;
            dao.Atualiza(produto);
            return Json(produto);
        }

    }
}