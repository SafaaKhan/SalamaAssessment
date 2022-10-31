using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalamaAssessment.Data.Migrations
{
    public partial class addQuotationIdToQuoteInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_quoteInfo",
                table: "quoteInfo");

            migrationBuilder.RenameTable(
                name: "quoteInfo",
                newName: "QuoteInfo");

            migrationBuilder.AddColumn<string>(
                name: "QuotationId",
                table: "QuoteInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuoteInfo",
                table: "QuoteInfo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuoteInfo",
                table: "QuoteInfo");

            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "QuoteInfo");

            migrationBuilder.RenameTable(
                name: "QuoteInfo",
                newName: "quoteInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_quoteInfo",
                table: "quoteInfo",
                column: "Id");
        }
    }
}
