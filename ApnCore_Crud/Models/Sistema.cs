using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Models
{
    public class Sistema
    {
        public int IdSistema { get; set; }
        public string Codigo { get; set; }
        public string Caption { get; set; }
        public string Icone { get; set; }
        public bool Bloqueio { get; set; }
        public int Ordem { get; set; }
    }
}
