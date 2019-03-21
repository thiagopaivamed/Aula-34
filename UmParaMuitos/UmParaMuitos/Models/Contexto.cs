using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmParaMuitos.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Empregado> Empregados { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empregado>().HasOne(e => e.Trabalho).WithMany(e => e.Empregados).HasForeignKey(e => e.TrabalhoId);

            modelBuilder.Entity<Trabalho>().HasMany(t => t.Empregados).WithOne(t => t.Trabalho);
        }
    }
}
