using GptWeb.Models;

namespace GptWeb.Services
{
    public class VendedorService : IVendedorService
    {
        public Task<List<Vendedor>> Listar()
        {
            //TODO Implementar usando EntityFramework
            return null;
        }

        public Task<Vendedor> ListarPorId(int id)
        {
            //TODO Implementar usando EntityFramework
            return null;
        }
        public Task Cadastrar(Vendedor vendedor)
        {
            //TODO Implementar usando EntityFramework
            return null;
        }

        public Task Editar(int id, Vendedor vendedor)
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
