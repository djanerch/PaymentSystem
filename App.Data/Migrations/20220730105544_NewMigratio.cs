using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class NewMigratio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peoples_Statuses_StatusId",
                table: "Peoples");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Peoples_StatusId",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Peoples");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Peoples",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Peoples");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Peoples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_StatusId",
                table: "Peoples",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peoples_Statuses_StatusId",
                table: "Peoples",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
