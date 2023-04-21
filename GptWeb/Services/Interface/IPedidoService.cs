using GptWeb.Models;

namespace GptWeb.Services
{
    public interface IPedidoService
    {
        Task<List<Pedido>> Listar();
        Task<Pedido> ListarPorId(int id);
        Task Cadastrar(Pedido pedido);
        Task Editar(int id, Pedido pedido);
        Task Deletar(int id);
    }
}
