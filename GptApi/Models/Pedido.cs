using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GptApi.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public int VendedorId { get; set; }
        public int StatusPedidoId { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual StatusPedido Status { get; set; }
    }
}
