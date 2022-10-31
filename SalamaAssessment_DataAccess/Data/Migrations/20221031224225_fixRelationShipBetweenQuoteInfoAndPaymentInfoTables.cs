using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalamaAssessment.Data.Migrations
{
    public partial class fixRelationShipBetweenQuoteInfoAndPaymentInfoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "QuoteInfoId",
                table: "PaymentInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfo_QuoteInfoId",
                table: "PaymentInfo",
                column: "QuoteInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentInfo_QuoteInfo_QuoteInfoId",
                table: "PaymentInfo",
                column: "QuoteInfoId",
                principalTable: "QuoteInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInfo_QuoteInfo_QuoteInfoId",
                table: "PaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInfo_QuoteInfoId",
                table: "PaymentInfo");

            migrationBuilder.DropColumn(
                name: "QuoteInfoId",
                table: "PaymentInfo");

            migrationBuilder.AddColumn<string>(
                name: "PaymentInfoId",
                table: "QuoteInfo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuoteInfo_PaymentInfoId",
                table: "QuoteInfo",
                column: "PaymentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteInfo_PaymentInfo_PaymentInfoId",
                table: "QuoteInfo",
                column: "PaymentInfoId",
                principalTable: "PaymentInfo",
                principalColumn: "Id");
        }
    }
}
