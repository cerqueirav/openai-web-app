namespace GptWeb.Models.ViewModels
{
    public class PedidoFormViewModel
    {
        public Pedido Pedido { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; }
    }
}
