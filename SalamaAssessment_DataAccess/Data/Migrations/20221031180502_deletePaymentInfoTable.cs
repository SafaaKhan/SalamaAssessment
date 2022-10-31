using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalamaAssessment.Data.Migrations
{
    public partial class deletePaymentInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteInfo_PaymentInfo_PaymentInfoId",
                table: "QuoteInfo");

            migrationBuilder.DropTable(
                name: "PaymentInfo");

            migrationBuilder.DropIndex(
                name: "IX_QuoteInfo_PaymentInfoId",
                table: "QuoteInfo");

            migrationBuilder.DropColumn(
                name: "PaymentInfoId",
                table: "QuoteInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentInfoId",
                table: "QuoteInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardholderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfo", x => x.Id);
                });

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
    }
}
