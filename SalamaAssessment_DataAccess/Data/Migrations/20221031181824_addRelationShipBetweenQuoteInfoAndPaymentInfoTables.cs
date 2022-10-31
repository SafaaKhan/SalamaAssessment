using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalamaAssessment.Data.Migrations
{
    public partial class addRelationShipBetweenQuoteInfoAndPaymentInfoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentInfoId",
                table: "QuoteInfo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteInfo_PaymentInfoId",
                table: "QuoteInfo",
                column: "PaymentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteInfo_PaymentInfo_PaymentInfoId",
                table: "QuoteInfo",
                column: "PaymentInfoId",
                principalTable: "PaymentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteInfo_PaymentInfo_PaymentInfoId",
                table: "QuoteInfo");

            migrationBuilder.DropIndex(
                name: "IX_QuoteInfo_PaymentInfoId",
                table: "QuoteInfo");

            migrationBuilder.DropColumn(
                name: "PaymentInfoId",
                table: "QuoteInfo");
        }
    }
}
