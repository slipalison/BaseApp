using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AcceptLaunches = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPlan", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AccountPlan",
                columns: new[] { "Id", "AcceptLaunches", "AccountName", "AccountType", "Code" },
                values: new object[,]
                {
                    { new Guid("0085fb9c-231d-4dd4-ae47-acef9746acf5"), true, "Fundo de obras", "Receita", "1.10" },
                    { new Guid("015e7216-5b47-4d06-b5ae-c7ad852e6450"), true, "Jardinagem", "Despesa", "2.3.3" },
                    { new Guid("04d1cbec-3b2c-40af-ae11-a10f61992f6b"), true, "Aviso prévio", "Despesa", "2.1.8" },
                    { new Guid("0912baaf-c96d-4c99-bdea-04fe8c1d4e55"), false, "Receitas", "Receita", "999.999.999" },
                    { new Guid("0bbf7a1f-9809-45b4-bb91-8f1e7a0a758b"), true, "Adicional de função", "Despesa", "2.1.7" },
                    { new Guid("0befd225-f57f-473d-8eb7-d3394fbc72a6"), true, "Correção monetária", "Receita", "1.11" },
                    { new Guid("0dc2506d-d607-4cf0-b135-61a162cc28df"), true, "Taxa de administração", "Despesa", "2.2.3" },
                    { new Guid("0fc46cb9-10a7-476d-8b87-cf1b0cb147eb"), true, "Acordo trabalhista", "Despesa", "2.1.15" },
                    { new Guid("1325ae6b-0906-4be8-a442-50cc0da01b1b"), true, "Rendimento de investimentos", "Receita", "5" },
                    { new Guid("1356064b-a197-4cf0-9ac6-3b5106c42d6e"), false, "Despesas bancárias", "Despesa", "3" },
                    { new Guid("14bb1794-4b7b-4ca0-9971-1a8f3e138f1f"), true, "Reserva de dependência", "Receita", "1.2" },
                    { new Guid("17d655e6-58d9-4aa9-ab00-270174e3e9fb"), true, "Pagamento duplicado", "Receita", "1.13" },
                    { new Guid("198b5d55-0e9c-4166-bd90-413f383954a1"), true, "Cesta básica", "Despesa", "2.1.14" },
                    { new Guid("2273fd42-e8b4-4bc0-88b3-69d95850e325"), true, "Resgates", "Despesa", "3.4" },
                    { new Guid("2313b92d-f466-45aa-a290-f10d9cdde7a1"), true, "Água", "Receita", "1.6" },
                    { new Guid("235edcfa-4104-48df-92ee-49304a3bb05c"), true, "Processamento de boletos", "Despesa", "3.2" },
                    { new Guid("2451444c-3e4a-4327-a67e-06f7e8dcc8d4"), false, "Receitas", "Receita", "999.999" },
                    { new Guid("263fe42a-5778-4b37-bbc4-a331febec543"), true, "INSS", "Despesa", "2.1.9" },
                    { new Guid("2a47fa3e-c806-4db9-b633-f2bc92980fba"), true, "Juros", "Despesa", "2.4.6" },
                    { new Guid("2b887533-a9a1-416c-850a-3d900cc06c5a"), true, "Vale transporte", "Despesa", "2.1.13" },
                    { new Guid("314e82af-4f44-4829-b781-8bc7ac12d41b"), true, "Seguro obrigatório", "Despesa", "2.2.5" },
                    { new Guid("335aaf56-524f-413e-9678-d95bec2deeec"), true, "Transferência entre contas", "Receita", "1.12" },
                    { new Guid("37f1f8cd-ea84-45ac-9677-a43f1f69ee70"), true, "Multas", "Despesa", "2.4.5" },
                    { new Guid("3de9397e-dfb8-48de-a6c3-e29b027a9fba"), false, "Outras receitas", "Receita", "4" },
                    { new Guid("3dead6c1-f552-40d3-a3d7-e4d79a6e3c79"), true, "Adiantamento salarial", "Despesa", "2.1.2" },
                    { new Guid("41d61ea1-5bf6-46b5-b838-683624ab5d0e"), false, "Receitas", "Receita", "999" },
                    { new Guid("420c53f9-b468-485f-84df-6bd937987c40"), true, "Luz e energia", "Receita", "1.8" },
                    { new Guid("43952b89-e4d2-4498-bd4b-47d4d117b771"), true, "Acordo", "Receita", "1.18" },
                    { new Guid("4b8ae187-8375-4ec0-b3ca-1b6f87e852b9"), true, "Água mineral", "Receita", "1.16" },
                    { new Guid("519e761e-ae1a-4744-8e49-8883aace2592"), true, "Taxa condominial", "Receita", "1.1" },
                    { new Guid("5905e325-646d-4de4-9384-79716057d7bf"), true, "Energia elétrica", "Despesa", "2.2.999" },
                    { new Guid("63fc0fcf-5753-4de6-ba12-d993a64ef363"), true, "Multa condominial", "Receita", "1.5" },
                    { new Guid("6667c738-a8e2-45a4-aa12-059d8152b7fe"), false, "Com pessoal", "Despesa", "2.1" },
                    { new Guid("6c122240-52c9-48ce-bde6-a7de113cf0eb"), true, "Rendimento de investimentos", "Receita", "5.999" },
                    { new Guid("6db1fc3f-9197-4992-86bd-a97994f0e6dc"), true, "Multas", "Receita", "1.3" },
                    { new Guid("725f93cd-b584-480c-92f2-82135d395324"), true, "Telefone", "Despesa", "2.2.6" },
                    { new Guid("76dce83c-baa9-4e8d-b7bb-f5824ae5aa70"), true, "Juros", "Receita", "1.4" },
                    { new Guid("78f8236e-4054-42f8-b45c-aff84cc0c508"), true, "13º salário", "Despesa", "2.1.5" },
                    { new Guid("7cf0a687-d145-4ac1-87a4-93da09fa7898"), true, "FGTS", "Despesa", "2.1.10" },
                    { new Guid("7d2ffbcd-722d-43dd-8664-2247a0ede85c"), true, "Xerox", "Despesa", "2.4.2" },
                    { new Guid("7e5d8641-2aea-4683-985b-d49d0c8f0d31"), true, "Honorários", "Receita", "1.19" },
                    { new Guid("83653e46-e99a-415c-9554-434cc030f75a"), true, "Taxa condominial", "Receita", "1.999.999" },
                    { new Guid("83aa9bb1-2a82-499f-a3ce-b759794a2a01"), false, "Diversas", "Despesa", "2.4" },
                    { new Guid("88872125-0fd6-48a0-bdf1-668ffc4162f8"), true, "Gás", "Receita", "1.7" },
                    { new Guid("89216a8b-c04a-4c8b-baa0-6b36430e229b"), true, "PIS", "Despesa", "2.1.11" },
                    { new Guid("90795368-24c2-42c2-9d35-070af7788085"), true, "Gás", "Despesa", "2.2.4" },
                    { new Guid("9366370e-cd94-416a-96fe-3d7f90f3c876"), false, "Mensais", "Despesa", "2.2" },
                    { new Guid("97416bf0-41f0-4cd7-8a66-089ccbb6212c"), true, "Vale refeição", "Despesa", "2.1.12" },
                    { new Guid("97fd2834-b14d-4f7f-8439-53d1441283a3"), true, "Crédito", "Receita", "1.15" },
                    { new Guid("9ae4b828-dc90-4ca6-a30b-f09b64e33551"), true, "Rendimento de investimentos", "Receita", "4.2" },
                    { new Guid("a01fcd20-6584-4f8d-8bcd-a96ea875d938"), true, "Hora extra", "Despesa", "2.1.3" },
                    { new Guid("a05f9178-7efa-4efa-9d36-05788ae08789"), true, "Correios", "Despesa", "2.4.3" },
                    { new Guid("a8cc0cb5-9dc8-441f-8e50-8b923d369e48"), true, "Taxa condominial", "Receita", "1.2.999" },
                    { new Guid("ab3fbef3-eeb8-4cef-8f9e-c014afbf2778"), true, "Estorno taxa de resgate", "Receita", "1.17" },
                    { new Guid("ab85bab5-45d8-4605-968a-dd330255f7db"), false, "Receitas", "Receita", "1" },
                    { new Guid("aeff953a-d5c0-46de-be90-8573012ceaac"), true, "Despesas judiciais", "Despesa", "2.4.4" },
                    { new Guid("af576e9a-31f6-47da-87d5-8b839e3db04a"), true, "Férias", "Despesa", "2.1.4" },
                    { new Guid("c2d62a8b-152d-49ee-8369-240a7a71ba30"), true, "Adiantamento 13º salário", "Despesa", "2.1.6" },
                    { new Guid("c3527730-bf18-490e-a913-f5ef27d69735"), true, "Fundo de reserva", "Receita", "1.9" },
                    { new Guid("c94de406-c331-4164-bdaf-2f72bb1a45fd"), true, "Água e esgoto", "Despesa", "2.2.2" },
                    { new Guid("ca5d22c0-88cf-40b0-9bb3-ab6c7f2666cb"), true, "Softwares e aplicativos", "Despesa", "2.2.7" },
                    { new Guid("d2542ca5-d887-4976-aacb-ace1ca379cae"), true, "Registro e processamento de boletos", "Despesa", "3.3" },
                    { new Guid("d2a84a5e-1da3-45b6-8b4e-967d43ab258c"), true, "Registro de boletos", "Despesa", "3.1" },
                    { new Guid("db67f854-e5f3-473e-9ab1-9a9531c5c88a"), true, "Salário", "Despesa", "2.1.1" },
                    { new Guid("dba8fae2-f7fe-478d-aa9a-ccb1f89e8776"), false, "Despesas", "Despesa", "2" },
                    { new Guid("dc37db7f-4104-4d7c-93a0-4ef5cb53da56"), false, "Manutenção", "Despesa", "2.3" },
                    { new Guid("e159aac6-ef27-47c1-92f2-007702c63fab"), true, "Elevador", "Despesa", "2.3.1" },
                    { new Guid("e4e9f5ab-fefc-4d72-a4f9-24b7a98385f6"), true, "Honorários de advogado", "Despesa", "2.4.1" },
                    { new Guid("e6e3ff32-971d-401c-a1d6-5325dc8e15f8"), true, "Cobrança", "Receita", "1.14" },
                    { new Guid("ea1c7a72-66f4-478e-9e6d-6f96974981e0"), true, "Transferência entre contas", "Despesa", "2.4.7" },
                    { new Guid("f0dda188-6f8f-4b8e-8a5f-41e60a7bf8c3"), true, "Rendimento de poupança", "Receita", "4.1" },
                    { new Guid("f5987f3c-4cc3-499d-aae5-2b43780d6ca5"), true, "Limpeza e conservação", "Despesa", "2.3.2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountPlan_AcceptLaunches",
                table: "AccountPlan",
                column: "AcceptLaunches");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPlan_AccountType",
                table: "AccountPlan",
                column: "AccountType");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPlan_Code",
                table: "AccountPlan",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPlan");
        }
    }
}
