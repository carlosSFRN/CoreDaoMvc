using ApnCore_Crud.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Estabelecimentos = _contextDAO.GetAllEstabelecimentos().Select(a => new SelectListItem(a.NomeEstabelecimento, a.IdEstabelecimento.ToString()));
            return View();
        }

    }
}
