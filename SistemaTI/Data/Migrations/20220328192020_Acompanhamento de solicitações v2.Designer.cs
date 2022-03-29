﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaTI.Data;

namespace SistemaTI.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220328192020_Acompanhamento de solicitações v2")]
    partial class Acompanhamentodesolicitaçõesv2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SistemaTI.Models.ApplicationUser", b =>
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

                    b.Property<int>("LimiteTroca")
                        .HasColumnType("int");

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

                    b.Property<byte[]>("PerfilFoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PrimeiroNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreNome")
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

            modelBuilder.Entity("SistemaTI.Models.Equipamento", b =>
                {
                    b.Property<int>("IdEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataMovimantacao")
                        .HasColumnType("datetime2");

                    b.Property<float?>("EquipValor")
                        .HasColumnType("real");

                    b.Property<int?>("EspecificacaoId")
                        .HasColumnType("int");

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemProcessoID")
                        .HasColumnType("int");

                    b.Property<int?>("LocalId")
                        .HasColumnType("int");

                    b.Property<string>("NuPatrimonio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NuSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessoId")
                        .HasColumnType("int");

                    b.Property<string>("Situacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEquipamento");

                    b.HasIndex("EspecificacaoId");

                    b.HasIndex("LocalId");

                    b.HasIndex("ProcessoId");

                    b.ToTable("Equipamento");
                });

            modelBuilder.Entity("SistemaTI.Models.Especificacao", b =>
                {
                    b.Property<int>("EspecificacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Fabicante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EspecificacaoId");

                    b.ToTable("Especificacao");
                });

            modelBuilder.Entity("SistemaTI.Models.ItensProcesso", b =>
                {
                    b.Property<int>("ItensProcessoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeSimples")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProcessoId")
                        .HasColumnType("int");

                    b.Property<int>("QTD")
                        .HasColumnType("int");

                    b.HasKey("ItensProcessoId");

                    b.HasIndex("ProcessoId");

                    b.ToTable("ItensProcesso");
                });

            modelBuilder.Entity("SistemaTI.Models.Local", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("INEP")
                        .HasColumnType("int");

                    b.Property<bool>("Laboratorio")
                        .HasColumnType("bit");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NunProtocolo")
                        .HasColumnType("int");

                    b.Property<string>("Situacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.Property<string>("URG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("localTipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Local");
                });

            modelBuilder.Entity("SistemaTI.Models.Processo", b =>
                {
                    b.Property<int>("ProcessoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assunto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroProcesso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prazo")
                        .HasColumnType("int");

                    b.Property<int>("Renovacao")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioCadastro")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProcessoId");

                    b.ToTable("Processo");
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

                    b.Property<string>("Criticidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desenvolvedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documentacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoDesenvolvimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hospedagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Licenca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Linguagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomePlataforma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeSistema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SistemaOperacinal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSistema");

                    b.ToTable("Sistema");
                });

            modelBuilder.Entity("SistemaTI.Models.Solicitacao", b =>
                {
                    b.Property<int>("SolicitacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataSolicitacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrdemServico")
                        .HasColumnType("int");

                    b.Property<string>("ProblemaReportado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SolicitacaoId");

                    b.ToTable("Solicitacao");
                });

            modelBuilder.Entity("SistemaTI.Models.Suprimento", b =>
                {
                    b.Property<int>("idSuprimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EspecificacaoId")
                        .HasColumnType("int");

                    b.Property<int>("QtdSuprimento")
                        .HasColumnType("int");

                    b.Property<string>("TipoSuprimento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idSuprimento");

                    b.HasIndex("EspecificacaoId");

                    b.ToTable("Suprimento");
                });

            modelBuilder.Entity("SistemaTI.Models.Tarefa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Prioridade")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("SistemaTI.Models.Tramitacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Localizacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Movimentacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProcessoId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioTramitacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProcessoId");

                    b.ToTable("Tramitacao");
                });

            modelBuilder.Entity("SistemaTI.Models.WiFi", b =>
                {
                    b.Property<int>("IdWifi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnderecoIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EspecificacaoId")
                        .HasColumnType("int");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<string>("SSID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenhaADM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenhaSSID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioADM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("IdWifi");

                    b.HasIndex("EspecificacaoId");

                    b.HasIndex("LocalId");

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
                    b.HasOne("SistemaTI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SistemaTI.Models.ApplicationUser", null)
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

                    b.HasOne("SistemaTI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SistemaTI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaTI.Models.Equipamento", b =>
                {
                    b.HasOne("SistemaTI.Models.Especificacao", "Especificacao")
                        .WithMany("EquipamentosEspecificacao")
                        .HasForeignKey("EspecificacaoId");

                    b.HasOne("SistemaTI.Models.Local", "Local")
                        .WithMany("LocalEquipamento")
                        .HasForeignKey("LocalId");

                    b.HasOne("SistemaTI.Models.Processo", "Processo")
                        .WithMany("EquipamentoProcesso")
                        .HasForeignKey("ProcessoId");
                });

            modelBuilder.Entity("SistemaTI.Models.ItensProcesso", b =>
                {
                    b.HasOne("SistemaTI.Models.Processo", "Protocolo")
                        .WithMany("ItensProcesso")
                        .HasForeignKey("ProcessoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaTI.Models.Suprimento", b =>
                {
                    b.HasOne("SistemaTI.Models.Especificacao", "Especificacao")
                        .WithMany("SuprimentosEspecificacao")
                        .HasForeignKey("EspecificacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaTI.Models.Tramitacao", b =>
                {
                    b.HasOne("SistemaTI.Models.Processo", "Protocolo")
                        .WithMany("Tramitar")
                        .HasForeignKey("ProcessoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaTI.Models.WiFi", b =>
                {
                    b.HasOne("SistemaTI.Models.Especificacao", "Especificacao")
                        .WithMany("WiFiModelo")
                        .HasForeignKey("EspecificacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaTI.Models.Local", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
