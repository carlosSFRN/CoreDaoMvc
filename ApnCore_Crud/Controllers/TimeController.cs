using ApnCore_Crud.Models;
using ApnCore_Crud.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApnCore_Crud.Controllers
{
    public class TimeController : Controller
    {
        private readonly ITimeRepository timeDAO;
        public TimeController(ITimeRepository _funcionario)
        {
            timeDAO = _funcionario;
        }

        public IActionResult Index()
        {
            List<Time> listaTime = timeDAO.GetAll().ToList();

            return View(listaTime);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Time time = timeDAO.Get(id);

            if (time == null)
            {
                return NotFound();
            }
            return View(time);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Time time)
        {
            if (ModelState.IsValid)
            {
                timeDAO.Add(time);
                return RedirectToAction("Index");
            }
            return View(time);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Time time = timeDAO.Get(id);

            if (time == null)
            {
                return NotFound();
            }
            return View(time);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Time time)
        {
            if (id != time.idTime)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                timeDAO.Update(time);
                return RedirectToAction("Index");
            }
            return View(time);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Time time = timeDAO.Get(id);

            if (time == null)
            {
                return NotFound();
            }
            return View(time);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            timeDAO.Delete(id);
            return RedirectToAction("Index");
        }
    }
}