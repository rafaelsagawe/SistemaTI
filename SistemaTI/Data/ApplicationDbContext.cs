using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaTI.Models;

namespace SistemaTI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SistemaTI.Models.Local> Local { get; set; }
        public DbSet<SistemaTI.Models.Equipamento> Equipamento { get; set; }
        public DbSet<SistemaTI.Models.Especificacao> Especificacao { get; set; }
        public DbSet<SistemaTI.Models.Suprimento> Suprimento { get; set; }
        public DbSet<SistemaTI.Models.WiFi> WiFi { get; set; }
        public DbSet<SistemaTI.Models.Sistema> Sistema { get; set; }
        public DbSet<SistemaTI.Models.Tarefa> Tarefa { get; set; }
        public DbSet<SistemaTI.Models.Processo> Processo { get; set; }
        public DbSet<SistemaTI.Models.Tramitacao> Tramitacao { get; set; }
        public DbSet<SistemaTI.Models.ItensProcesso> ItensProcesso { get; set; }
        public DbSet<SistemaTI.Models.Manutencao> Manutencao { get; set; }

    }
}
