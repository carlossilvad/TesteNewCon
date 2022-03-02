using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories.Interface
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> ObterTodos();
        
        Task<T> ObterPorId(int id);

        Task<T> Criar(T obj);

        Task<T> Atualizar(T obj);

        Task Deletar(int id);

        // List<T> LocalizaPagina<Tipo>(int pagina, int tamanhoPagina) where Tipo : class;

        // int GetTotalRegistros();
    }
}