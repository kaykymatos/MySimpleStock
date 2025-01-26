using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySimpleStock.Api.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldOnMonthlyProfitReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "MonthlyProfitReports",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "MonthlyProfitReports");
        }
    }
}
