﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webAPI;

#nullable disable

namespace webAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231224144426_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("webAPI.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CasovnaZnacka")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProjektId")
                        .HasColumnType("integer");

                    b.Property<string>("StopnjaResnosti")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UporabnikId")
                        .HasColumnType("integer");

                    b.Property<string>("Vsebina")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("logi");
                });

            modelBuilder.Entity("webAPI.Projekt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImeProjekta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UporabnikId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Projekti");
                });

            modelBuilder.Entity("webAPI.Uporabnik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Uporabniki");
                });
#pragma warning restore 612, 618
        }
    }
}