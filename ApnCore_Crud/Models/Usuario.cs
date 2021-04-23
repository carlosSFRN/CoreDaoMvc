using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_Crud.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Nome Usuario' ")]
        [StringLength(200)]
        [Display(Name = "Nome Usuario")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Cpf' ")]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Email' ")]
        [StringLength(200)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Telefone' ")]
        [StringLength(20)]
        public string Telefone { get; set; }
    }
}
