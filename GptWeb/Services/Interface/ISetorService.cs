using GptWeb.Models;

namespace GptWeb.Services
{
    public interface ISetorService
    {
        Task<List<Setor>> Listar();
        Task<Setor> ListarPorId(int id);
        Task Cadastrar(Setor setor);
        Task Editar(int id, Setor setor);
        Task Deletar(int id);
    }
}
