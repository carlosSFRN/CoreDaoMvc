using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApnCore_Crud.Models
{
    [Table("Estabelecimento")]
    public class Estabelecimento
    {
        public int idEstabelecimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Nome Estabelecimento' ")]
        [StringLength(200)]
        [Display(Name = "Nome Estabelecimento")]
        public string NomeEstabelecimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Nome Fantasia' ")]
        [StringLength(200)]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Cep' ")]
        [StringLength(8)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Endereco' ")]
        [StringLength(200)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Numero' ")]
        [StringLength(10)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Bairro' ")]
        [StringLength(200)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'UF' ")]
        [StringLength(2)]
        public string Uf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Cnpj' ")]
        [StringLength(14)]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Email' ")]
        [StringLength(200)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório 'Telefone' ")]
        [StringLength(20)]
        public string Telefone { get; set; }
    }
}
