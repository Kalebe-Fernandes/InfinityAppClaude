using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PopularFichasEApontamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dataAtual = DateTime.UtcNow;

            // IDs das entidades já criadas anteriormente
            var obraId1 = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var obraId2 = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var obraId3 = Guid.Parse("33333333-3333-3333-3333-333333333333");

            var servicoId1 = Guid.Parse("b1111111-1111-1111-1111-111111111111");
            var servicoId2 = Guid.Parse("b1222222-2222-2222-2222-222222222222");
            var servicoId6 = Guid.Parse("b2222222-2222-2222-2222-222222222222");
            var servicoId7 = Guid.Parse("b2333333-3333-3333-3333-333333333333");
            var servicoId8 = Guid.Parse("b3111111-1111-1111-1111-111111111111");
            var servicoId9 = Guid.Parse("b3222222-2222-2222-2222-222222222222");

            var trechoId1 = Guid.Parse("c1111111-1111-1111-1111-111111111111");
            var trechoId3 = Guid.Parse("c2111111-1111-1111-1111-111111111111");
            var trechoId5 = Guid.Parse("c3111111-1111-1111-1111-111111111111");

            var equipamentoId1 = Guid.Parse("d1111111-1111-1111-1111-111111111111");
            var equipamentoId3 = Guid.Parse("d1333333-3333-3333-3333-333333333333");
            var equipamentoId4 = Guid.Parse("d2111111-1111-1111-1111-111111111111");
            var equipamentoId6 = Guid.Parse("d2333333-3333-3333-3333-333333333333");
            var equipamentoId7 = Guid.Parse("d3111111-1111-1111-1111-111111111111");
            var equipamentoId8 = Guid.Parse("d3222222-2222-2222-2222-222222222222");

            var depositoId1 = Guid.Parse("e1111111-1111-1111-1111-111111111111");
            var depositoId3 = Guid.Parse("e2111111-1111-1111-1111-111111111111");
            var depositoId4 = Guid.Parse("e3111111-1111-1111-1111-111111111111");

            var materialId1 = Guid.Parse("a1111111-1111-1111-1111-111111111111");
            var materialId2 = Guid.Parse("a2222222-2222-2222-2222-222222222222");
            var materialId4 = Guid.Parse("a4444444-4444-4444-4444-444444444444");
            var materialId6 = Guid.Parse("a6666666-6666-6666-6666-666666666666");

            // ===========================
            // FICHAS
            // ===========================

            // OBRA 1 - Ficha 1: Limpeza de Pista
            var fichaLimpeza1Id = Guid.Parse("f1111111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "FichasLimpezaPista",
                columns: ["Id", "Numero", "DataProducao", "ObraId", "ServicoId", "TrechoId", "Pista", "EquipamentoExecucaoId", "Observacoes", "Status", "DataCriacao", "DataAtualizacao"],
                values: [fichaLimpeza1Id, 1, new DateTime(2025, 1, 2), obraId1, servicoId1, trechoId1, 0, equipamentoId1, "Limpeza inicial do trecho - Pista Norte", 1, dataAtual, dataAtual]);

            // OBRA 1 - Ficha 2: CBUQ
            var fichaCBUQ1Id = Guid.Parse("f1222222-2222-2222-2222-222222222222");
            migrationBuilder.InsertData(
                table: "FichasCBUQ",
                columns: ["Id", "Numero", "DataProducao", "ObraId", "ServicoId", "TrechoId", "Pista", "EquipamentoExecucaoId", "Observacoes", "Status", "DataCriacao", "DataAtualizacao"],
                values: [fichaCBUQ1Id, 2, new DateTime(2025, 1, 3), obraId1, servicoId2, trechoId1, 0, equipamentoId3, "Aplicação de CBUQ - Camada de 5cm", 1, dataAtual, dataAtual]);

            // OBRA 2 - Ficha 3: Microrevestimento
            var fichaMicro1Id = Guid.Parse("f2111111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "FichasMicrorevestimento",
                columns: ["Id", "Numero", "DataProducao", "ObraId", "ServicoId", "TrechoId", "Pista", "EquipamentoExecucaoId", "Observacoes", "Status", "DataCriacao", "DataAtualizacao"],
                values: [fichaMicro1Id, 1, new DateTime(2025, 1, 2), obraId2, servicoId6, trechoId3, null, equipamentoId6, "Microrevestimento aplicado com temperatura adequada", 1, dataAtual, dataAtual]);

            // OBRA 2 - Ficha 4: Bota Dentro
            var fichaBota1Id = Guid.Parse("f2222222-2222-2222-2222-222222222222");
            migrationBuilder.InsertData(
                table: "FichasBotaDentro",
                columns: ["Id", "Numero", "DataProducao", "ObraId", "ServicoId", "TrechoId", "Pista", "EquipamentoExecucaoId", "DepositoOrigemId", "DepositoDestinoId", "Observacoes", "Status", "DataCriacao", "DataAtualizacao"],
                values: [fichaBota1Id, 2, new DateTime(2025, 1, 3), obraId2, servicoId7, trechoId3, null, equipamentoId4, depositoId3, null, "Escavação e transporte de material", 1, dataAtual, dataAtual]);

            // OBRA 3 - Ficha 5: Viagem CB
            var fichaViagem1Id = Guid.Parse("f3111111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "FichasViagemCB",
                columns: ["Id", "Numero", "DataProducao", "ObraId", "ServicoId", "TrechoId", "Pista", "EquipamentoExecucaoId", "Capacidade", "DepositoOrigemId", "DepositoDestinoId", "Observacoes", "Status", "DataCriacao", "DataAtualizacao"],
                values: [fichaViagem1Id, 1, new DateTime(2025, 1, 2), obraId3, servicoId9, trechoId5, null, equipamentoId7, 16m, depositoId4, null, "Transporte de cascalho para base do pavimento", 1, dataAtual, dataAtual]);

            // OBRA 3 - Ficha 6: CBUQ
            var fichaCBUQ2Id = Guid.Parse("f3222222-2222-2222-2222-222222222222");
            migrationBuilder.InsertData(
                table: "FichasCBUQ",
                columns: ["Id", "Numero", "DataProducao", "ObraId", "ServicoId", "TrechoId", "Pista", "EquipamentoExecucaoId", "Observacoes", "Status", "DataCriacao", "DataAtualizacao"],
                values: [fichaCBUQ2Id, 2, new DateTime(2025, 1, 3), obraId3, servicoId8, trechoId5, null, equipamentoId7, "Aplicação de CBUQ - Camada de 6cm", 0, dataAtual, dataAtual]);

            // ===========================
            // RELACIONAMENTO FICHA-EQUIPAMENTO (FichaViagemCB)
            // ===========================
            var fichaEquipId1 = Guid.Parse("fe111111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "FichaEquipamentos",
                columns: ["Id", "FichaViagemCBId", "EquipamentoId", "DataCriacao", "DataAtualizacao"],
                values: [fichaEquipId1, fichaViagem1Id, equipamentoId8, dataAtual, dataAtual]);

            // ===========================
            // APONTAMENTOS - FICHA 1 (LIMPEZA DE PISTA)
            // ===========================
            var apontLimp1Id = Guid.Parse("ap111111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "ApontamentosLimpezaPista",
                columns: ["Id", "FichaLimpezaPistaId", "Lado", "EstacaInicial", "FracaoInicial", "EstacaFinal", "FracaoFinal", "Extensao", "Largura", "AreaM2", "DataCriacao", "DataAtualizacao"],
                values: [apontLimp1Id, fichaLimpeza1Id, 0, 0, 0m, 50, 0m, 1000m, 10.5m, 10500m, dataAtual, dataAtual]);

            var apontLimp2Id = Guid.Parse("ap112222-2222-2222-2222-222222222222");
            migrationBuilder.InsertData(
                table: "ApontamentosLimpezaPista",
                columns: ["Id", "FichaLimpezaPistaId", "Lado", "EstacaInicial", "FracaoInicial", "EstacaFinal", "FracaoFinal", "Extensao", "Largura", "AreaM2", "DataCriacao", "DataAtualizacao"],
                values: [apontLimp2Id, fichaLimpeza1Id, 1, 0, 0m, 50, 0m, 1000m, 10.5m, 10500m, dataAtual, dataAtual]);

            // ===========================
            // APONTAMENTOS - FICHA 2 (CBUQ)
            // ===========================
            var apontCBUQ1Id = Guid.Parse("ap211111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "ApontamentosCBUQ",
                columns: ["Id", "FichaCBUQId", "Lado", "EstacaInicial", "FracaoInicial", "EstacaFinal", "FracaoFinal", "Extensao", "Largura", "EspessuraCm", "AreaM2", "VolumeM3", "DataCriacao", "DataAtualizacao"],
                values: [apontCBUQ1Id, fichaCBUQ1Id, 0, 0, 0m, 25, 0m, 500m, 7.2m, 5m, 3600m, 18m, dataAtual, dataAtual]);

            var apontCBUQ2Id = Guid.Parse("ap212222-2222-2222-2222-222222222222");
            migrationBuilder.InsertData(
                table: "ApontamentosCBUQ",
                columns: ["Id", "FichaCBUQId", "Lado", "EstacaInicial", "FracaoInicial", "EstacaFinal", "FracaoFinal", "Extensao", "Largura", "EspessuraCm", "AreaM2", "VolumeM3", "DataCriacao", "DataAtualizacao"],
                values: [apontCBUQ2Id, fichaCBUQ1Id, 1, 0, 0m, 25, 0m, 500m, 7.2m, 5m, 3600m, 18m, dataAtual, dataAtual]);

            // Materiais do CBUQ (Apontamento 1)
            var apontCBUQMat1Id = Guid.Parse("apm11111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "ApontamentoCBUQMateriais",
                columns: ["Id", "ApontamentoCBUQId", "MaterialId", "Quantidade", "DataCriacao", "DataAtualizacao"],
                values: [apontCBUQMat1Id, apontCBUQ1Id, materialId1, 18m, dataAtual, dataAtual]);

            // Materiais do CBUQ (Apontamento 2)
            var apontCBUQMat2Id = Guid.Parse("apm12222-2222-2222-2222-222222222222");
            migrationBuilder.InsertData(
                table: "ApontamentoCBUQMateriais",
                columns: ["Id", "ApontamentoCBUQId", "MaterialId", "Quantidade", "DataCriacao", "DataAtualizacao"],
                values: [apontCBUQMat2Id, apontCBUQ2Id, materialId1, 18m, dataAtual, dataAtual]);

            // ===========================
            // APONTAMENTOS - FICHA 3 (MICROREVESTIMENTO)
            // ===========================
            var apontMicro1Id = Guid.Parse("ap311111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "ApontamentosMicrorevestimento",
                columns: ["Id", "FichaMicrorevestimentoId", "Lado", "EstacaInicial", "FracaoInicial", "EstacaFinal", "FracaoFinal", "Extensao", "Largura", "EspessuraCm", "AreaM2", "VolumeM3", "DataCriacao", "DataAtualizacao"],
                values: [apontMicro1Id, fichaMicro1Id, 0, 0, 0m, 10, 0m, 200m, 7.0m, 2m, 1400m, 2.8m, dataAtual, dataAtual]);

            var apontMicro2Id = Guid.Parse("ap312222-2222-2222-2222-222222222222");
            migrationBuilder.InsertData(
                table: "ApontamentosMicrorevestimento",
                columns: ["Id", "FichaMicrorevestimentoId", "Lado", "EstacaInicial", "FracaoInicial", "EstacaFinal", "FracaoFinal", "Extensao", "Largura", "EspessuraCm", "AreaM2", "VolumeM3", "DataCriacao", "DataAtualizacao"],
                values: [apontMicro2Id, fichaMicro1Id, 1, 0, 0m, 10, 0m, 200m, 7.0m, 2m, 1400m, 2.8m, dataAtual, dataAtual]);

            // Materiais do Microrevestimento (Apontamento 1)
            var apontMicroMat1Id = Guid.Parse("apm21111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "ApontamentoMicrorevestimentoMateriais",
                columns: ["Id", "ApontamentoMicrorevestimentoId", "MaterialId", "Quantidade", "DataCriacao", "DataAtualizacao"],
                values: [apontMicroMat1Id, apontMicro1Id, materialId6, 2.3m, dataAtual, dataAtual]);

            var apontMicroMat2Id = Guid.Parse("apm21122-1122-1122-1122-112211221122");
            migrationBuilder.InsertData(
                table: "ApontamentoMicrorevestimentoMateriais",
                columns: ["Id", "ApontamentoMicrorevestimentoId", "MaterialId", "Quantidade", "DataCriacao", "DataAtualizacao"],
                values: [apontMicroMat2Id, apontMicro1Id, materialId4, 0.5m, dataAtual, dataAtual]);

            // Materiais do Microrevestimento (Apontamento 2)
            var apontMicroMat3Id = Guid.Parse("apm22222-2222-2222-2222-222222222222");
            migrationBuilder.InsertData(
                table: "ApontamentoMicrorevestimentoMateriais",
                columns: ["Id", "ApontamentoMicrorevestimentoId", "MaterialId", "Quantidade", "DataCriacao", "DataAtualizacao"],
                values: [apontMicroMat3Id, apontMicro2Id, materialId6, 2.3m, dataAtual, dataAtual]);

            var apontMicroMat4Id = Guid.Parse("apm22233-2233-2233-2233-223322332233");
            migrationBuilder.InsertData(
                table: "ApontamentoMicrorevestimentoMateriais",
                columns: ["Id", "ApontamentoMicrorevestimentoId", "MaterialId", "Quantidade", "DataCriacao", "DataAtualizacao"],
                values: [apontMicroMat4Id, apontMicro2Id, materialId4, 0.5m, dataAtual, dataAtual]);

            // ===========================
            // APONTAMENTOS - FICHA 4 (BOTA DENTRO)
            // ===========================
            var apontBota1Id = Guid.Parse("ap411111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "ApontamentosBotaDentro",
                columns: ["Id", "FichaBotaDentroId", "MaterialId", "QtdViagens", "VolumeM3", "DataCriacao", "DataAtualizacao"],
                values: [apontBota1Id, fichaBota1Id, materialId2, 8, 144m, dataAtual, dataAtual]);

            var apontBota2Id = Guid.Parse("ap412222-2222-2222-2222-222222222222");
            migrationBuilder.InsertData(
                table: "ApontamentosBotaDentro",
                columns: ["Id", "FichaBotaDentroId", "MaterialId", "QtdViagens", "VolumeM3", "DataCriacao", "DataAtualizacao"],
                values: [apontBota2Id, fichaBota1Id, materialId2, 5, 90m, dataAtual, dataAtual]);

            // ===========================
            // APONTAMENTOS - FICHA 5 (VIAGEM CB)
            // ===========================
            var apontViagem1Id = Guid.Parse("ap511111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "ApontamentosViagemCB",
                columns: ["Id", "FichaViagemCBId", "EquipamentoId", "MaterialId", "HoraCarregamento", "HoraDescarregamento", "QtdViagens", "VolumeM3", "DataCriacao", "DataAtualizacao"],
                values: [apontViagem1Id, fichaViagem1Id, equipamentoId8, materialId2, new TimeSpan(7, 30, 0), new TimeSpan(8, 15, 0), 12, 192m, dataAtual, dataAtual]);

            var apontViagem2Id = Guid.Parse("ap512222-2222-2222-2222-222222222222");
            migrationBuilder.InsertData(
                table: "ApontamentosViagemCB",
                columns: ["Id", "FichaViagemCBId", "EquipamentoId", "MaterialId", "HoraCarregamento", "HoraDescarregamento", "QtdViagens", "VolumeM3", "DataCriacao", "DataAtualizacao"],
                values: [apontViagem2Id, fichaViagem1Id, equipamentoId8, materialId2, new TimeSpan(13, 0, 0), new TimeSpan(13, 45, 0), 8, 128m, dataAtual, dataAtual]);

            // ===========================
            // APONTAMENTOS - FICHA 6 (CBUQ - PENDENTE)
            // ===========================
            var apontCBUQ3Id = Guid.Parse("ap611111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "ApontamentosCBUQ",
                columns: ["Id", "FichaCBUQId", "Lado", "EstacaInicial", "FracaoInicial", "EstacaFinal", "FracaoFinal", "Extensao", "Largura", "EspessuraCm", "AreaM2", "VolumeM3", "DataCriacao", "DataAtualizacao"],
                values: [apontCBUQ3Id, fichaCBUQ2Id, 0, 0, 0m, 30, 0m, 600m, 7.5m, 6m, 4500m, 27m, dataAtual, dataAtual]);

            // Materiais do CBUQ (Apontamento 3)
            var apontCBUQMat3Id = Guid.Parse("apm31111-1111-1111-1111-111111111111");
            migrationBuilder.InsertData(
                table: "ApontamentoCBUQMateriais",
                columns: ["Id", "ApontamentoCBUQId", "MaterialId", "Quantidade", "DataCriacao", "DataAtualizacao"],
                values: [apontCBUQMat3Id, apontCBUQ3Id, materialId1, 27m, dataAtual, dataAtual]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove dados na ordem inversa para respeitar as chaves estrangeiras

            // Remove Materiais dos Apontamentos
            migrationBuilder.DeleteData(table: "ApontamentoCBUQMateriais", keyColumn: "Id", keyValue: Guid.Parse("apm11111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "ApontamentoCBUQMateriais", keyColumn: "Id", keyValue: Guid.Parse("apm12222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "ApontamentoCBUQMateriais", keyColumn: "Id", keyValue: Guid.Parse("apm31111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "ApontamentoMicrorevestimentoMateriais", keyColumn: "Id", keyValue: Guid.Parse("apm21111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "ApontamentoMicrorevestimentoMateriais", keyColumn: "Id", keyValue: Guid.Parse("apm21122-1122-1122-1122-112211221122"));
            migrationBuilder.DeleteData(table: "ApontamentoMicrorevestimentoMateriais", keyColumn: "Id", keyValue: Guid.Parse("apm22222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "ApontamentoMicrorevestimentoMateriais", keyColumn: "Id", keyValue: Guid.Parse("apm22233-2233-2233-2233-223322332233"));

            // Remove Apontamentos
            migrationBuilder.DeleteData(table: "ApontamentosLimpezaPista", keyColumn: "Id", keyValue: Guid.Parse("ap111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "ApontamentosLimpezaPista", keyColumn: "Id", keyValue: Guid.Parse("ap112222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "ApontamentosCBUQ", keyColumn: "Id", keyValue: Guid.Parse("ap211111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "ApontamentosCBUQ", keyColumn: "Id", keyValue: Guid.Parse("ap212222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "ApontamentosCBUQ", keyColumn: "Id", keyValue: Guid.Parse("ap611111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "ApontamentosMicrorevestimento", keyColumn: "Id", keyValue: Guid.Parse("ap311111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "ApontamentosMicrorevestimento", keyColumn: "Id", keyValue: Guid.Parse("ap312222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "ApontamentosBotaDentro", keyColumn: "Id", keyValue: Guid.Parse("ap411111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "ApontamentosBotaDentro", keyColumn: "Id", keyValue: Guid.Parse("ap412222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "ApontamentosViagemCB", keyColumn: "Id", keyValue: Guid.Parse("ap511111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "ApontamentosViagemCB", keyColumn: "Id", keyValue: Guid.Parse("ap512222-2222-2222-2222-222222222222"));

            // Remove Relacionamento Ficha-Equipamento
            migrationBuilder.DeleteData(table: "FichaEquipamentos", keyColumn: "Id", keyValue: Guid.Parse("fe111111-1111-1111-1111-111111111111"));

            // Remove Fichas
            migrationBuilder.DeleteData(table: "FichasLimpezaPista", keyColumn: "Id", keyValue: Guid.Parse("f1111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "FichasCBUQ", keyColumn: "Id", keyValue: Guid.Parse("f1222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "FichasMicrorevestimento", keyColumn: "Id", keyValue: Guid.Parse("f2111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "FichasBotaDentro", keyColumn: "Id", keyValue: Guid.Parse("f2222222-2222-2222-2222-222222222222"));
            migrationBuilder.DeleteData(table: "FichasViagemCB", keyColumn: "Id", keyValue: Guid.Parse("f3111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(table: "FichasCBUQ", keyColumn: "Id", keyValue: Guid.Parse("f3222222-2222-2222-2222-222222222222"));
        }
    }
}
