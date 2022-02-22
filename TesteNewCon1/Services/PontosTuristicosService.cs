using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteNewCon1.Context;
using TesteNewCon1.Model;

namespace TesteNewCon1.Services
{
    public class PontosTuristicosService : IPontoTuristico
    {
        private readonly AppDbContext _context;

        public PontosTuristicosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PontoTuristico>> GetPontosTuristicos()
        {
            try
            {
                return await _context.PontosTuristicos.ToListAsync();
            }
            catch
            {
                throw;
            }

        }
        public async Task<IEnumerable<PontoTuristico>> GetPontosTuristicosByNome(string nome)
        {
            IEnumerable<PontoTuristico> pontosTuristicos;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                pontosTuristicos = await _context.PontosTuristicos.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                pontosTuristicos = await GetPontosTuristicos();
            }
            return pontosTuristicos;
        }

        public async Task<IEnumerable<PontoTuristico>> GetPontosTuristicosByLocalizacao(string localizacao)
        {
            IEnumerable<PontoTuristico> pontosTuristicos;
            if (!string.IsNullOrWhiteSpace(localizacao))
            {
                pontosTuristicos = await _context.PontosTuristicos.Where(n => n.Localizacao.Contains(localizacao)).ToListAsync();
            }
            else
            {
                pontosTuristicos = await GetPontosTuristicos();
            }
            return pontosTuristicos;
        }

        public async Task<PontoTuristico> GetPontoTuristico(int id)
        {
            var pontoTuristico = await _context.PontosTuristicos.FindAsync(id);
            return pontoTuristico;
        }

        public async Task CreatePontoTuristico(PontoTuristico pontoTuristico)
        {
            _context.PontosTuristicos.Add(pontoTuristico);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePontoTuristico(PontoTuristico pontoTuristico)
        {
            _context.Entry(pontoTuristico).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePontoTuristico(PontoTuristico pontoTuristico)
        {
            _context.PontosTuristicos.Remove(pontoTuristico);
            await _context.SaveChangesAsync();
        }
    }
}
