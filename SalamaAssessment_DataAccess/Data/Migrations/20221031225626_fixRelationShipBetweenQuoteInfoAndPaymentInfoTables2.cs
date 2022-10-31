using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalamaAssessment.Data.Migrations
{
    public partial class fixRelationShipBetweenQuoteInfoAndPaymentInfoTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInfo_QuoteInfo_QuoteInfoId",
                table: "PaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInfo_QuoteInfoId",
                table: "PaymentInfo");

            migrationBuilder.AlterColumn<string>(
                name: "QuoteInfoId",
                table: "PaymentInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "QuoteInfoIdKey",
                table: "PaymentInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfo_QuoteInfoIdKey",
                table: "PaymentInfo",
                column: "QuoteInfoIdKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentInfo_QuoteInfo_QuoteInfoIdKey",
                table: "PaymentInfo",
                column: "QuoteInfoIdKey",
                principalTable: "QuoteInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInfo_QuoteInfo_QuoteInfoIdKey",
                table: "PaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInfo_QuoteInfoIdKey",
                table: "PaymentInfo");

            migrationBuilder.DropColumn(
                name: "QuoteInfoIdKey",
                table: "PaymentInfo");

            migrationBuilder.AlterColumn<int>(
                name: "QuoteInfoId",
                table: "PaymentInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
