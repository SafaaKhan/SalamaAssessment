using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalamaAssessment.Data.Migrations
{
    public partial class addrelationshipBetweenPolicyAndPaymentInfoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInfo_PolicyInfo_PolicyInfoIdKey",
                table: "PaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInfo_PolicyInfoIdKey",
                table: "PaymentInfo");

            migrationBuilder.DropColumn(
                name: "PolicyInfoIdKey",
                table: "PaymentInfo");

            migrationBuilder.AddColumn<int>(
                name: "PaymentInfoIdKey",
                table: "PolicyInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyInfo_PaymentInfoIdKey",
                table: "PolicyInfo",
                column: "PaymentInfoIdKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyInfo_PaymentInfo_PaymentInfoIdKey",
                table: "PolicyInfo",
                column: "PaymentInfoIdKey",
                principalTable: "PaymentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyInfo_PaymentInfo_PaymentInfoIdKey",
                table: "PolicyInfo");

            migrationBuilder.DropIndex(
                name: "IX_PolicyInfo_PaymentInfoIdKey",
                table: "PolicyInfo");

            migrationBuilder.DropColumn(
                name: "PaymentInfoIdKey",
                table: "PolicyInfo");

            migrationBuilder.AddColumn<int>(
                name: "PolicyInfoIdKey",
                table: "PaymentInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfo_PolicyInfoIdKey",
                table: "PaymentInfo",
                column: "PolicyInfoIdKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentInfo_PolicyInfo_PolicyInfoIdKey",
                table: "PaymentInfo",
                column: "PolicyInfoIdKey",
                principalTable: "PolicyInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
