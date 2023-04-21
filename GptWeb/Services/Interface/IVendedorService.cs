using GptWeb.Models;

namespace GptWeb.Services
{
    public interface IVendedorService
    {
        Task<List<Vendedor>> Listar();
        Task<Vendedor> ListarPorId(int id);
        Task Cadastrar(Vendedor vendedor);
        Task Editar(int id, Vendedor vendedor);
        Task Deletar(int id);
    }
}
