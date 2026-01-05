using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationCooretiva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Obras");

            migrationBuilder.RenameColumn(
                name: "Unidade",
                table: "Servicos",
                newName: "UnidadeMedida");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Servicos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Unidade",
                table: "Materiais",
                newName: "UnidadeMedida");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Depositos",
                newName: "Nome");

            migrationBuilder.AddColumn<Guid>(
                name: "DepositoId",
                table: "Trechos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstaCompleto",
                table: "Trechos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Prefixo",
                table: "Equipamentos",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrefixoObra",
                table: "Equipamentos",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Depositos",
                type: "REAL",
                precision: 10,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Depositos",
                type: "REAL",
                precision: 10,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nivel = table.Column<int>(type: "INTEGER", nullable: false),
                    Categoria = table.Column<int>(type: "INTEGER", nullable: false),
                    Origem = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Mensagem = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Excecao = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true),
                    ContextoJson = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true),
                    UsuarioId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Tela = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trechos_DepositoId",
                table: "Trechos",
                column: "DepositoId");

            migrationBuilder.CreateIndex(
                name: "idx_logs_categoria",
                table: "Logs",
                column: "Categoria");

            migrationBuilder.CreateIndex(
                name: "idx_logs_nivel",
                table: "Logs",
                column: "Nivel");

            migrationBuilder.CreateIndex(
                name: "idx_logs_timestamp",
                table: "Logs",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "idx_logs_usuario",
                table: "Logs",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trechos_Depositos_DepositoId",
                table: "Trechos",
                column: "DepositoId",
                principalTable: "Depositos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trechos_Depositos_DepositoId",
                table: "Trechos");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Trechos_DepositoId",
                table: "Trechos");

            migrationBuilder.DropColumn(
                name: "DepositoId",
                table: "Trechos");

            migrationBuilder.DropColumn(
                name: "EstaCompleto",
                table: "Trechos");

            migrationBuilder.DropColumn(
                name: "Prefixo",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "PrefixoObra",
                table: "Equipamentos");

            migrationBuilder.RenameColumn(
                name: "UnidadeMedida",
                table: "Servicos",
                newName: "Unidade");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Servicos",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "UnidadeMedida",
                table: "Materiais",
                newName: "Unidade");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Depositos",
                newName: "Descricao");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Obras",
                type: "TEXT",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Depositos",
                type: "TEXT",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldPrecision: 10,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Depositos",
                type: "TEXT",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldPrecision: 10,
                oldScale: 6,
                oldNullable: true);
        }
    }
}
