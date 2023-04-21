using GptWeb.Models;

namespace GptWeb.Services
{
    public class SetorService : ISetorService
    {
        public SetorService() { }

        public Task<List<Setor>> Listar()
        {
            //TODO Implementar usando EntityFramework
            return null;
        }

        public Task<Setor> ListarPorId(int id)
        {
            //TODO Implementar usando EntityFramework
            return null;
        }
        public Task Cadastrar(Setor setor)
        {
            //TODO Implementar usando EntityFramework
            return null;
        }

        public Task Editar(int id, Setor setor)
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
