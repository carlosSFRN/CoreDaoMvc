using ApnCore_Crud.Models;
using ApnCore_Crud.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Components
{
    public class Menu : ViewComponent
    {
        private readonly IMenuSistemaRepository _contextDAO;
        public Menu(IMenuSistemaRepository contextDAO)
        {
            _contextDAO = contextDAO;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            List<Sistema> listaMenu = _contextDAO.GetAll().ToList();

            return View(listaMenu);
        }
    }
}
