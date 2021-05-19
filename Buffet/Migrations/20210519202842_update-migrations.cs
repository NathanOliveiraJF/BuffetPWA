using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet.Migrations
{
    public partial class updatemigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_LocalEntity_LocalId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalEntity",
                table: "LocalEntity");

            migrationBuilder.RenameTable(
                name: "LocalEntity",
                newName: "LocalEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Local",
                table: "LocalEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Local_LocalId",
                table: "Eventos",
                column: "LocalId",
                principalTable: "LocalEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Local_LocalId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Local",
                table: "LocalEntity");

            migrationBuilder.RenameTable(
                name: "LocalEntity",
                newName: "LocalEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalEntity",
                table: "LocalEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_LocalEntity_LocalId",
                table: "Eventos",
                column: "LocalId",
                principalTable: "LocalEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
