using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalamaAssessment.Data.Migrations
{
    public partial class addRelationShipBetweenQuoteInfoAndPaymentInfoTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteInfo_PaymentInfo_PaymentInfoId",
                table: "QuoteInfo");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentInfoId",
                table: "QuoteInfo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteInfo_PaymentInfo_PaymentInfoId",
                table: "QuoteInfo",
                column: "PaymentInfoId",
                principalTable: "PaymentInfo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteInfo_PaymentInfo_PaymentInfoId",
                table: "QuoteInfo");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentInfoId",
                table: "QuoteInfo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteInfo_PaymentInfo_PaymentInfoId",
                table: "QuoteInfo",
                column: "PaymentInfoId",
                principalTable: "PaymentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
