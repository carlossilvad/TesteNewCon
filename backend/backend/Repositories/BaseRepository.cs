using backend.Context;
using backend.Models;
using backend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : PontoTuristico
    {
        protected AppDbContext _context;

        public BaseRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public virtual async Task<List<T>> ObterTodos()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public virtual async Task<T> ObterPorId(int id)
        {
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<T> Criar(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Atualizar(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }

        public List<T> LocalizaPagina<Tipo>(int numeroPagina, int quantidadeRegistros) where Tipo : class
        {
            return _context.Set<T>()
                .Skip(quantidadeRegistros * (numeroPagina - 1))
                    .Take(quantidadeRegistros).ToList();
        }

        public int GetTotalRegistros()
        {
            return _context.Set<T>().AsNoTracking().Count();
        }

        public virtual async Task Deletar(int id)
        {
            var obj = await ObterPorId(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}