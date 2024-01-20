﻿// <auto-generated />
using System;
using JeBalance.Architecture.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JeBalance.Architecture.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240120093539_adresse2")]
    partial class adresse2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("JeBalance.Architecture.SQLite.Model.DenonciationSQLite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("Horodatage")
                        .HasColumnType("TEXT")
                        .HasColumnName("horodatage");

                    b.Property<int>("IdInformateur")
                        .HasColumnType("INTEGER")
                        .HasColumnName("fk_informateur");

                    b.Property<int?>("IdReponse")
                        .HasColumnType("INTEGER")
                        .HasColumnName("fk_reponse");

                    b.Property<int>("IdSuspect")
                        .HasColumnType("INTEGER")
                        .HasColumnName("fk_suspect");

                    b.Property<int>("InformateurId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PaysEvasion")
                        .HasColumnType("TEXT")
                        .HasColumnName("pays_evasion");

                    b.Property<int>("ReponseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Statut")
                        .HasColumnType("int")
                        .HasColumnName("statut");

                    b.Property<int>("SuspectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeDelit")
                        .HasColumnType("int")
                        .HasColumnName("type_delit");

                    b.HasKey("Id");

                    b.HasIndex("IdInformateur");

                    b.HasIndex("IdReponse")
                        .IsUnique();

                    b.HasIndex("IdSuspect");

                    b.ToTable("DENONCIATIONS", (string)null);
                });

            modelBuilder.Entity("JeBalance.Architecture.SQLite.Model.InformateurSQLite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("addresse");

                    b.Property<bool>("EstCalomniateur")
                        .HasColumnType("INTEGER")
                        .HasColumnName("calomniateur");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nom");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("prenom");

                    b.HasKey("Id");

                    b.ToTable("INFORMATEURS", (string)null);
                });

            modelBuilder.Entity("JeBalance.Architecture.SQLite.Model.ReponseSQLite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.HasKey("Id");

                    b.ToTable("ReponseSQLite");
                });

            modelBuilder.Entity("JeBalance.Architecture.SQLite.Model.SuspectSQLite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("adresse");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nom");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("prenom");

                    b.HasKey("Id");

                    b.ToTable("SUSPECTS", (string)null);
                });

            modelBuilder.Entity("JeBalance.Architecture.SQLite.Model.DenonciationSQLite", b =>
                {
                    b.HasOne("JeBalance.Architecture.SQLite.Model.InformateurSQLite", "Informateur")
                        .WithMany()
                        .HasForeignKey("IdInformateur")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JeBalance.Architecture.SQLite.Model.ReponseSQLite", "Reponse")
                        .WithOne()
                        .HasForeignKey("JeBalance.Architecture.SQLite.Model.DenonciationSQLite", "IdReponse")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("JeBalance.Architecture.SQLite.Model.SuspectSQLite", "Suspect")
                        .WithMany()
                        .HasForeignKey("IdSuspect")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Informateur");

                    b.Navigation("Reponse");

                    b.Navigation("Suspect");
                });
#pragma warning restore 612, 618
        }
    }
}
