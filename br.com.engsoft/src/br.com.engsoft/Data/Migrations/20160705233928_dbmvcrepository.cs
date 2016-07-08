using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace br.com.engsoft.Data.Migrations
{
    public partial class dbmvcrepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    codigo_cidade = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cidadecodigo_cidade = table.Column<int>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    taxa = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.codigo_cidade);
                    table.ForeignKey(
                        name: "FK_Cidade_Cidade_Cidadecodigo_cidade",
                        column: x => x.Cidadecodigo_cidade,
                        principalTable: "Cidade",
                        principalColumn: "codigo_cidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    codigo_cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    endereco = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.codigo_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Frete",
                columns: table => new
                {
                    codigo_frete = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigo_cidade1 = table.Column<int>(nullable: false),
                    codigo_cliente1 = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    peso = table.Column<float>(nullable: false),
                    valor = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frete", x => x.codigo_frete);
                    table.ForeignKey(
                        name: "FK_Frete_Cidade_codigo_cidade1",
                        column: x => x.codigo_cidade1,
                        principalTable: "Cidade",
                        principalColumn: "codigo_cidade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frete_Cliente_codigo_cliente1",
                        column: x => x.codigo_cliente1,
                        principalTable: "Cliente",
                        principalColumn: "codigo_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_Cidadecodigo_cidade",
                table: "Cidade",
                column: "Cidadecodigo_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_Frete_codigo_cidade1",
                table: "Frete",
                column: "codigo_cidade1");

            migrationBuilder.CreateIndex(
                name: "IX_Frete_codigo_cliente1",
                table: "Frete",
                column: "codigo_cliente1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frete");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
