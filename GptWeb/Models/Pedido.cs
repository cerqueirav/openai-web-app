using System.ComponentModel.DataAnnotations;
using GptWeb.Models.Enums;

namespace GptWeb.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Valor { get; set; }
        public int VendedorId { get; set; }

        [Display(Name = "Descrição do pedido")]
        public string Descricao { get; set; }

        public SaleStatus Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public Pedido() { }

        public Pedido(int id, DateTime data, double valor, SaleStatus status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
