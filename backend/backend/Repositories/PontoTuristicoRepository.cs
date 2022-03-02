using backend.Services.Pagination;
using backend.Context;
using backend.Models;
using System.Linq;
using backend.Repositories.Interface;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace backend.Repositories
{
    public class PontoTuristicoRepository : BaseRepository<PontoTuristico>, IPontoTuristicoRepository
    {
        protected new readonly AppDbContext _context;

        public PontoTuristicoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PontoTuristico>> GetPontosTuristicosPorNome(string T)
        {
            var pontosTuristicos = await _context.PontosTuristicos.Where(
                c => c.Nome.Contains(T) || 
                c.Cidade.Contains(T) || 
                c.Descricao.Contains(T) || 
                c.Localizacao.Contains(T) || 
                c.Estado.Contains(T)).ToListAsync();

            return pontosTuristicos;
        }

        public PagedList<PontoTuristico> GetPontosTuristicos(PontoTuristicoParameters produtosParameters)
        {
            return PagedList<PontoTuristico>.ToPagedList(_context.PontosTuristicos.OrderByDescending(on => on.Id),
                produtosParameters.PageNumber, produtosParameters.PageSize);
        }
    }
}