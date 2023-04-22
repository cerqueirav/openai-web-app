using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GptApi.Models
{
    [Table("Setor")]
    public class Setor
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public Setor(string Nome)
        {
            this.Nome = Nome;
        }

        public Setor() { }
    }
}
