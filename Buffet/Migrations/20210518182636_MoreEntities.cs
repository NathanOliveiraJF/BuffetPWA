using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet.Migrations
{
    public partial class MoreEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventoEntity_Clientes_ClienteId",
                table: "EventoEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventoEntity",
                table: "EventoEntity");

            migrationBuilder.RenameTable(
                name: "EventoEntity",
                newName: "Eventos");

            migrationBuilder.RenameIndex(
                name: "IX_EventoEntity_ClienteId",
                table: "Eventos",
                newName: "IX_Eventos_ClienteId");

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInserido",
                table: "Clientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "Clientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Clientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextoObservacao",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TipoId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "Eventos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInserido",
                table: "Eventos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "Eventos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataTermino",
                table: "Eventos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocalId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SituacaoId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextoObservacao",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TipoId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LocalEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacaoEvento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoEvento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoId",
                table: "Clientes",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_LocalId",
                table: "Eventos",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_SituacaoId",
                table: "Eventos",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoId",
                table: "Eventos",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_TipoCliente_TipoId",
                table: "Clientes",
                column: "TipoId",
                principalTable: "TipoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Clientes_ClienteId",
                table: "Eventos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_LocalEntity_LocalId",
                table: "Eventos",
                column: "LocalId",
                principalTable: "LocalEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_SituacaoEvento_SituacaoId",
                table: "Eventos",
                column: "SituacaoId",
                principalTable: "SituacaoEvento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_TipoEvento_TipoId",
                table: "Eventos",
                column: "TipoId",
                principalTable: "TipoEvento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_TipoCliente_TipoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Clientes_ClienteId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_LocalEntity_LocalId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_SituacaoEvento_SituacaoId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_TipoEvento_TipoId",
                table: "Eventos");

            migrationBuilder.DropTable(
                name: "LocalEntity");

            migrationBuilder.DropTable(
                name: "SituacaoEvento");

            migrationBuilder.DropTable(
                name: "TipoCliente");

            migrationBuilder.DropTable(
                name: "TipoEvento");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_TipoId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_LocalId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_SituacaoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_TipoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataInserido",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TextoObservacao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "DataInserido",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "DataTermino",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "SituacaoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TextoObservacao",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Eventos");

            migrationBuilder.RenameTable(
                name: "Eventos",
                newName: "EventoEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_ClienteId",
                table: "EventoEntity",
                newName: "IX_EventoEntity_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventoEntity",
                table: "EventoEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventoEntity_Clientes_ClienteId",
                table: "EventoEntity",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
