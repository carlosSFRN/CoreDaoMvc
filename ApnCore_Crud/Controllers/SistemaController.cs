using ApnCore_Crud.Models;
using ApnCore_Crud.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Controllers
{
    public class SistemaController : Controller
    {
        private readonly ISistemaRepository _contextDAO;
        public SistemaController(ISistemaRepository contextDAO)
        {
            _contextDAO = contextDAO;
        }

        public IActionResult Index()
        {
            List<Sistema> listaUsuario = _contextDAO.GetAll().ToList();

            return View(listaUsuario);
        }
    }
}
