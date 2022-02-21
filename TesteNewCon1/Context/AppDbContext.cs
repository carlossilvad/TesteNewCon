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

    }
}

