using ApnCore_Crud.Models;
using ApnCore_Crud.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Controllers
{
    public class UsuarioEstabelecimentoController : Controller
    {
        private readonly IUsuarioEstabelecimentoRepository _contextDAO;
        public UsuarioEstabelecimentoController(IUsuarioEstabelecimentoRepository contextDAO)
        {
            _contextDAO = contextDAO;
        }

        public IActionResult Index(int id)
        {
            List<UsuarioEstabelecimento> listaUsuarioEstabelecimento = _contextDAO.GetAll(id).ToList();

            ViewBag.IdUsuario = id;
            return View(listaUsuarioEstabelecimento);
        }


        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.Estabelecimentos = _contextDAO.GetAllEstabelecimentos().Select(a => new SelectListItem(a.NomeEstabelecimento, a.IdEstabelecimento.ToString()));
            ViewBag.Usuario = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] UsuarioEstabelecimento usuarioEstabelecimento)
        {
            if (ModelState.IsValid)
            {
                _contextDAO.Add(usuarioEstabelecimento);
                return RedirectToAction("Index", new RouteValueDictionary(
            new { action = "Index", Id = usuarioEstabelecimento.IdUsuario }));
            }
            return View(usuarioEstabelecimento);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UsuarioEstabelecimento usuarioEstabelecimento = _contextDAO.GetId(id);

            if (usuarioEstabelecimento == null)
            {
                return NotFound();
            }
            return View(usuarioEstabelecimento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] UsuarioEstabelecimento usuarioEstabelecimento)
        {
            if (id != usuarioEstabelecimento.IdUsuario)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _contextDAO.Edit(usuarioEstabelecimento);
                return RedirectToAction("Index");
            }
            return View(usuarioEstabelecimento);
        }

        public IActionResult Delete(int? id)
        {
            UsuarioEstabelecimento usuarioEstabelecimento = _contextDAO.GetId(id);

            if (usuarioEstabelecimento == null)
            {
                return NotFound();
            }

            _contextDAO.Delete(id);

            return RedirectToAction("Index", new RouteValueDictionary(
            new { action = "Index", Id = usuarioEstabelecimento.IdUsuario }));
        }

    }
}
