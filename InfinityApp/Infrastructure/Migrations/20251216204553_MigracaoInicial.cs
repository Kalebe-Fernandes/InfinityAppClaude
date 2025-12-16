using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilaSincronizacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FichaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TipoFicha = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TipoOperacao = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    TentativasRealizadas = table.Column<int>(type: "INTEGER", nullable: false),
                    UltimaTentativa = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MensagemErro = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    DataSincronizacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilaSincronizacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materiais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Unidade = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativa = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    KeycloakId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EmailVerificado = table.Column<bool>(type: "INTEGER", nullable: false),
                    UltimoLogin = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depositos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Latitude = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    Longitude = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    Provisorio = table.Column<bool>(type: "INTEGER", nullable: false),
                    ObraId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depositos_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Capacidade = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    Placa = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Provisorio = table.Column<bool>(type: "INTEGER", nullable: false),
                    ObraId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Unidade = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    ObraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trechos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    PistaDupla = table.Column<bool>(type: "INTEGER", nullable: false),
                    EstacaInicial = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    EstacaFinal = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    ObraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trechos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trechos_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoSincronizacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ObraId = table.Column<Guid>(type: "TEXT", nullable: true),
                    QuantidadeFichas = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeSucesso = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeErro = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DuracaoSegundos = table.Column<int>(type: "INTEGER", nullable: true),
                    Detalhes = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoSincronizacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoSincronizacao_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoSincronizacao_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialServico",
                columns: table => new
                {
                    MateriaisId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServicosId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialServico", x => new { x.MateriaisId, x.ServicosId });
                    table.ForeignKey(
                        name: "FK_MaterialServico_Materiais_MateriaisId",
                        column: x => x.MateriaisId,
                        principalTable: "Materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialServico_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FichasBotaDentro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepositoOrigemId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DepositoDestinoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    DataProducao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ObraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrechoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pista = table.Column<string>(type: "TEXT", nullable: true),
                    EquipamentoExecucaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasBotaDentro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichasBotaDentro_Depositos_DepositoDestinoId",
                        column: x => x.DepositoDestinoId,
                        principalTable: "Depositos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasBotaDentro_Depositos_DepositoOrigemId",
                        column: x => x.DepositoOrigemId,
                        principalTable: "Depositos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasBotaDentro_Equipamentos_EquipamentoExecucaoId",
                        column: x => x.EquipamentoExecucaoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasBotaDentro_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasBotaDentro_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasBotaDentro_Trechos_TrechoId",
                        column: x => x.TrechoId,
                        principalTable: "Trechos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FichasCBUQ",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    DataProducao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ObraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrechoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pista = table.Column<string>(type: "TEXT", nullable: true),
                    EquipamentoExecucaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasCBUQ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichasCBUQ_Equipamentos_EquipamentoExecucaoId",
                        column: x => x.EquipamentoExecucaoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasCBUQ_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasCBUQ_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasCBUQ_Trechos_TrechoId",
                        column: x => x.TrechoId,
                        principalTable: "Trechos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FichasFresagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    DataProducao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ObraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrechoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pista = table.Column<string>(type: "TEXT", nullable: true),
                    EquipamentoExecucaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasFresagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichasFresagem_Equipamentos_EquipamentoExecucaoId",
                        column: x => x.EquipamentoExecucaoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasFresagem_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasFresagem_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasFresagem_Trechos_TrechoId",
                        column: x => x.TrechoId,
                        principalTable: "Trechos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FichasLimpezaPista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    DataProducao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ObraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrechoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pista = table.Column<string>(type: "TEXT", nullable: true),
                    EquipamentoExecucaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasLimpezaPista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichasLimpezaPista_Equipamentos_EquipamentoExecucaoId",
                        column: x => x.EquipamentoExecucaoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasLimpezaPista_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasLimpezaPista_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasLimpezaPista_Trechos_TrechoId",
                        column: x => x.TrechoId,
                        principalTable: "Trechos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FichasMicrorevestimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    DataProducao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ObraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrechoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pista = table.Column<string>(type: "TEXT", nullable: true),
                    EquipamentoExecucaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasMicrorevestimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichasMicrorevestimento_Equipamentos_EquipamentoExecucaoId",
                        column: x => x.EquipamentoExecucaoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasMicrorevestimento_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasMicrorevestimento_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasMicrorevestimento_Trechos_TrechoId",
                        column: x => x.TrechoId,
                        principalTable: "Trechos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FichasViagemCB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Capacidade = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DepositoOrigemId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DepositoDestinoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    DataProducao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ObraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrechoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pista = table.Column<string>(type: "TEXT", nullable: true),
                    EquipamentoExecucaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasViagemCB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichasViagemCB_Depositos_DepositoDestinoId",
                        column: x => x.DepositoDestinoId,
                        principalTable: "Depositos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasViagemCB_Depositos_DepositoOrigemId",
                        column: x => x.DepositoOrigemId,
                        principalTable: "Depositos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasViagemCB_Equipamentos_EquipamentoExecucaoId",
                        column: x => x.EquipamentoExecucaoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasViagemCB_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasViagemCB_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasViagemCB_Trechos_TrechoId",
                        column: x => x.TrechoId,
                        principalTable: "Trechos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApontamentosBotaDentro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FichaBotaDentroId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaterialId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QtdViagens = table.Column<int>(type: "INTEGER", nullable: false),
                    VolumeM3 = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApontamentosBotaDentro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApontamentosBotaDentro_FichasBotaDentro_FichaBotaDentroId",
                        column: x => x.FichaBotaDentroId,
                        principalTable: "FichasBotaDentro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApontamentosBotaDentro_Materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApontamentosCBUQ",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FichaCBUQId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Lado = table.Column<string>(type: "TEXT", nullable: false),
                    EstacaInicial = table.Column<int>(type: "INTEGER", nullable: false),
                    FracaoInicial = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    EstacaFinal = table.Column<int>(type: "INTEGER", nullable: false),
                    FracaoFinal = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Extensao = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Largura = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    EspessuraCm = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    AreaM2 = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    VolumeM3 = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApontamentosCBUQ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApontamentosCBUQ_FichasCBUQ_FichaCBUQId",
                        column: x => x.FichaCBUQId,
                        principalTable: "FichasCBUQ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApontamentosFresagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FichaFresagemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Lado = table.Column<string>(type: "TEXT", nullable: false),
                    EstacaInicial = table.Column<int>(type: "INTEGER", nullable: false),
                    FracaoInicial = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    EstacaFinal = table.Column<int>(type: "INTEGER", nullable: false),
                    FracaoFinal = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Extensao = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Largura = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    EspessuraCm = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    AreaM2 = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    VolumeM3 = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApontamentosFresagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApontamentosFresagem_FichasFresagem_FichaFresagemId",
                        column: x => x.FichaFresagemId,
                        principalTable: "FichasFresagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApontamentosLimpezaPista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FichaLimpezaPistaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Lado = table.Column<string>(type: "TEXT", nullable: false),
                    EstacaInicial = table.Column<int>(type: "INTEGER", nullable: false),
                    FracaoInicial = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    EstacaFinal = table.Column<int>(type: "INTEGER", nullable: false),
                    FracaoFinal = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Extensao = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Largura = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    AreaM2 = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApontamentosLimpezaPista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApontamentosLimpezaPista_FichasLimpezaPista_FichaLimpezaPistaId",
                        column: x => x.FichaLimpezaPistaId,
                        principalTable: "FichasLimpezaPista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApontamentosMicrorevestimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FichaMicrorevestimentoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Lado = table.Column<string>(type: "TEXT", nullable: false),
                    EstacaInicial = table.Column<int>(type: "INTEGER", nullable: false),
                    FracaoInicial = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    EstacaFinal = table.Column<int>(type: "INTEGER", nullable: false),
                    FracaoFinal = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Extensao = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Largura = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    EspessuraCm = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    AreaM2 = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    VolumeM3 = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApontamentosMicrorevestimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApontamentosMicrorevestimento_FichasMicrorevestimento_FichaMicrorevestimentoId",
                        column: x => x.FichaMicrorevestimentoId,
                        principalTable: "FichasMicrorevestimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApontamentosViagemCB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FichaViagemCBId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EquipamentoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaterialId = table.Column<Guid>(type: "TEXT", nullable: false),
                    HoraCarregamento = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    HoraDescarregamento = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    QtdViagens = table.Column<int>(type: "INTEGER", nullable: false),
                    VolumeM3 = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApontamentosViagemCB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApontamentosViagemCB_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApontamentosViagemCB_FichasViagemCB_FichaViagemCBId",
                        column: x => x.FichaViagemCBId,
                        principalTable: "FichasViagemCB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApontamentosViagemCB_Materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FichasEquipamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FichaViagemCBId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EquipamentoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasEquipamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichasEquipamentos_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichasEquipamentos_FichasViagemCB_FichaViagemCBId",
                        column: x => x.FichaViagemCBId,
                        principalTable: "FichasViagemCB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApontamentosCBUQMateriais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApontamentoCBUQId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaterialId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantidade = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApontamentosCBUQMateriais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApontamentosCBUQMateriais_ApontamentosCBUQ_ApontamentoCBUQId",
                        column: x => x.ApontamentoCBUQId,
                        principalTable: "ApontamentosCBUQ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApontamentosCBUQMateriais_Materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApontamentosMicrorevestimentoMateriais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApontamentoMicrorevestimentoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaterialId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantidade = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApontamentosMicrorevestimentoMateriais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApontamentosMicrorevestimentoMateriais_ApontamentosMicrorevestimento_ApontamentoMicrorevestimentoId",
                        column: x => x.ApontamentoMicrorevestimentoId,
                        principalTable: "ApontamentosMicrorevestimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApontamentosMicrorevestimentoMateriais_Materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosBotaDentro_FichaBotaDentroId",
                table: "ApontamentosBotaDentro",
                column: "FichaBotaDentroId");

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosBotaDentro_MaterialId",
                table: "ApontamentosBotaDentro",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosCBUQ_FichaCBUQId",
                table: "ApontamentosCBUQ",
                column: "FichaCBUQId");

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosCBUQMateriais_ApontamentoCBUQId_MaterialId",
                table: "ApontamentosCBUQMateriais",
                columns: new[] { "ApontamentoCBUQId", "MaterialId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosCBUQMateriais_MaterialId",
                table: "ApontamentosCBUQMateriais",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosFresagem_FichaFresagemId",
                table: "ApontamentosFresagem",
                column: "FichaFresagemId");

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosLimpezaPista_FichaLimpezaPistaId",
                table: "ApontamentosLimpezaPista",
                column: "FichaLimpezaPistaId");

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosMicrorevestimento_FichaMicrorevestimentoId",
                table: "ApontamentosMicrorevestimento",
                column: "FichaMicrorevestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosMicrorevestimentoMateriais_ApontamentoMicrorevestimentoId_MaterialId",
                table: "ApontamentosMicrorevestimentoMateriais",
                columns: new[] { "ApontamentoMicrorevestimentoId", "MaterialId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosMicrorevestimentoMateriais_MaterialId",
                table: "ApontamentosMicrorevestimentoMateriais",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosViagemCB_EquipamentoId",
                table: "ApontamentosViagemCB",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosViagemCB_FichaViagemCBId",
                table: "ApontamentosViagemCB",
                column: "FichaViagemCBId");

            migrationBuilder.CreateIndex(
                name: "IX_ApontamentosViagemCB_MaterialId",
                table: "ApontamentosViagemCB",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_Codigo",
                table: "Depositos",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_ObraId",
                table: "Depositos",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_Provisorio",
                table: "Depositos",
                column: "Provisorio");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_ObraId",
                table: "Equipamentos",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_Placa",
                table: "Equipamentos",
                column: "Placa");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_Provisorio",
                table: "Equipamentos",
                column: "Provisorio");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_Tipo",
                table: "Equipamentos",
                column: "Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_FichasBotaDentro_DataProducao",
                table: "FichasBotaDentro",
                column: "DataProducao");

            migrationBuilder.CreateIndex(
                name: "IX_FichasBotaDentro_DepositoDestinoId",
                table: "FichasBotaDentro",
                column: "DepositoDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasBotaDentro_DepositoOrigemId",
                table: "FichasBotaDentro",
                column: "DepositoOrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasBotaDentro_EquipamentoExecucaoId",
                table: "FichasBotaDentro",
                column: "EquipamentoExecucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasBotaDentro_ObraId",
                table: "FichasBotaDentro",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasBotaDentro_ObraId_Numero",
                table: "FichasBotaDentro",
                columns: new[] { "ObraId", "Numero" });

            migrationBuilder.CreateIndex(
                name: "IX_FichasBotaDentro_ServicoId",
                table: "FichasBotaDentro",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasBotaDentro_Status",
                table: "FichasBotaDentro",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_FichasBotaDentro_TrechoId",
                table: "FichasBotaDentro",
                column: "TrechoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasCBUQ_DataProducao",
                table: "FichasCBUQ",
                column: "DataProducao");

            migrationBuilder.CreateIndex(
                name: "IX_FichasCBUQ_EquipamentoExecucaoId",
                table: "FichasCBUQ",
                column: "EquipamentoExecucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasCBUQ_ObraId",
                table: "FichasCBUQ",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasCBUQ_ObraId_Numero",
                table: "FichasCBUQ",
                columns: new[] { "ObraId", "Numero" });

            migrationBuilder.CreateIndex(
                name: "IX_FichasCBUQ_ServicoId",
                table: "FichasCBUQ",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasCBUQ_Status",
                table: "FichasCBUQ",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_FichasCBUQ_TrechoId",
                table: "FichasCBUQ",
                column: "TrechoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasEquipamentos_EquipamentoId",
                table: "FichasEquipamentos",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasEquipamentos_FichaViagemCBId_EquipamentoId",
                table: "FichasEquipamentos",
                columns: new[] { "FichaViagemCBId", "EquipamentoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FichasFresagem_DataProducao",
                table: "FichasFresagem",
                column: "DataProducao");

            migrationBuilder.CreateIndex(
                name: "IX_FichasFresagem_EquipamentoExecucaoId",
                table: "FichasFresagem",
                column: "EquipamentoExecucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasFresagem_ObraId",
                table: "FichasFresagem",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasFresagem_ObraId_Numero",
                table: "FichasFresagem",
                columns: new[] { "ObraId", "Numero" });

            migrationBuilder.CreateIndex(
                name: "IX_FichasFresagem_ServicoId",
                table: "FichasFresagem",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasFresagem_Status",
                table: "FichasFresagem",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_FichasFresagem_TrechoId",
                table: "FichasFresagem",
                column: "TrechoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasLimpezaPista_DataProducao",
                table: "FichasLimpezaPista",
                column: "DataProducao");

            migrationBuilder.CreateIndex(
                name: "IX_FichasLimpezaPista_EquipamentoExecucaoId",
                table: "FichasLimpezaPista",
                column: "EquipamentoExecucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasLimpezaPista_ObraId",
                table: "FichasLimpezaPista",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasLimpezaPista_ObraId_Numero",
                table: "FichasLimpezaPista",
                columns: new[] { "ObraId", "Numero" });

            migrationBuilder.CreateIndex(
                name: "IX_FichasLimpezaPista_ServicoId",
                table: "FichasLimpezaPista",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasLimpezaPista_Status",
                table: "FichasLimpezaPista",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_FichasLimpezaPista_TrechoId",
                table: "FichasLimpezaPista",
                column: "TrechoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasMicrorevestimento_DataProducao",
                table: "FichasMicrorevestimento",
                column: "DataProducao");

            migrationBuilder.CreateIndex(
                name: "IX_FichasMicrorevestimento_EquipamentoExecucaoId",
                table: "FichasMicrorevestimento",
                column: "EquipamentoExecucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasMicrorevestimento_ObraId",
                table: "FichasMicrorevestimento",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasMicrorevestimento_ObraId_Numero",
                table: "FichasMicrorevestimento",
                columns: new[] { "ObraId", "Numero" });

            migrationBuilder.CreateIndex(
                name: "IX_FichasMicrorevestimento_ServicoId",
                table: "FichasMicrorevestimento",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasMicrorevestimento_Status",
                table: "FichasMicrorevestimento",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_FichasMicrorevestimento_TrechoId",
                table: "FichasMicrorevestimento",
                column: "TrechoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasViagemCB_DataProducao",
                table: "FichasViagemCB",
                column: "DataProducao");

            migrationBuilder.CreateIndex(
                name: "IX_FichasViagemCB_DepositoDestinoId",
                table: "FichasViagemCB",
                column: "DepositoDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasViagemCB_DepositoOrigemId",
                table: "FichasViagemCB",
                column: "DepositoOrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasViagemCB_EquipamentoExecucaoId",
                table: "FichasViagemCB",
                column: "EquipamentoExecucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasViagemCB_ObraId",
                table: "FichasViagemCB",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasViagemCB_ObraId_Numero",
                table: "FichasViagemCB",
                columns: new[] { "ObraId", "Numero" });

            migrationBuilder.CreateIndex(
                name: "IX_FichasViagemCB_ServicoId",
                table: "FichasViagemCB",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasViagemCB_Status",
                table: "FichasViagemCB",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_FichasViagemCB_TrechoId",
                table: "FichasViagemCB",
                column: "TrechoId");

            migrationBuilder.CreateIndex(
                name: "IX_FilaSincronizacao_DataSincronizacao",
                table: "FilaSincronizacao",
                column: "DataSincronizacao");

            migrationBuilder.CreateIndex(
                name: "IX_FilaSincronizacao_FichaId",
                table: "FilaSincronizacao",
                column: "FichaId");

            migrationBuilder.CreateIndex(
                name: "IX_FilaSincronizacao_Status",
                table: "FilaSincronizacao",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSincronizacao_DataInicio",
                table: "HistoricoSincronizacao",
                column: "DataInicio");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSincronizacao_ObraId",
                table: "HistoricoSincronizacao",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSincronizacao_Status",
                table: "HistoricoSincronizacao",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSincronizacao_Tipo",
                table: "HistoricoSincronizacao",
                column: "Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSincronizacao_UsuarioId",
                table: "HistoricoSincronizacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_Codigo",
                table: "Materiais",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialServico_ServicosId",
                table: "MaterialServico",
                column: "ServicosId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_Ativa",
                table: "Obras",
                column: "Ativa");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_Codigo",
                table: "Obras",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Ativo",
                table: "Servicos",
                column: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_ObraId_Codigo",
                table: "Servicos",
                columns: new[] { "ObraId", "Codigo" });

            migrationBuilder.CreateIndex(
                name: "IX_Trechos_ObraId_Codigo",
                table: "Trechos",
                columns: new[] { "ObraId", "Codigo" });

            migrationBuilder.CreateIndex(
                name: "IX_Trechos_PistaDupla",
                table: "Trechos",
                column: "PistaDupla");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Ativo",
                table: "Usuarios",
                column: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_KeycloakId",
                table: "Usuarios",
                column: "KeycloakId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Username",
                table: "Usuarios",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApontamentosBotaDentro");

            migrationBuilder.DropTable(
                name: "ApontamentosCBUQMateriais");

            migrationBuilder.DropTable(
                name: "ApontamentosFresagem");

            migrationBuilder.DropTable(
                name: "ApontamentosLimpezaPista");

            migrationBuilder.DropTable(
                name: "ApontamentosMicrorevestimentoMateriais");

            migrationBuilder.DropTable(
                name: "ApontamentosViagemCB");

            migrationBuilder.DropTable(
                name: "FichasEquipamentos");

            migrationBuilder.DropTable(
                name: "FilaSincronizacao");

            migrationBuilder.DropTable(
                name: "HistoricoSincronizacao");

            migrationBuilder.DropTable(
                name: "MaterialServico");

            migrationBuilder.DropTable(
                name: "FichasBotaDentro");

            migrationBuilder.DropTable(
                name: "ApontamentosCBUQ");

            migrationBuilder.DropTable(
                name: "FichasFresagem");

            migrationBuilder.DropTable(
                name: "FichasLimpezaPista");

            migrationBuilder.DropTable(
                name: "ApontamentosMicrorevestimento");

            migrationBuilder.DropTable(
                name: "FichasViagemCB");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Materiais");

            migrationBuilder.DropTable(
                name: "FichasCBUQ");

            migrationBuilder.DropTable(
                name: "FichasMicrorevestimento");

            migrationBuilder.DropTable(
                name: "Depositos");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Trechos");

            migrationBuilder.DropTable(
                name: "Obras");
        }
    }
}
