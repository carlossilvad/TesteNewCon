using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using backend.Services.Pagination;

namespace backend.Services.Interfaces
{
    public interface IPontoTuristicoService
    {
        PagedList<PontoTuristico> ObterPontosTuristicos(PontoTuristicoParameters pontosTuristicosParameters);

        Task<PontoTuristico> ObterPontoTuristicoPorId(int id);

        Task<List<PontoTuristico>> ObterPontosTuristicosPorNome(string nome);

        Task<List<PontoTuristico>> ObterPontosTuristicosPorLocalizacao(string localizacao);
        
        Task<PontoTuristico> CriarPontoTuristico(PontoTuristico pontoTuristico);
        
        Task<PontoTuristico> AtualizarPontoTuristico(int id, PontoTuristico pontoTuristico);
        
        Task DeletarPontoTuristico(int id);
    }
}
