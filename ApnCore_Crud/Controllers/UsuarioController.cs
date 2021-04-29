using ApnCore_Crud.Models;
using ApnCore_Crud.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApnCore_Crud.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _contextDAO;
        public UsuarioController(IUsuarioRepository contextDAO)
        {
            _contextDAO = contextDAO;
        }

        public IActionResult Index()
        {
            List<Usuario> listaUsuario = _contextDAO.GetAll().ToList();

            return View(listaUsuario);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Usuario usuario = _contextDAO.GetId(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contextDAO.Add(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Usuario usuario = _contextDAO.GetId(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _contextDAO.Edit(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Usuario usuario = _contextDAO.GetId(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
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
