using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Models
{
    public class UsuarioEstabelecimento
    {
        public int IdUsuarioEstabelecimento { get; set; }
        public int IdEstabelecimento { get; set; }
        [Display(Name = "Estabelecimento")]
        public string NomeEstabelecimento { get; set; }
        public int IdUsuario { get; set; }
    }
}
