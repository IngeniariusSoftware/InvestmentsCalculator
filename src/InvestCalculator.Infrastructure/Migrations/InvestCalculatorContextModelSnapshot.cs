﻿// <auto-generated />
using InvestCalculator.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvestCalculator.Infrastructure.Migrations
{
    [DbContext(typeof(InvestCalculatorContext))]
    partial class InvestCalculatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("InvestCalculator.Dtos.LowLevelInvestmentInstrumentDto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("InvestmentInstrumentType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("InvestmentInstruments");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            InvestmentInstrumentType = 2,
                            Name = "Вклад"
                        },
                        new
                        {
                            Id = 2L,
                            InvestmentInstrumentType = 0,
                            Name = "Акции"
                        },
                        new
                        {
                            Id = 3L,
                            InvestmentInstrumentType = 0,
                            Name = "ETF"
                        },
                        new
                        {
                            Id = 4L,
                            InvestmentInstrumentType = 1,
                            Name = "Облигации"
                        },
                        new
                        {
                            Id = 5L,
                            InvestmentInstrumentType = 1,
                            Name = "Фонды облигаций"
                        },
                        new
                        {
                            Id = 6L,
                            InvestmentInstrumentType = 1,
                            Name = "Золото"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}