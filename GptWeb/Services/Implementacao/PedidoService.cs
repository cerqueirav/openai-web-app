using GptWeb.Models;

namespace GptWeb.Services
{
    public class PedidoService: IPedidoService
    {
        public Task<List<Pedido>> Listar()
        {
            //TODO Implementar usando EntityFramework
            return null;
        }

        public Task<Pedido> ListarPorId(int id)
        {
            //TODO Implementar usando EntityFramework
            return null;
        }

        public Task Cadastrar(Pedido pedido)
        {
            //TODO Implementar usando EntityFramework
            return null;
        }

        public Task Editar(int id, Pedido pedido)
        {
            //TODO Implementar usando EntityFramework
            return null;
        }

        public Task Deletar(int id)
        {
            //TODO Implementar usando EntityFramework
            return null;
        }
    }
}
