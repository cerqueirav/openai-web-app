using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GptApi.Models
{
    [Table("StatusPedido")]
    public class StatusPedido
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
