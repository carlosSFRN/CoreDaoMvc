using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApnCore_Crud.Models
{
    [Table("Time")]
    public class Time
    {
        [Key]
        public int idTime { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
