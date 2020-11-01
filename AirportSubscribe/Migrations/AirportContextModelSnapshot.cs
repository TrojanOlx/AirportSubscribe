﻿// <auto-generated />
using AirportSubscribe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirportSubscribe.Migrations
{
    [DbContext(typeof(AirportContext))]
    partial class AirportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AirportSubscribe.Models.UrlModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UrlString")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UrlType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UrlModels");
                });
#pragma warning restore 612, 618
        }
    }
}
