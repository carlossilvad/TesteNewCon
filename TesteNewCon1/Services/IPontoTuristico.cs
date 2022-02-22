using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteNewCon1.Model;

namespace TesteNewCon1.Services
{
    public interface IPontoTuristico
    {
        Task<IEnumerable<PontoTuristico>> GetPontosTuristicos();
        Task<PontoTuristico> GetPontoTuristico(int id);
        Task<IEnumerable<PontoTuristico>> GetPontosTuristicosByNome(string nome);
        Task<IEnumerable<PontoTuristico>> GetPontosTuristicosByLocalizacao(string localizacao);
        Task CreatePontoTuristico(PontoTuristico pontoTuristico);
        Task UpdatePontoTuristico(PontoTuristico pontoTuristico);
        Task DeletePontoTuristico(PontoTuristico pontoTuristico);

    }
}
