using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Controllers
{
    public class MenuSistemaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
