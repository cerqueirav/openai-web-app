using GptApi.Models;

namespace GptApi.Repository.Interface
{
    public interface ISetorRepository
    {
        Setor Cadastrar(Setor setor);
        IEnumerable<Setor> Listar();
        Setor? ListarPorId(int id);
        Setor Atualizar(Setor setor);
        bool Deletar(Setor setor);
    }
}
