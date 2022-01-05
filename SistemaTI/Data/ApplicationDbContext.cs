using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaTI.Models;

namespace SistemaTI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SistemaTI.Models.Local> Local { get; set; }
        public DbSet<SistemaTI.Models.Tarefa> Tarefa { get; set; }
        public DbSet<SistemaTI.Models.Equipamento> Equipamento { get; set; }
        public DbSet<SistemaTI.Models.Sistema> Sistema { get; set; }
        public DbSet<SistemaTI.Models.ModeloFabicante> ModeloFabicante { get; set; }
        public DbSet<SistemaTI.Models.Suprimento> Suprimento { get; set; }
        public DbSet<SistemaTI.Models.WiFi> WiFi { get; set; }
        public DbSet<SistemaTI.Models.Recebido> Recebido { get; set; }
        public DbSet<SistemaTI.Models.Enviado> Enviado { get; set; }

    }
}
