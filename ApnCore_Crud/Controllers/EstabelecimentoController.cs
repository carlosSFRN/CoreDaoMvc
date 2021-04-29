using ApnCore_Crud.Models;
using ApnCore_Crud.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApnCore_Crud.Controllers
{
    public class EstabelecimentoController : Controller
    {
        private readonly IEstabelecimentoRepository _contextDAO;
        public EstabelecimentoController(IEstabelecimentoRepository contextDAO)
        {
            _contextDAO = contextDAO;
        }

        public IActionResult Index()
        {
            List<Estabelecimento> listaEstabelecimento = _contextDAO.GetAll().ToList();

            return View(listaEstabelecimento);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Estabelecimento estabelecimento = _contextDAO.GetId(id);

            if (estabelecimento == null)
            {
                return NotFound();
            }
            return View(estabelecimento);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                _contextDAO.Add(estabelecimento);
                return RedirectToAction("Index");
            }
            return View(estabelecimento);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Estabelecimento estabelecimento = _contextDAO.GetId(id);

            if (estabelecimento == null)
            {
                return NotFound();
            }
            return View(estabelecimento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Estabelecimento estabelecimento)
        {
            if (id != estabelecimento.IdEstabelecimento)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _contextDAO.Edit(estabelecimento);
                return RedirectToAction("Index");
            }
            return View(estabelecimento);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Estabelecimento estabelecimento = _contextDAO.GetId(id);

            if (estabelecimento == null)
            {
                return NotFound();
            }
            return View(estabelecimento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            _contextDAO.Delete(id);
            return RedirectToAction("Index");
        }
    }
}