using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteNewCon1.Model;

namespace TesteNewCon1.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<PontoTuristico> PontosTuristicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PontoTuristico>().HasData(
                new PontoTuristico
                {
                    Id = 1,
                    Nome = "TESTE Cristo Redentor",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                }


                );
        }

    }
}

