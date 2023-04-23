using GptApi.Context;
using GptApi.Models;
using GptApi.Repository.Interface;

namespace GptApi.Repository.Implementacao
{
    public class SetorRepository : ISetorRepository
    {
        private readonly ShopContext _shopContext;
        public SetorRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public Setor Cadastrar(Setor setor)
        {
            var result = _shopContext.Setor.Add(setor);
            _shopContext.SaveChanges();
            return result.Entity;
        }
        public IEnumerable<Setor> Listar()
        {
            return _shopContext.Setor.ToList();
        }

        public Setor? ListarPorId(int id)
        {
            return _shopContext.Setor.Where(x => x.Id == id).FirstOrDefault();
        }

        public Setor Atualizar(Setor setor)
        {
            var result = _shopContext.Setor.Update(setor);
            _shopContext.SaveChanges();
            return result.Entity;
        }

        public bool Deletar(Setor setor)
        {            
            var result = _shopContext.Remove(setor);
            _shopContext.SaveChanges();
            return (result is not null);
        }
    }
}
