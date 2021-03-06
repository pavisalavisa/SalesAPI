﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(SalesDbContext))]
    partial class SalesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Domain.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ArticleNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
