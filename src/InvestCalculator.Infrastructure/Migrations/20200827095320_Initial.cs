using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestCalculator.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestmentInstruments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    InvestmentInstrumentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentInstruments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "InvestmentInstruments",
                columns: new[] { "Id", "InvestmentInstrumentType", "Name" },
                values: new object[] { 1L, 2, "Вклад" });

            migrationBuilder.InsertData(
                table: "InvestmentInstruments",
                columns: new[] { "Id", "InvestmentInstrumentType", "Name" },
                values: new object[] { 2L, 0, "Акции" });

            migrationBuilder.InsertData(
                table: "InvestmentInstruments",
                columns: new[] { "Id", "InvestmentInstrumentType", "Name" },
                values: new object[] { 3L, 0, "ETF" });

            migrationBuilder.InsertData(
                table: "InvestmentInstruments",
                columns: new[] { "Id", "InvestmentInstrumentType", "Name" },
                values: new object[] { 4L, 1, "Облигации" });

            migrationBuilder.InsertData(
                table: "InvestmentInstruments",
                columns: new[] { "Id", "InvestmentInstrumentType", "Name" },
                values: new object[] { 5L, 1, "Фонды облигаций" });

            migrationBuilder.InsertData(
                table: "InvestmentInstruments",
                columns: new[] { "Id", "InvestmentInstrumentType", "Name" },
                values: new object[] { 6L, 1, "Золото" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentInstruments");
        }
    }
}
