using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PopulaBancoDadosIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dataAtual = DateTime.UtcNow;

            // ===========================
            // OBRAS
            // ===========================
            var obraId1 = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var obraId2 = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var obraId3 = Guid.Parse("33333333-3333-3333-3333-333333333333");

            migrationBuilder.InsertData(
                table: "Obras",
                columns: ["Id", "Codigo", "Nome", "DataInicio", "DataFim", "Ativa", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { obraId1, "OBR-001", "Duplicação BR-153 - Trecho Anápolis", new DateTime(2024, 1, 15), new DateTime(2025, 12, 31), true, dataAtual, dataAtual },
                { obraId2, "OBR-002", "Restauração GO-060 - Goiânia/Trindade", new DateTime(2024, 3, 1), new DateTime(2025, 8, 30), true, dataAtual, dataAtual },
                { obraId3, "OBR-003", "Pavimentação GO-222 - Setor Rural", new DateTime(2023, 10, 1), new DateTime(2025, 6, 15), true, dataAtual, dataAtual }
                });

            // ===========================
            // MATERIAIS
            // ===========================
            var materialId1 = Guid.Parse("a1111111-1111-1111-1111-111111111111");
            var materialId2 = Guid.Parse("a2222222-2222-2222-2222-222222222222");
            var materialId3 = Guid.Parse("a3333333-3333-3333-3333-333333333333");
            var materialId4 = Guid.Parse("a4444444-4444-4444-4444-444444444444");
            var materialId5 = Guid.Parse("a5555555-5555-5555-5555-555555555555");
            var materialId6 = Guid.Parse("a6666666-6666-6666-6666-666666666666");

            migrationBuilder.InsertData(
                table: "Materiais",
                columns: ["Id", "Codigo", "Descricao", "UnidadeMedida", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { materialId1, "MAT-001", "CBUQ - Concreto Betuminoso Usinado a Quente", "m³", dataAtual, dataAtual },
                { materialId2, "MAT-002", "Cascalho Britado", "m³", dataAtual, dataAtual },
                { materialId3, "MAT-003", "Brita Graduada", "m³", dataAtual, dataAtual },
                { materialId4, "MAT-004", "Emulsão Asfáltica RR-2C", "ton", dataAtual, dataAtual },
                { materialId5, "MAT-005", "Areia de Brita", "m³", dataAtual, dataAtual },
                { materialId6, "MAT-006", "Micro Revestimento a Frio", "m³", dataAtual, dataAtual }
                });

            // ===========================
            // SERVIÇOS - OBRA 1
            // ===========================
            var servicoId1 = Guid.Parse("b1111111-1111-1111-1111-111111111111");
            var servicoId2 = Guid.Parse("b1222222-2222-2222-2222-222222222222");
            var servicoId3 = Guid.Parse("b1333333-3333-3333-3333-333333333333");
            var servicoId4 = Guid.Parse("b1444444-4444-4444-4444-444444444444");

            migrationBuilder.InsertData(
                table: "Servicos",
                columns: ["Id", "Codigo", "Nome", "UnidadeMedida", "Ativo", "ObraId", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { servicoId1, "SRV-001", "Limpeza de Pista", "m²", true, obraId1, dataAtual, dataAtual },
                { servicoId2, "SRV-002", "Aplicação de CBUQ", "m³", true, obraId1, dataAtual, dataAtual },
                { servicoId3, "SRV-003", "Transporte de Material CB", "m³", true, obraId1, dataAtual, dataAtual },
                { servicoId4, "SRV-004", "Fresagem de Pavimento", "m²", true, obraId1, dataAtual, dataAtual }
                });

            // ===========================
            // SERVIÇOS - OBRA 2
            // ===========================
            var servicoId5 = Guid.Parse("b2111111-1111-1111-1111-111111111111");
            var servicoId6 = Guid.Parse("b2222222-2222-2222-2222-222222222222");
            var servicoId7 = Guid.Parse("b2333333-3333-3333-3333-333333333333");

            migrationBuilder.InsertData(
                table: "Servicos",
                columns: ["Id", "Codigo", "Nome", "UnidadeMedida", "Ativo", "ObraId", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { servicoId5, "SRV-005", "Limpeza de Pista", "m²", true, obraId2, dataAtual, dataAtual },
                { servicoId6, "SRV-006", "Aplicação de Micro Revestimento", "m²", true, obraId2, dataAtual, dataAtual },
                { servicoId7, "SRV-007", "Bota Dentro/Bota Fora com Escavadeira", "m³", true, obraId2, dataAtual, dataAtual }
                });

            // ===========================
            // SERVIÇOS - OBRA 3
            // ===========================
            var servicoId8 = Guid.Parse("b3111111-1111-1111-1111-111111111111");
            var servicoId9 = Guid.Parse("b3222222-2222-2222-2222-222222222222");
            var servicoId10 = Guid.Parse("b3333333-3333-3333-3333-333333333333");

            migrationBuilder.InsertData(
                table: "Servicos",
                columns: ["Id", "Codigo", "Nome", "UnidadeMedida", "Ativo", "ObraId", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { servicoId8, "SRV-008", "Aplicação de CBUQ", "m³", true, obraId3, dataAtual, dataAtual },
                { servicoId9, "SRV-009", "Transporte de Material CB", "m³", true, obraId3, dataAtual, dataAtual },
                { servicoId10, "SRV-010", "Limpeza de Pista", "m²", true, obraId3, dataAtual, dataAtual }
                });

            // ===========================
            // TRECHOS - OBRA 1
            // ===========================
            var trechoId1 = Guid.Parse("c1111111-1111-1111-1111-111111111111");
            var trechoId2 = Guid.Parse("c1222222-2222-2222-2222-222222222222");

            migrationBuilder.InsertData(
                table: "Trechos",
                columns: ["Id", "Codigo", "Descricao", "Tipo", "PistaDupla", "EstaCompleto", "EstacaInicial", "EstacaFinal", "ObraId", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { trechoId1, "TRC-001", "Trecho 1 - Estaca 0+000 a 250+000", 0, true, false, 0m, 250m, obraId1, dataAtual, dataAtual },
                { trechoId2, "TRC-002", "Trecho 2 - Estaca 250+000 a 500+000", 0, true, false, 250m, 500m, obraId1, dataAtual, dataAtual }
                });

            // ===========================
            // TRECHOS - OBRA 2
            // ===========================
            var trechoId3 = Guid.Parse("c2111111-1111-1111-1111-111111111111");
            var trechoId4 = Guid.Parse("c2222222-2222-2222-2222-222222222222");

            migrationBuilder.InsertData(
                table: "Trechos",
                columns: ["Id", "Codigo", "Descricao", "Tipo", "PistaDupla", "EstaCompleto", "EstacaInicial", "EstacaFinal", "ObraId", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { trechoId3, "TRC-003", "Trecho 1 - KM 0 a KM 15", 1, false, false, 0m, 15m, obraId2, dataAtual, dataAtual },
                { trechoId4, "TRC-004", "Trecho 2 - KM 15 a KM 28", 1, false, false, 15m, 28m, obraId2, dataAtual, dataAtual }
                });

            // ===========================
            // TRECHOS - OBRA 3
            // ===========================
            var trechoId5 = Guid.Parse("c3111111-1111-1111-1111-111111111111");
            var trechoId6 = Guid.Parse("c3222222-2222-2222-2222-222222222222");

            migrationBuilder.InsertData(
                table: "Trechos",
                columns: ["Id", "Codigo", "Descricao", "Tipo", "PistaDupla", "EstaCompleto", "EstacaInicial", "EstacaFinal", "ObraId", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { trechoId5, "TRC-005", "Trecho 1 - Estaca 0+000 a 180+000", 0, false, false, 0m, 180m, obraId3, dataAtual, dataAtual },
                { trechoId6, "TRC-006", "Trecho 2 - Estaca 180+000 a 320+000", 0, false, true, 180m, 320m, obraId3, dataAtual, dataAtual }
                });

            // ===========================
            // EQUIPAMENTOS - OBRA 1
            // ===========================
            var equipamentoId1 = Guid.Parse("d1111111-1111-1111-1111-111111111111");
            var equipamentoId2 = Guid.Parse("d1222222-2222-2222-2222-222222222222");
            var equipamentoId3 = Guid.Parse("d1333333-3333-3333-3333-333333333333");

            migrationBuilder.InsertData(
                table: "Equipamentos",
                columns: ["Id", "Codigo", "Descricao", "Tipo", "Capacidade", "Placa", "Provisorio", "ObraId", "Prefixo", "PrefixoObra", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { equipamentoId1, "EQP-001", "Motoniveladora CAT 140K", 0, null, "ABC-1234", false, obraId1, "MN-01", "OBR001-MN01", dataAtual, dataAtual },
                { equipamentoId2, "EQP-002", "Caminhão Basculante Mercedes 2726", 1, 14m, "DEF-5678", false, obraId1, "CB-01", "OBR001-CB01", dataAtual, dataAtual },
                { equipamentoId3, "EQP-003", "Vibro Acabadora Vögele Super 1800", 2, null, "GHI-9012", false, obraId1, "VA-01", "OBR001-VA01", dataAtual, dataAtual }
                });

            // ===========================
            // EQUIPAMENTOS - OBRA 2
            // ===========================
            var equipamentoId4 = Guid.Parse("d2111111-1111-1111-1111-111111111111");
            var equipamentoId5 = Guid.Parse("d2222222-2222-2222-2222-222222222222");
            var equipamentoId6 = Guid.Parse("d2333333-3333-3333-3333-333333333333");

            migrationBuilder.InsertData(
                table: "Equipamentos",
                columns: ["Id", "Codigo", "Descricao", "Tipo", "Capacidade", "Placa", "Provisorio", "ObraId", "Prefixo", "PrefixoObra", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { equipamentoId4, "EQP-004", "Escavadeira Hidráulica CAT 320D", 0, null, "JKL-3456", false, obraId2, "EH-01", "OBR002-EH01", dataAtual, dataAtual },
                { equipamentoId5, "EQP-005", "Caminhão Basculante Volvo FMX 500", 1, 18m, "MNO-7890", false, obraId2, "CB-02", "OBR002-CB02", dataAtual, dataAtual },
                { equipamentoId6, "EQP-006", "Rolo Compactador BOMAG BW 213", 0, null, "PQR-2345", false, obraId2, "RC-01", "OBR002-RC01", dataAtual, dataAtual }
                });

            // ===========================
            // EQUIPAMENTOS - OBRA 3
            // ===========================
            var equipamentoId7 = Guid.Parse("d3111111-1111-1111-1111-111111111111");
            var equipamentoId8 = Guid.Parse("d3222222-2222-2222-2222-222222222222");
            var equipamentoId9 = Guid.Parse("d3333333-3333-3333-3333-333333333333");

            migrationBuilder.InsertData(
                table: "Equipamentos",
                columns: ["Id", "Codigo", "Descricao", "Tipo", "Capacidade", "Placa", "Provisorio", "ObraId", "Prefixo", "PrefixoObra", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { equipamentoId7, "EQP-007", "Vibro Acabadora Dynapac F121C", 2, null, "STU-6789", false, obraId3, "VA-02", "OBR003-VA02", dataAtual, dataAtual },
                { equipamentoId8, "EQP-008", "Caminhão Basculante Scania P360", 1, 16m, "VWX-0123", false, obraId3, "CB-03", "OBR003-CB03", dataAtual, dataAtual },
                { equipamentoId9, "EQP-009", "Fresadora Wirtgen W100", 0, null, "YZA-4567", false, obraId3, "FR-01", "OBR003-FR01", dataAtual, dataAtual }
                });

            // ===========================
            // DEPÓSITOS - OBRA 1
            // ===========================
            var depositoId1 = Guid.Parse("e1111111-1111-1111-1111-111111111111");
            var depositoId2 = Guid.Parse("e1222222-2222-2222-2222-222222222222");

            migrationBuilder.InsertData(
                table: "Depositos",
                columns: ["Id", "Codigo", "Nome", "Coordenada_Latitude", "Coordenada_Longitude", "Provisorio", "ObraId", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { depositoId1, "DEP-001", "Depósito Central BR-153 - KM 25", -16.3293, -48.9530, false, obraId1, dataAtual, dataAtual },
                { depositoId2, "DEP-002", "Depósito Secundário BR-153 - KM 45", -16.4125, -49.0215, false, obraId1, dataAtual, dataAtual }
                });

            // ===========================
            // DEPÓSITOS - OBRA 2
            // ===========================
            var depositoId3 = Guid.Parse("e2111111-1111-1111-1111-111111111111");

            migrationBuilder.InsertData(
                table: "Depositos",
                columns: ["Id", "Codigo", "Nome", "Coordenada_Latitude", "Coordenada_Longitude", "Provisorio", "ObraId", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { depositoId3, "DEP-003", "Depósito GO-060 - Base Trindade", -16.6511, -49.4889, false, obraId2, dataAtual, dataAtual }
                });

            // ===========================
            // DEPÓSITOS - OBRA 3
            // ===========================
            var depositoId4 = Guid.Parse("e3111111-1111-1111-1111-111111111111");
            var depositoId5 = Guid.Parse("e3222222-2222-2222-2222-222222222222");

            migrationBuilder.InsertData(
                table: "Depositos",
                columns: ["Id", "Codigo", "Nome", "Coordenada_Latitude", "Coordenada_Longitude", "Provisorio", "ObraId", "DataCriacao", "DataAtualizacao"],
                values: new object[,]
                {
                { depositoId4, "DEP-004", "Depósito GO-222 - Área Rural Norte", -16.2145, -49.1823, false, obraId3, dataAtual, dataAtual },
                { depositoId5, "DEP-005", "Depósito GO-222 - Área Rural Sul", -16.3876, -49.2541, false, obraId3, dataAtual, dataAtual }
                });

            // ===========================
            // RELACIONAMENTO SERVIÇO-MATERIAL (Many-to-Many)
            // ===========================
            // Assumindo que existe uma tabela de junção "ServicoMaterial"
            migrationBuilder.InsertData(
                table: "ServicoMaterial",
                columns: ["ServicosId", "MateriaisId"],
                values: new object[,]
                {
                // Obra 1 - Serviços
                { servicoId2, materialId1 }, // Aplicação de CBUQ usa CBUQ
                { servicoId3, materialId2 }, // Transporte de Material CB usa Cascalho
                { servicoId3, materialId3 }, // Transporte de Material CB usa Brita

                // Obra 2 - Serviços
                { servicoId6, materialId6 }, // Micro Revestimento usa material específico
                { servicoId6, materialId4 }, // Micro Revestimento usa Emulsão
                { servicoId7, materialId2 }, // Bota Dentro/Fora usa Cascalho

                // Obra 3 - Serviços
                { servicoId8, materialId1 }, // Aplicação de CBUQ usa CBUQ
                { servicoId9, materialId2 }, // Transporte CB usa Cascalho
                { servicoId9, materialId5 }  // Transporte CB usa Areia
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove dados na ordem inversa para respeitar as chaves estrangeiras

            // Remove relacionamento Serviço-Material
            migrationBuilder.DeleteData(table: "ServicoMaterial", keyColumns: ["ServicosId", "MateriaisId"], keyValues: [Guid.Parse("b1222222-2222-2222-2222-222222222222"), Guid.Parse("a1111111-1111-1111-1111-111111111111")]);
            migrationBuilder.DeleteData(table: "ServicoMaterial", keyColumns: ["ServicosId", "MateriaisId"], keyValues: [Guid.Parse("b1333333-3333-3333-3333-333333333333"), Guid.Parse("a2222222-2222-2222-2222-222222222222")]);
            migrationBuilder.DeleteData(table: "ServicoMaterial", keyColumns: ["ServicosId", "MateriaisId"], keyValues: [Guid.Parse("b1333333-3333-3333-3333-333333333333"), Guid.Parse("a3333333-3333-3333-3333-333333333333")]);
            migrationBuilder.DeleteData(table: "ServicoMaterial", keyColumns: ["ServicosId", "MateriaisId"], keyValues: [Guid.Parse("b2222222-2222-2222-2222-222222222222"), Guid.Parse("a6666666-6666-6666-6666-666666666666")]);
            migrationBuilder.DeleteData(table: "ServicoMaterial", keyColumns: ["ServicosId", "MateriaisId"], keyValues: [Guid.Parse("b2222222-2222-2222-2222-222222222222"), Guid.Parse("a4444444-4444-4444-4444-444444444444")]);
            migrationBuilder.DeleteData(table: "ServicoMaterial", keyColumns: ["ServicosId", "MateriaisId"], keyValues: [Guid.Parse("b2333333-3333-3333-3333-333333333333"), Guid.Parse("a2222222-2222-2222-2222-222222222222")]);
            migrationBuilder.DeleteData(table: "ServicoMaterial", keyColumns: ["ServicosId", "MateriaisId"], keyValues: [Guid.Parse("b3111111-1111-1111-1111-111111111111"), Guid.Parse("a1111111-1111-1111-1111-111111111111")]);
            migrationBuilder.DeleteData(table: "ServicoMaterial", keyColumns: ["ServicosId", "MateriaisId"], keyValues: [Guid.Parse("b3222222-2222-2222-2222-222222222222"), Guid.Parse("a2222222-2222-2222-2222-222222222222")]);
            migrationBuilder.DeleteData(table: "ServicoMaterial", keyColumns: ["ServicosId", "MateriaisId"], keyValues: [Guid.Parse("b3222222-2222-2222-2222-222222222222"), Guid.Parse("a5555555-5555-5555-5555-555555555555")]);

            // Remove Depósitos
            migrationBuilder.DeleteData(table: "Depositos", keyColumn: "Id", keyValue: Guid.Parse("e1111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Depositos", keyColumn: "Id", keyValue: Guid.Parse("e1222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "Depositos", keyColumn: "Id", keyValue: Guid.Parse("e2111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Depositos", keyColumn: "Id", keyValue: Guid.Parse("e3111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Depositos", keyColumn: "Id", keyValue: Guid.Parse("e3222222-2222-2222-2222-222222222222"));

            // Remove Equipamentos
            migrationBuilder.DeleteData(table: "Equipamentos", keyColumn: "Id", keyValue: Guid.Parse("d1111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Equipamentos", keyColumn: "Id", keyValue: Guid.Parse("d1222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "Equipamentos", keyColumn: "Id", keyValue: Guid.Parse("d1333333-3333-3333-3333-333333333333"));
            migrationBuilder.DeleteData(table: "Equipamentos", keyColumn: "Id", keyValue: Guid.Parse("d2111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Equipamentos", keyColumn: "Id", keyValue: Guid.Parse("d2222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "Equipamentos", keyColumn: "Id", keyValue: Guid.Parse("d2333333-3333-3333-3333-333333333333"));
            migrationBuilder.DeleteData(table: "Equipamentos", keyColumn: "Id", keyValue: Guid.Parse("d3111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Equipamentos", keyColumn: "Id", keyValue: Guid.Parse("d3222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "Equipamentos", keyColumn: "Id", keyValue: Guid.Parse("d3333333-3333-3333-3333-333333333333"));

            // Remove Trechos
            migrationBuilder.DeleteData(table: "Trechos", keyColumn: "Id", keyValue: Guid.Parse("c1111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Trechos", keyColumn: "Id", keyValue: Guid.Parse("c1222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "Trechos", keyColumn: "Id", keyValue: Guid.Parse("c2111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Trechos", keyColumn: "Id", keyValue: Guid.Parse("c2222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "Trechos", keyColumn: "Id", keyValue: Guid.Parse("c3111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Trechos", keyColumn: "Id", keyValue: Guid.Parse("c3222222-2222-2222-2222-222222222222"));

            // Remove Serviços
            migrationBuilder.DeleteData(table: "Servicos", keyColumn: "Id", keyValue: Guid.Parse("b1111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Servicos", keyColumn: "Id", keyValue: Guid.Parse("b1222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "Servicos", keyColumn: "Id", keyValue: Guid.Parse("b1333333-3333-3333-3333-333333333333"));
            migrationBuilder.DeleteData(table: "Servicos", keyColumn: "Id", keyValue: Guid.Parse("b1444444-4444-4444-4444-444444444444"));
            migrationBuilder.DeleteData(table: "Servicos", keyColumn: "Id", keyValue: Guid.Parse("b2111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Servicos", keyColumn: "Id", keyValue: Guid.Parse("b2222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "Servicos", keyColumn: "Id", keyValue: Guid.Parse("b2333333-3333-3333-3333-333333333333"));
            migrationBuilder.DeleteData(table: "Servicos", keyColumn: "Id", keyValue: Guid.Parse("b3111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Servicos", keyColumn: "Id", keyValue: Guid.Parse("b3222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "Servicos", keyColumn: "Id", keyValue: Guid.Parse("b3333333-3333-3333-3333-333333333333"));

            // Remove Materiais
            migrationBuilder.DeleteData(table: "Materiais", keyColumn: "Id", keyValue: Guid.Parse("a1111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Materiais", keyColumn: "Id", keyValue: Guid.Parse("a2222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "Materiais", keyColumn: "Id", keyValue: Guid.Parse("a3333333-3333-3333-3333-333333333333"));
            migrationBuilder.DeleteData(table: "Materiais", keyColumn: "Id", keyValue: Guid.Parse("a4444444-4444-4444-4444-444444444444"));
            migrationBuilder.DeleteData(table: "Materiais", keyColumn: "Id", keyValue: Guid.Parse("a5555555-5555-5555-5555-555555555555"));
            migrationBuilder.DeleteData(table: "Materiais", keyColumn: "Id", keyValue: Guid.Parse("a6666666-6666-6666-6666-666666666666"));

            // Remove Obras
            migrationBuilder.DeleteData(table: "Obras", keyColumn: "Id", keyValue: Guid.Parse("11111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "Obras", keyColumn: "Id", keyValue: Guid.Parse("22222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "Obras", keyColumn: "Id", keyValue: Guid.Parse("33333333-3333-3333-3333-333333333333"));
        }
    }
}
