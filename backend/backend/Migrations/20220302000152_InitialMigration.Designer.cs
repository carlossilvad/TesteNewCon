// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Context;

namespace backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220302000152_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backend.Models.PontoTuristico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("PontosTuristicos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                            Estado = "RJ",
                            Localizacao = "Morro do Corcovado",
                            Nome = "Cristo Redentor 1"
                        },
                        new
                        {
                            Id = 2,
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                            Estado = "RJ",
                            Localizacao = "Morro do Corcovado",
                            Nome = "Cristo Redentor 2"
                        },
                        new
                        {
                            Id = 3,
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                            Estado = "RJ",
                            Localizacao = "Morro do Corcovado",
                            Nome = "Cristo Redentor 3"
                        },
                        new
                        {
                            Id = 4,
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                            Estado = "RJ",
                            Localizacao = "Morro do Corcovado",
                            Nome = "Cristo Redentor 4"
                        },
                        new
                        {
                            Id = 5,
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                            Estado = "RJ",
                            Localizacao = "Morro do Corcovado",
                            Nome = "Cristo Redentor 5"
                        },
                        new
                        {
                            Id = 6,
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                            Estado = "RJ",
                            Localizacao = "Morro do Corcovado",
                            Nome = "Cristo Redentor 6"
                        },
                        new
                        {
                            Id = 7,
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                            Estado = "RJ",
                            Localizacao = "Morro do Corcovado",
                            Nome = "Cristo Redentor 7"
                        },
                        new
                        {
                            Id = 8,
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                            Estado = "RJ",
                            Localizacao = "Morro do Corcovado",
                            Nome = "Cristo Redentor 8"
                        },
                        new
                        {
                            Id = 9,
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                            Estado = "RJ",
                            Localizacao = "Morro do Corcovado",
                            Nome = "Cristo Redentor 9"
                        },
                        new
                        {
                            Id = 10,
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                            Estado = "RJ",
                            Localizacao = "Morro do Corcovado",
                            Nome = "Cristo Redentor 10"
                        },
                        new
                        {
                            Id = 11,
                            Cidade = "Rio de Janeiro",
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cristo Redentor é uma estátua art déco que retrata Jesus Cristo.",
                            Estado = "RJ",
                            Localizacao = "Morro do Corcovado",
                            Nome = "Cristo Redentor 11"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
