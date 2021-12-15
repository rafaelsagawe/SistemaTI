﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaTI.Data;

namespace SistemaTI.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SistemaTI.Models.Documentos", b =>
                {
                    b.Property<int>("IdDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assunto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataDocumento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destinatario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroDocumento")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDocumento");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("SistemaTI.Models.Equipamento", b =>
                {
                    b.Property<int>("IdEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataMovimantacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("EquipOrigem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquipTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("EquipValor")
                        .HasColumnType("real");

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NuPatrimonio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NuSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Situacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEquipamento");

                    b.ToTable("Equipamento");
                });

            modelBuilder.Entity("SistemaTI.Models.Local", b =>
                {
                    b.Property<int>("idLocal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EquipamentoIdEquipamento")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.Property<string>("localTipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idLocal");

                    b.HasIndex("EquipamentoIdEquipamento");

                    b.ToTable("Local");
                });

            modelBuilder.Entity("SistemaTI.Models.ModeloFabicante", b =>
                {
                    b.Property<int>("idModelo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EquipamentoIdEquipamento")
                        .HasColumnType("int");

                    b.Property<string>("Fabicante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idModelo");

                    b.HasIndex("EquipamentoIdEquipamento");

                    b.ToTable("ModeloFabicante");
                });

            modelBuilder.Entity("SistemaTI.Models.Sistema", b =>
                {
                    b.Property<int>("IdSistema")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acesso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BandoDados")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clientes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoFonte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documentacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoDesenvolvimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hospedagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Linguagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomePlataforma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeSistema")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSistema");

                    b.ToTable("Sistema");
                });

            modelBuilder.Entity("SistemaTI.Models.Solicitacao", b =>
                {
                    b.Property<int>("IdSolicitacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAtendimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRecebimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Equipamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrdemServico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolitacaoStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextoSolicitacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSolicitacao");

                    b.ToTable("Solicitacao");
                });

            modelBuilder.Entity("SistemaTI.Models.Suprimento", b =>
                {
                    b.Property<int>("idSuprimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ModeloEquipamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtdSuprimento")
                        .HasColumnType("int");

                    b.Property<string>("TipoSuprimento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idSuprimento");

                    b.ToTable("Suprimento");
                });

            modelBuilder.Entity("SistemaTI.Models.Tarefa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("concluido")
                        .HasColumnType("bit");

                    b.Property<DateTime>("dataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("SistemaTI.Models.WiFi", b =>
                {
                    b.Property<int>("IdWifi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Localid")
                        .HasColumnType("int");

                    b.Property<string>("SSID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenhaADM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenhaSSID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioADM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("equipamentoIDIdEquipamento")
                        .HasColumnType("int");

                    b.HasKey("IdWifi");

                    b.HasIndex("equipamentoIDIdEquipamento");

                    b.ToTable("WiFi");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaTI.Models.Local", b =>
                {
                    b.HasOne("SistemaTI.Models.Equipamento", null)
                        .WithMany("Locais")
                        .HasForeignKey("EquipamentoIdEquipamento");
                });

            modelBuilder.Entity("SistemaTI.Models.ModeloFabicante", b =>
                {
                    b.HasOne("SistemaTI.Models.Equipamento", null)
                        .WithMany("ModeloFabicantes")
                        .HasForeignKey("EquipamentoIdEquipamento");
                });

            modelBuilder.Entity("SistemaTI.Models.WiFi", b =>
                {
                    b.HasOne("SistemaTI.Models.Equipamento", "equipamentoID")
                        .WithMany()
                        .HasForeignKey("equipamentoIDIdEquipamento");
                });
#pragma warning restore 612, 618
        }
    }
}
