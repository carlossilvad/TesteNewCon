using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PontoTuristico> PontosTuristicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PontoTuristico>().HasData(
                new PontoTuristico
                {
                    Id = 1,
                    Nome = "Cristo Redentor 1",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                },
                new PontoTuristico
                {
                    Id = 2,
                    Nome = "Cristo Redentor 2",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                },
                new PontoTuristico
                {
                    Id = 3,
                    Nome = "Cristo Redentor 3",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                },
                new PontoTuristico
                {
                    Id = 4,
                    Nome = "Cristo Redentor 4",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                },
                new PontoTuristico
                {
                    Id = 5,
                    Nome = "Cristo Redentor 5",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                },
                new PontoTuristico
                {
                    Id = 6,
                    Nome = "Cristo Redentor 6",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                },
                new PontoTuristico
                {
                    Id = 7,
                    Nome = "Cristo Redentor 7",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                },
                new PontoTuristico
                {
                    Id = 8,
                    Nome = "Cristo Redentor 8",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                },
                new PontoTuristico
                {
                    Id = 9,
                    Nome = "Cristo Redentor 9",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                },
                new PontoTuristico
                {
                    Id = 10,
                    Nome = "Cristo Redentor 10",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                },
                new PontoTuristico
                {
                    Id = 11,
                    Nome = "Cristo Redentor 11",
                    Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                    Localizacao = "Morro do Corcovado",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                }


                );
        }

    }
}

