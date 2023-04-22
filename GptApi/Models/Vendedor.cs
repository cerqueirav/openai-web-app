using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GptApi.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }
        public int SetorId { get; set; }
        public virtual Setor Setor { get; set; }
    }
}
