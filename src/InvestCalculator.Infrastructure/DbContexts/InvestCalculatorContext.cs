using System;
using InvestCalculator.Dtos;
using InvestCalculator.Portfolio;
using Microsoft.EntityFrameworkCore;

namespace InvestCalculator.Infrastructure
{
    public class InvestCalculatorContext: DbContext
    
    {
        public InvestCalculatorContext(DbContextOptions<InvestCalculatorContext> options) :
            base(options)
        {
            
        }
        public DbSet<LowLevelInvestmentInstrumentDto> InvestmentInstruments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LowLevelInvestmentInstrumentDto>().HasData(new LowLevelInvestmentInstrumentDto{Id = 1, Name = "Вклад", InvestmentInstrumentType = HighLevelInvestmentInstruments.Cash});
            modelBuilder.Entity<LowLevelInvestmentInstrumentDto>().HasData(new LowLevelInvestmentInstrumentDto{Id = 2, Name = "Акции",InvestmentInstrumentType = HighLevelInvestmentInstruments.Shares});
            modelBuilder.Entity<LowLevelInvestmentInstrumentDto>().HasData(new LowLevelInvestmentInstrumentDto{Id = 3, Name = "ETF", InvestmentInstrumentType = HighLevelInvestmentInstruments.Shares});
            modelBuilder.Entity<LowLevelInvestmentInstrumentDto>().HasData(new LowLevelInvestmentInstrumentDto{Id=4, Name = "Облигации", InvestmentInstrumentType = HighLevelInvestmentInstruments.Obligations});
            modelBuilder.Entity<LowLevelInvestmentInstrumentDto>().HasData(new LowLevelInvestmentInstrumentDto{Id = 5, Name = "Фонды облигаций", InvestmentInstrumentType = HighLevelInvestmentInstruments.Obligations});
            modelBuilder.Entity<LowLevelInvestmentInstrumentDto>().HasData(new LowLevelInvestmentInstrumentDto{Id = 6, Name = "Золото", InvestmentInstrumentType = HighLevelInvestmentInstruments.Obligations});
        }
    }
}