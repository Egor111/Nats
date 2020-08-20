﻿// <auto-generated />
using System;
using BasicFunctionality.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BasicFunctionality.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.RecipientNats", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HashCode")
                        .HasColumnType("int");

                    b.Property<int>("Numbet")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecipientTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecipientNats");
                });
#pragma warning restore 612, 618
        }
    }
}
