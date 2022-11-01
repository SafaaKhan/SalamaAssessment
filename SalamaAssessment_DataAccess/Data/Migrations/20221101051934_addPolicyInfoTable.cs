using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalamaAssessment.Data.Migrations
{
    public partial class addPolicyInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolicyInfoIdKey",
                table: "PaymentInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PolicyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyInfo", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentInfo_PolicyInfo_PolicyInfoIdKey",
                table: "PaymentInfo");

            migrationBuilder.DropTable(
                name: "PolicyInfo");

            migrationBuilder.DropIndex(
                name: "IX_PaymentInfo_PolicyInfoIdKey",
                table: "PaymentInfo");

            migrationBuilder.DropColumn(
                name: "PolicyInfoIdKey",
                table: "PaymentInfo");
        }
    }
}
