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
        

        // Customizando as tabelas do banco de dados do Entity
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");

            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "Usuario");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Regra");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UsuarioRegras");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UsuarioClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("LoginsUsuario");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RegraClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("TokensUsuario");
            });
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
        public DbSet<SistemaTI.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}
