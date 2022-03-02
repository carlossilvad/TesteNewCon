using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using backend.Services.Pagination;

namespace backend.Repositories.Interface
{
    public interface IPontoTuristicoRepository : IBaseRepository<PontoTuristico>
    {
        PagedList<PontoTuristico> GetPontosTuristicos(PontoTuristicoParameters pontosTuristicosParameters);

        Task<List<PontoTuristico>> GetPontosTuristicosPorNome(string search);
    }
}